using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace RC.Common
{
	public static class Check
	{
		public static bool IsEmptyString(object o)
		{
            return o == null || string.IsNullOrEmpty(o.ToString());
		}

		public static bool IsInt(object o)
		{
            int num;
            return o != null && int.TryParse(o.ToString(), out num);
		}

		public static bool IsDecimal(object o)
		{
            decimal num;
            return o != null && decimal.TryParse(o.ToString(), out num);
        }

		public static bool IsDouble(object o)
		{
            double num;
            return o!= null && double.TryParse(o.ToString(), out num);
        }

		public static bool IsDateTime(object o)
		{
			DateTime dateTime;
			return o != null && DateTime.TryParse(o.ToString(), out dateTime);
		}

		public static bool IsMonth(object input)
		{
            int result = Tools.AnyToInt(input);

            if (result >= 1 && result <= 12)
                return true;
            else
                return false;
		}

		public static bool IsHour(object input)
		{
            int result = Tools.AnyToInt(input);

            if (result >= 0 && result <= 23)
                return true;
            else
                return false;
        }

		public static bool IsMinute(object Hour, object Minute)
		{
			bool result;
			try
			{
				if (Tools.AnyToInt(Hour) != 24 && Convert.ToInt32(Minute) >= 0 && Convert.ToInt32(Minute) <= 59)
				{
					result = true;
				}
				else if (Tools.AnyToInt(Hour) == 24 && Convert.ToInt32(Minute) == 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public static bool IsValidDataSet(DataSet ds)
		{
			return ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0;
		}

		public static bool IsValidDataTable(DataTable dt)
		{
			return dt != null && dt.Rows.Count != 0;
		}

		public static bool IsValidDataReader(SqlDataReader dr)
		{
			return dr != null && dr.HasRows;
		}

		public static bool IsRegularlyRange(object start, object end, Type checkType)
		{
			try
			{
				if (checkType == typeof(DateTime))
				{
					if (Tools.AnyToDateTime(start) < Tools.AnyToDateTime(end))
					{
						bool result = true;
						return result;
					}
				}
				else if (checkType == typeof(short) || checkType == typeof(int))
				{
					if (Tools.AnyToInt(start) < Tools.AnyToInt(end))
					{
						bool result = true;
						return result;
					}
				}
				else if (checkType == typeof(long))
				{
					if (Tools.AnyToLong(start) < Tools.AnyToLong(end))
					{
						bool result = true;
						return result;
					}
				}
				else if (checkType == typeof(decimal))
				{
					if (Tools.AnyToDecimal(start) < Tools.AnyToDecimal(end))
					{
						bool result = true;
						return result;
					}
				}
				else if (checkType == typeof(double))
				{
					if (Tools.AnyToDouble(start) < Tools.AnyToDouble(end))
					{
						bool result = true;
						return result;
					}
				}
				else if (checkType == typeof(string) && string.Compare(Tools.AnyToString(start), Tools.AnyToString(end)) < 0)
				{
					bool result = true;
					return result;
				}
			}
			catch
			{
				bool result = false;
				return result;
			}
			return true;
		}

		public static bool IsDateString(object date)
		{
			string date2 = Tools.AnyToString(date);
			return Check.IsDateString(date2);
		}

		public static bool IsDateString(string date)
		{
			try
			{
				Regex regex = new Regex("^[0-9]{4}/?([0-9]|[0-9][0-9])/?([0-9]|[0-9][0-9])$");
				bool result;
				if (!regex.IsMatch(date, 0))
				{
					result = false;
					return result;
				}
				if (date.Length < 8)
				{
					result = false;
					return result;
				}
				regex = new Regex("^[0-9]{8}$");
				if (regex.IsMatch(date, 0))
				{
					date = date.Insert(4, "/").Insert(7, "/");
				}
				DateTime dateTime;
				if (DateTime.TryParse(date, out dateTime))
				{
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (FormatException)
			{
			}
			return false;
		}

		public static bool IsYearMonthString(string date)
		{
			try
			{
				Regex regex = new Regex("^[0-9]{4}/?([0-9]|[0-9][0-9])$");
				bool result;
				if (!regex.IsMatch(date, 0))
				{
					result = false;
					return result;
				}
				if (date.Length == 6)
				{
					date = date.Insert(4, "/") + "/01";
				}
				else
				{
					date += "/01";
				}
				DateTime dateTime;
				if (DateTime.TryParse(date, out dateTime))
				{
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (FormatException)
			{
			}
			return false;
		}

		public static bool IsYearMonthString(object date)
		{
			string date2 = Tools.AnyToString(date);
			return Check.IsYearMonthString(date2);
		}

		public static bool IsYearString(string date)
		{
			try
			{
				Regex regex = new Regex("^[0-9]{4}$");
				if (regex.IsMatch(date, 0))
				{
					bool result;
					if (date == "0000")
					{
						result = false;
						return result;
					}
					DateTime dateTime;
					if (DateTime.TryParse(date + "/01/01", out dateTime))
					{
						result = true;
						return result;
					}
					result = false;
					return result;
				}
			}
			catch (FormatException)
			{
			}
			return false;
		}

		public static bool IsYearString(object date)
		{
			Tools.AnyToString(date);
			return Check.IsYearString(date);
		}

		public static bool IsSingleByteCharsOnly(string str)
		{
			return str.Length == Tools.LengthB(str);
		}

		public static bool IsConvertableStringToMMDDString(string p_date)
		{
			string text;
			return Check.IsConvertableStringToMMDDString(p_date, out text);
		}

		public static bool IsConvertableStringToMMDDString(string p_date, out string po_stringMD)
		{
			string text = (string)Converter.StringToYYYYMMDDString(p_date);
			string text2 = string.Concat(new string[]
			{
				text.Substring(0, 4),
				"/",
				text.Substring(4, 2),
				"/",
				text.Substring(6, 2)
			});
			if (Tools.AnyToInt(text2.Substring(0, 4)) < 1900 || Tools.AnyToInt(text2.Substring(0, 4)) > 2100)
			{
				po_stringMD = p_date;
				return false;
			}
			if (!Check.IsDateTime(text2))
			{
				po_stringMD = p_date;
				return false;
			}
			po_stringMD = text2.Substring(5);
			return true;
		}

		public static bool IsConvertableStringToYYYYMMDDString(string p_date)
		{
			string text;
			return Check.IsConvertableStringToYYYYMMDDString(p_date, out text);
		}

		public static bool IsConvertableStringToYYYYMMDDString(string p_date, out string po_stringYMD)
		{
			string text = (string)Converter.StringToYYYYMMDDString(p_date);
			string text2 = string.Concat(new string[]
			{
				text.Substring(0, 4),
				"/",
				text.Substring(4, 2),
				"/",
				text.Substring(6, 2)
			});
			if (Tools.AnyToInt(text2.Substring(0, 4)) < 1900 || Tools.AnyToInt(text2.Substring(0, 4)) > 2100)
			{
				po_stringYMD = p_date;
				return false;
			}
			if (!Check.IsDateTime(text2))
			{
				po_stringYMD = p_date;
				return false;
			}
			po_stringYMD = text2;
			return true;
		}

		public static bool IsConvertableStringToYYYMMString(string p_date)
		{
			string text;
			return Check.IsConvertableStringToYYYMMString(p_date, out text);
		}

		public static bool IsConvertableStringToYYYMMString(string p_date, out string po_stringYM)
		{
			int num = 0;
			string text;
			if (p_date.IndexOf("/") > 0 || p_date.StartsWith("/"))
			{
				text = "";
				for (int i = 0; i < p_date.Length; i++)
				{
					if (p_date.Substring(i, 1) != "/")
					{
						text += p_date.Substring(i, 1);
					}
					else
					{
						num++;
					}
				}
				if (num > 1)
				{
					po_stringYM = p_date;
					return false;
				}
				text = text.Substring(0, p_date.IndexOf("/")) + p_date.Substring(p_date.IndexOf("/") + 1, p_date.Length - 1 - p_date.IndexOf("/")).PadLeft(2, '0');
			}
			else if (p_date.Length > 6)
			{
				text = p_date.Substring(p_date.Length - 6, 6);
			}
			else
			{
				text = p_date;
			}
			text += "01";
			string text2;
			if (!Check.IsConvertableStringToYYYYMMDDString(text, out text2))
			{
				po_stringYM = p_date;
				return false;
			}
			po_stringYM = text2.Substring(0, 7);
			return true;
		}

		public static bool IsConvertableStringToYYYYString(string p_date)
		{
			string text;
			return Check.IsConvertableStringToYYYYString(p_date, out text);
		}

		public static bool IsConvertableStringToYYYYString(string p_date, out string po_stringY)
		{
			if (p_date.IndexOf("/") > 0 || p_date.StartsWith("/"))
			{
				po_stringY = p_date;
				return false;
			}
			string text;
			if (p_date.Length > 4)
			{
				text = p_date.Substring(p_date.Length - 4, 4);
			}
			else
			{
				text = p_date;
				if (Tools.AnyToInt(text) >= 2100)
				{
					po_stringY = p_date;
					return false;
				}
				if (Tools.AnyToInt(text) < 1000)
				{
					if (Tools.AnyToInt(text) >= 80)
					{
						text = (Tools.AnyToInt(text) + 1900).ToString();
					}
					else
					{
						text = (Tools.AnyToInt(text) + 2000).ToString();
					}
				}
			}
			text += "0101";
			string text2;
			if (!Check.IsConvertableStringToYYYYMMDDString(text, out text2))
			{
				po_stringY = p_date;
				return false;
			}
			po_stringY = text2.Substring(0, 4);
			return true;
		}

		public static bool IsConvertableStringToHHMMSSString(string p_time)
		{
			string text;
			return Check.IsConvertableStringToHHMMSSString(p_time, out text);
		}

		public static bool IsConvertableStringToHHMMSSString(string p_time, out string po_stringHMS)
		{
			string text = (string)Converter.StringToHHMMSSString(p_time);
			string text2 = string.Concat(new string[]
			{
				text.Substring(0, 2),
				":",
				text.Substring(2, 2),
				":",
				text.Substring(4, 2)
			});
			if (Tools.AnyToInt(text2.Substring(0, 2)) < 0)
			{
				po_stringHMS = p_time;
				return false;
			}
			if (Tools.AnyToInt(text2.Substring(2, 2)) < 0 || Tools.AnyToInt(text2.Substring(2, 2)) > 59)
			{
				po_stringHMS = p_time;
				return false;
			}
			if (Tools.AnyToInt(text2.Substring(4, 2)) < 0 || Tools.AnyToInt(text2.Substring(4, 2)) > 59)
			{
				po_stringHMS = p_time;
				return false;
			}
			po_stringHMS = text2;
			return true;
		}

		public static bool IsConvertableStringToHHMMString(string p_time)
		{
			string text;
			return Check.IsConvertableStringToHHMMString(p_time, out text);
		}

		public static bool IsConvertableStringToHHMMString(string p_time, out string po_stringHM)
		{
			string text = Tools.AnyToString(p_time);
			int num = 0;
			text = text.Replace(".", ":");
			string text2;
			if (text.IndexOf(":") > 0 || text.StartsWith(":"))
			{
				text2 = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text.Substring(i, 1) != ":")
					{
						text2 += text.Substring(i, 1);
					}
					else
					{
						num++;
					}
				}
				if (num > 1)
				{
					po_stringHM = text;
					return false;
				}
				text2 = text2.Substring(0, text.IndexOf(":")) + text.Substring(text.IndexOf(":") + 1, text.Length - 1 - text.IndexOf(":")).PadLeft(2, '0');
			}
			else if (text.Length > 4)
			{
				text2 = text.Substring(text.Length - 4, 4);
			}
			else
			{
				text2 = text;
			}
			text2 += "00";
			string text3;
			if (!Check.IsConvertableStringToHHMMSSString(text2, out text3))
			{
				po_stringHM = text;
				return false;
			}
			po_stringHM = text3.Substring(0, 5);
			return true;
		}

		public static bool IsConvertableStringToHHString(string p_time)
		{
			string text;
			return Check.IsConvertableStringToHHString(p_time, out text);
		}

		public static bool IsConvertableStringToHHString(string p_time, out string po_stringH)
		{
			string text = Tools.AnyToString(p_time);
			text = text.Replace(".", ":");
			if (text.IndexOf(":") > 0 || text.StartsWith(":"))
			{
				po_stringH = text;
				return false;
			}
			string text2;
			if (text.Length > 2)
			{
				text2 = text.Substring(text.Length - 2, 2);
			}
			else
			{
				text2 = text.PadLeft(2, '0');
			}
			text2 += "0000";
			string text3;
			if (!Check.IsConvertableStringToHHMMSSString(text2, out text3))
			{
				po_stringH = text;
				return false;
			}
			po_stringH = text3.Substring(0, 2);
			return true;
		}

		public static bool IsConvertableStringToYYYYMMDDHHMMSSString(string p_date)
		{
			string text;
			return Check.IsConvertableStringToYYYYMMDDHHMMSSString(p_date, out text);
		}

		public static bool IsConvertableStringToYYYYMMDDHHMMSSString(string p_date, out string po_stringYMD)
		{
			string text = Tools.AnyToString(p_date);
			string[] array = new string[6];
			int num = 0;
			text = text.Replace(".", ":");
			for (int i = 0; i < text.Length; i++)
			{
				if (text.Substring(i, 1) == "/" || text.Substring(i, 1) == ":" || text.Substring(i, 1) == " ")
				{
					num++;
				}
			}
			if (num > 5)
			{
				po_stringYMD = p_date;
				return false;
			}
			string p_date2;
			string p_time;
			if (num != 0)
			{
				string text2 = "";
				string text3 = "";
				int startIndex = 0;
				int j = 0;
				int num2 = 0;
				for (int i = 0; i < text.Length; i++)
				{
					if (text.Substring(i, 1) == "/" || text.Substring(i, 1) == ":" || text.Substring(i, 1) == " ")
					{
						array[j] = text.Substring(startIndex, num2);
						array[j] = array[j].PadLeft(2, '0');
						j++;
						startIndex = i + 1;
						num2 = 0;
						if (j == 5)
						{
							array[j] = text.Substring(startIndex);
							array[j] = array[j].PadLeft(2, '0');
						}
					}
					else
					{
						num2++;
					}
				}
				if (j < 5)
				{
					array[j] = text.Substring(startIndex);
					array[j] = array[j].PadLeft(2, '0');
					j++;
					for (int k = j; k < 6; k++)
					{
						array[j] = "00";
					}
				}
				for (j = 0; j < 6; j++)
				{
					switch (j)
					{
					case 0:
					case 1:
					case 2:
						text2 += array[j];
						break;
					case 3:
					case 4:
					case 5:
						text3 += array[j];
						break;
					}
				}
				p_date2 = (string)Converter.StringToYYYYMMDDString(text2);
				p_time = (string)Converter.StringToHHMMSSString(text3);
			}
			else
			{
				text = text.Replace(" ", "");
				p_date2 = text.Substring(0, 8);
				p_time = text.Substring(8);
			}
			string str;
			if (!Check.IsConvertableStringToYYYYMMDDString(p_date2, out str))
			{
				po_stringYMD = p_date;
				return false;
			}
			string str2;
			if (!Check.IsConvertableStringToHHMMSSString(p_time, out str2))
			{
				po_stringYMD = p_date;
				return false;
			}
			po_stringYMD = str + " " + str2;
			return true;
		}

		public static bool IsConvertableStringToYYYYMMDDHHMMString(string p_date)
		{
			string text;
			return Check.IsConvertableStringToYYYYMMDDHHMMString(p_date, out text);
		}

		public static bool IsConvertableStringToYYYYMMDDHHMMString(string p_date, out string po_stringYMD)
		{
			string text = Tools.AnyToString(p_date);
			string[] array = new string[5];
			int num = 0;
			text = text.Replace(".", ":");
			for (int i = 0; i < text.Length; i++)
			{
				if (text.Substring(i, 1) == "/" || text.Substring(i, 1) == ":" || text.Substring(i, 1) == " ")
				{
					num++;
				}
			}
			if (num > 4)
			{
				po_stringYMD = p_date;
				return false;
			}
			string p_date2;
			string p_time;
			if (num != 0)
			{
				string text2 = "";
				string text3 = "";
				int startIndex = 0;
				int j = 0;
				int num2 = 0;
				for (int i = 0; i < text.Length; i++)
				{
					if (text.Substring(i, 1) == "/" || text.Substring(i, 1) == ":" || text.Substring(i, 1) == " ")
					{
						array[j] = text.Substring(startIndex, num2);
						array[j] = array[j].PadLeft(2, '0');
						j++;
						startIndex = i + 1;
						num2 = 0;
						if (j == 4)
						{
							array[j] = text.Substring(startIndex);
							array[j] = array[j].PadLeft(2, '0');
						}
					}
					else
					{
						num2++;
					}
				}
				if (j < 4)
				{
					array[j] = text.Substring(startIndex);
					array[j] = array[j].PadLeft(2, '0');
					j++;
					for (int k = j; k < 6; k++)
					{
						array[j] = "00";
					}
				}
				for (j = 0; j < 6; j++)
				{
					switch (j)
					{
					case 0:
					case 1:
					case 2:
						text2 += array[j];
						break;
					case 3:
					case 4:
						text3 += array[j];
						break;
					case 5:
						text3 += "00";
						break;
					}
				}
				p_date2 = (string)Converter.StringToYYYYMMDDString(text2);
				p_time = (string)Converter.StringToHHMMSSString(text3);
			}
			else
			{
				text = text.Replace(" ", "");
				p_date2 = text.Substring(0, 8);
				p_time = text.Substring(8, 4) + "00";
			}
			string str;
			if (!Check.IsConvertableStringToYYYYMMDDString(p_date2, out str))
			{
				po_stringYMD = p_date;
				return false;
			}
			string text4;
			if (!Check.IsConvertableStringToHHMMSSString(p_time, out text4))
			{
				po_stringYMD = p_date;
				return false;
			}
			po_stringYMD = str + " " + text4.Substring(0, 5);
			return true;
		}
	}
}
