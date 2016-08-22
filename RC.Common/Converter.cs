using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RC.Common
{
	public static class Converter
	{
		public delegate object ConvertValue(object objValue);

		public static object Through(object value)
		{
			return value;
		}

		public static object StringToSlashedYYYYMMDDString(object date)
		{
			string text = null;
			if (date != null)
			{
				text = Tools.AnyToString(date);
				Regex regex = new Regex("^[0-9]{8}$");
				if (regex.IsMatch(text))
				{
					text = text.Insert(4, "/").Insert(7, "/");
				}
			}
			return text;
		}

		public static object StringToSlashedMMDDString(object date)
		{
			string text = null;
			if (date != null)
			{
				text = Tools.Format(Tools.AnyToInt(date), "0000");
				Regex regex = new Regex("^[0-9]{4}$");
				if (regex.IsMatch(text))
				{
					text = text.Insert(2, "/");
				}
			}
			return text;
		}

		public static object StringToSlashedYYYYMMString(object date)
		{
			string text = null;
			if (date != null)
			{
				text = Tools.AnyToString(date);
				Regex regex = new Regex("^[0-9]{6}$");
				if (regex.IsMatch(text))
				{
					text = text.Insert(4, "/");
				}
			}
			return text;
		}

		public static object StringToRemoveSlashString(object date)
		{
			string result = null;
			if (date != null)
			{
				result = Tools.AnyToString(date).Replace("/", "");
			}
			return result;
		}

		public static object DBNullToNull(object inputValue)
		{
			object result = inputValue;
			if (inputValue is DBNull)
			{
				result = null;
			}
			return result;
		}

		public static object NullToDBNull(object inputValue)
		{
			object result = inputValue;
			if (inputValue == null)
			{
				result = DBNull.Value;
			}
			else if (inputValue.ToString() == string.Empty)
			{
				result = DBNull.Value;
			}
			return result;
		}

		public static object BooleanToString(object boolean)
		{
			if (!(boolean is bool) || !(bool)boolean)
			{
				return "0";
			}
			return "1";
		}

		public static object DateTimeToString(object date)
		{
			string result = null;
			if (date != null && date is DateTime)
			{
				result = ((DateTime)date).ToString("yyyy/MM/dd");
			}
			return result;
		}

		public static object YYYYMMStringToInt(object p_date)
		{
			string text = Tools.AnyToString(p_date);
			if (text.Length < 8)
			{
				if (text.IndexOf("/") != 4)
				{
					text = text.Insert(4, "/");
				}
				text += "/01";
			}
			text = (Converter.StringToSlashedYYYYMMString(text) as string);
			int num = int.Parse(DateTime.Parse(text).ToString("yyyyMM"));
			return num;
		}

		public static object MMDDStringToInt(object p_date)
		{
			string text = Tools.AnyToString(p_date);
			text = Tools.FormatDate(DateTime.Now.ToString(), "yyyy", false) + "/" + text;
			int num = int.Parse(DateTime.Parse(text).ToString("MMdd"));
			return num;
		}

		public static object ConvertPostCode(object PostCode)
		{
			string text = null;
			if (PostCode != null)
			{
				text = Tools.AnyToString(PostCode);
				string text2 = text.Replace("-", "");
				if (text2.Length == 7)
				{
					text = text2.Substring(0, 3) + "-" + text2.Substring(3, 4);
				}
			}
			return text;
		}

		public static object StringToYYYYMMString(object p_objDate)
		{
			if (Tools.AnyToString(p_objDate) == string.Empty)
			{
				return p_objDate;
			}
			string result;
			if (Check.IsConvertableStringToYYYMMString(Tools.AnyToString(p_objDate), out result))
			{
				return result;
			}
			return p_objDate;
		}

		public static object StringToYYYYMMDDString(object p_Date)
		{
			string text = Tools.AnyToString(p_Date);
			string result = "00000000";
			int num = 0;
			string text2;
			if (text.IndexOf("/") > 0 || text.StartsWith("/"))
			{
				text2 = "";
				for (int i = 0; i < text.Length; i++)
				{
					if (text.Substring(i, 1) != "/")
					{
						text2 += text.Substring(i, 1);
					}
					else
					{
						num++;
					}
				}
			}
			else if (text.Length > 8)
			{
				text2 = text.Substring(text.Length - 8, 8);
			}
			else
			{
				text2 = text;
			}
			if (!Check.IsInt(text2))
			{
				return result;
			}
			if (Tools.AnyToInt(text2) == 0)
			{
				return result;
			}
			if (num > 2)
			{
				return result;
			}
			string o = Tools.Format(Tools.AnyToInt(text2), "0");
			switch (num)
			{
			case 0:
				switch (text2.Length)
				{
				case 1:
				case 2:
					return Tools.FormatDate(DateTime.Now.ToString(), "yyyyMM", false) + Tools.Format(Tools.AnyToInt(o), "00");
				case 3:
				case 4:
					return Tools.FormatDate(DateTime.Now.ToString(), "yyyy", false) + Tools.Format(Tools.AnyToInt(o), "0000");
				case 5:
				case 6:
					return Tools.FormatDate(DateTime.Now.ToString(), "yyyy", false).Substring(0, 2) + Tools.Format(Tools.AnyToInt(o), "000000");
				case 7:
				case 8:
					return Tools.Format(Tools.AnyToInt(o), "00000000");
				}
				break;
			case 1:
			{
				int i = text.IndexOf("/");
				if (text.Substring(0, i).Length <= 2 && text.Substring(i + 1).Length <= 2)
				{
					return Tools.FormatDate(DateTime.Now.ToString(), "yyyy", false) + Tools.Format(Tools.AnyToInt(text.Substring(0, i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(i + 1)), "00");
				}
				break;
			}
			case 2:
			{
				int i = text.IndexOf("/");
				int num2 = text.IndexOf("/", i + 1);
				if (text.Substring(0, i).Length <= 4 && text.Substring(i + 1, num2 - 1 - i).Length <= 2 && text.Substring(num2 + 1).Length <= 2)
				{
					if (text.Substring(0, i).Length <= 2)
					{
						return Tools.FormatDate(DateTime.Now.ToString(), "yyyy", false).Substring(0, 2) + Tools.Format(Tools.AnyToInt(text.Substring(0, i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(i + 1, num2 - 1 - i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(num2 + 1)), "00");
					}
					return Tools.Format(Tools.AnyToInt(text.Substring(0, i)), "0000") + Tools.Format(Tools.AnyToInt(text.Substring(i + 1, num2 - 1 - i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(num2 + 1)), "00");
				}
				break;
			}
			}
			return result;
		}

		public static object StringToHHMMSSString(object p_Time)
		{
			string text = Tools.AnyToString(p_Time);
			string result = "000000";
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
			}
			else if (text.Length > 6)
			{
				text2 = text.Substring(text.Length - 6, 6);
			}
			else
			{
				text2 = text;
			}
			if (!Check.IsInt(text2))
			{
				return result;
			}
			if (num > 2)
			{
				return result;
			}
			Tools.Format(Tools.AnyToInt(text2), "0");
			switch (num)
			{
			case 0:
				return Tools.Format(Tools.AnyToInt(text2), "000000");
			case 1:
			{
				int i = text.IndexOf(":");
				if (text.Substring(0, i).Length <= 2 && text.Substring(i + 1).Length <= 2)
				{
					return Tools.Format(Tools.AnyToInt(text.Substring(0, i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(i + 1)), "00") + "00";
				}
				break;
			}
			case 2:
			{
				int i = text.IndexOf(":");
				int num2 = text.IndexOf(":", i + 1);
				if (text.Substring(0, i).Length <= 2 && text.Substring(i + 1, num2 - 1 - i).Length <= 2 && text.Substring(num2 + 1).Length <= 2)
				{
					return Tools.Format(Tools.AnyToInt(text.Substring(0, i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(i + 1, num2 - 1 - i)), "00") + Tools.Format(Tools.AnyToInt(text.Substring(num2 + 1)), "00");
				}
				break;
			}
			}
			return result;
		}

		public static object DateTimeToJapaneseEraDateString(object date)
		{
			if (date == null || !(date is DateTime))
			{
				return null;
			}
			CultureInfo cultureInfo = new CultureInfo("ja-JP");
			JapaneseCalendar calendar = new JapaneseCalendar();
			cultureInfo.DateTimeFormat.Calendar = calendar;
			string text = ((DateTime)date).ToString("y.M.d", cultureInfo);
			switch (cultureInfo.DateTimeFormat.Calendar.GetEra((DateTime)date))
			{
			case 1:
				text = "M" + text;
				break;
			case 2:
				text = "T" + text;
				break;
			case 3:
				text = "S" + text;
				break;
			case 4:
				text = "H" + text;
				break;
			}
			return text;
		}

		public static object StringToJapaneseEraDateString(object p_objDate)
		{
			if (Tools.AnyToString(p_objDate) == string.Empty)
			{
				return p_objDate;
			}
			CultureInfo cultureInfo = new CultureInfo("ja-JP");
			JapaneseCalendar calendar = new JapaneseCalendar();
			cultureInfo.DateTimeFormat.Calendar = calendar;
			return DateTime.Parse((string)p_objDate, cultureInfo);
		}

		public static object DateTimeToJapaneseEraDateString(object date, string format)
		{
			if (date == null || !(date is DateTime))
			{
				return null;
			}
			CultureInfo cultureInfo = new CultureInfo("ja-JP");
			JapaneseCalendar calendar = new JapaneseCalendar();
			cultureInfo.DateTimeFormat.Calendar = calendar;
			return ((DateTime)date).ToString(format, cultureInfo);
		}

		[Obsolete]
		public static string ConvertToValidDay(string date)
		{
			Regex regex = new Regex("^(\\d{4})/((0[1-9])|(1[0-2]))/(\\d{2})$");
			Match match = regex.Match(date);
			if (!match.Success)
			{
				throw new FormatException(string.Format("年月部分の書式が間違っています。{0}", date));
			}
			int year = int.Parse(match.Groups[1].Value);
			int month = int.Parse(match.Groups[2].Value);
			int.Parse(match.Groups[5].Value);
			DateTime.DaysInMonth(year, month);
			return date;
		}

		[Obsolete]
		public static IDictionary DataRowToDictionary(DataRow dataRow)
		{
			Hashtable hashtable = new Hashtable();
			foreach (DataColumn dataColumn in dataRow.Table.Columns)
			{
				if (dataRow[dataColumn.ColumnName] != DBNull.Value)
				{
					hashtable[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
				}
				else
				{
					hashtable[dataColumn.ColumnName] = DBNull.Value;
				}
			}
			return hashtable;
		}
	}
}
