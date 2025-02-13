using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using BUS.ClassHelper;
using Newtonsoft.Json.Linq;
using QuanLyQuanBia.ClassHelper;

public class JSON_Settings
{
	internal string PathFileSetting;

	internal JObject json;

	public JSON_Settings(string jsonStringOrPathFile, bool isJsonString = false)
	{
		if (isJsonString)
		{
			if (jsonStringOrPathFile.Trim() == "")
			{
				jsonStringOrPathFile = "{}";
			}
			json = JObject.Parse(jsonStringOrPathFile);
			return;
		}
		try
		{
			if (jsonStringOrPathFile.Contains("\\") || jsonStringOrPathFile.Contains("/"))
			{
				PathFileSetting = jsonStringOrPathFile;
			}
			else
			{
				PathFileSetting = Common.PathExE() + "\\settings\\" + jsonStringOrPathFile + ".json";
			}
			if (!File.Exists(PathFileSetting))
			{
				using (File.AppendText(PathFileSetting))
				{
				}
			}
			json = JObject.Parse(File.ReadAllText(PathFileSetting));
		}
		catch
		{
			json = new JObject();
		}
	}

	public Dictionary<string, object> ConvertToDictionary(JObject jObject = null)
	{
        Dictionary<string, object> dic = new Dictionary<string, object>();
        try
        {
            dic = jObject.ToObject<Dictionary<string, object>>();
            List<string> list = (from x in dic.Select(delegate (KeyValuePair<string, object> r) { return new { value = r, key = r.Key }; }) where x.value.GetType() == typeof(JObject) select x.key).ToList();
            List<string> list2 = (from x in dic.Select(delegate (KeyValuePair<string, object> r) { return new { value = r, key = r.Key }; }) where x.value.GetType() == typeof(JObject) select x.key).ToList();
            list2.ForEach(delegate (string key)
            {
                dic[key] = (from x in ((JArray)dic[key]).Values()
                            select ((JValue)x).Value).ToArray();
            });
            list.ForEach(delegate (string key)
            {
                dic[key] = ConvertToDictionary(dic[key] as JObject);
            });
        }
        catch
        {
        }
        return dic;
    }

	public JSON_Settings()
	{
		json = new JObject();
	}

	public string GetValue(string key, string valueDefault = "")
	{
		string result = valueDefault;
		try
		{
			result = ((json[key] == null) ? valueDefault : json[key].ToString());
		}
		catch
		{
		}
		return result;
	}

	public List<string> GetValueList(string key, int typeSplitString = 0)
	{
		List<string> list = new List<string>();
		try
		{
			list = ((typeSplitString != 0) ? GetValue(key).Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : GetValue(key).Split('\n').ToList());
			list = Common.RemoveEmptyItems(list);
		}
		catch
		{
		}
		return list;
	}

	public int GetValueInt(string key, int valueDefault = 0)
	{
		int result = valueDefault;
		try
		{
			result = ((json[key] == null) ? valueDefault : Convert.ToInt32(json[key].ToString()));
		}
		catch
		{
		}
		return result;
	}

	public bool GetValueBool(string key, bool valueDefault = false)
	{
		bool result = valueDefault;
		try
		{
			result = ((json[key] == null) ? valueDefault : Convert.ToBoolean(json[key].ToString()));
			return result;
		}
		catch
		{
			return result;
		}
	}

	public void Add(string key, string value)
	{
		try
		{
			if (!json.ContainsKey(key))
			{
				json.Add(key, (JToken)value);
			}
			else
			{
				json[key] = (JToken)value;
			}
		}
		catch (Exception)
		{
		}
	}

	public void Update(string key, object value)
	{
		try
		{
			json[key] = (JToken)value.ToString();
		}
		catch
		{
		}
	}
	
	public void AddListToJsonObject(string key, List<string> values, int delimiterType = 0)
	{
		try
		{
			// Nếu delimiterType bằng 0, sử dụng dấu xuống dòng làm dấu phân cách
			// Nếu không, sử dụng "\n|\n"
			if (delimiterType == 0)
			{
				json[key] = (JToken)string.Join("\n", values).ToString();
			}
			else
			{
				json[key] = (JToken)string.Join("\n|\n", values).ToString();
			}
		}
		catch
		{
		}
	}


	public void Update(string key, List<string> values)
	{
		try
		{
			bool hasNewLine = false;
			foreach (string value in values)
			{
				// Kiểm tra xem giá trị có chứa dấu xuống dòng không
				if (value.Contains("\n"))
				{
					hasNewLine = true;
					break;
				}
			}

			// Nếu có dấu xuống dòng, thêm một dấu "|"
			if (hasNewLine)
			{
				json[key] = (JToken)string.Join("\n|\n", values).ToString();
			}
			else
			{
				json[key] = (JToken)string.Join("\n", values).ToString();
			}
		}
		catch
		{
		}
	}


	public void Remove(string key)
	{
		try
		{
			json.Remove(key);
		}
		catch
		{
		}
	}

	public void Save(string pathFileSetting = "")
	{
		try
		{
			if (pathFileSetting == "")
			{
				pathFileSetting = PathFileSetting;
			}
			File.WriteAllText(pathFileSetting, json.ToString());
		}
		catch
		{
		}
	}

	public string GetFullString()
	{
		string result = "";
		try
		{
			result = json.ToString().Replace("\r\n", "");
		}
		catch (Exception)
		{
		}
		return result;
	}

	public List<string> GetAllFieldNames()
	{
		List<string> fieldNames = new List<string>();
		foreach (var property in json.Properties())
		{
			fieldNames.Add(GetValue(property.Name));
		}
		return fieldNames;
	}

	public string GetKeyByValueFromJson(string targetValue)
	{
		try
		{
			// Duyệt qua tất cả các trường trong đối tượng JSON
			foreach (var property in json.Properties())
			{
				if (property.Value != null && property.Value.ToString() == targetValue)
				{
					// Nếu giá trị của trường trùng khớp với giá trị cần tìm, trả về tên trường
					return property.Name;
				}
			}

			// Trường không tồn tại hoặc không tìm thấy giá trị, trả về null
			return null;
		}
		catch
		{

			return null;
		}
	}
}
