using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace RC.Common
{
	public static class Tools
	{
		public static int AnyToInt(object o)
		{
			if (o == null)
			{
				return 0;
			}
			int result;
			try
			{
				int num;
				if (!int.TryParse(o.ToString(), out num))
				{
					result = 0;
				}
				else
				{
					result = int.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public static short AnyToShort(object o)
		{
			if (o == null)
			{
				return 0;
			}
			short result;
			try
			{
				short num;
				if (!short.TryParse(o.ToString(), out num))
				{
					result = 0;
				}
				else
				{
					result = short.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public static long AnyToLong(object o)
		{
			if (o == null)
			{
				return 0L;
			}
			long result;
			try
			{
				long num;
				if (!long.TryParse(o.ToString(), out num))
				{
					result = 0L;
				}
				else
				{
					result = long.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0L;
			}
			return result;
		}

		public static decimal AnyToDecimal(object o)
		{
			if (o == null)
			{
				return 0.0m;
			}
			decimal result;
			try
			{
				decimal num;
				if (!decimal.TryParse(o.ToString(), out num))
				{
					result = 0.0m;
				}
				else
				{
					result = decimal.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0.0m;
			}
			return result;
		}

		public static float AnyToFloat(object o)
		{
			if (o == null)
			{
				return 0f;
			}
			float result;
			try
			{
				float num;
				if (!float.TryParse(o.ToString(), out num))
				{
					result = 0f;
				}
				else
				{
					result = float.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0f;
			}
			return result;
		}

		public static double AnyToDouble(object o)
		{
			if (o == null)
			{
				return 0.0;
			}
			double result;
			try
			{
				double num;
				if (!double.TryParse(o.ToString(), out num))
				{
					result = 0.0;
				}
				else
				{
					result = double.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0.0;
			}
			return result;
		}

		public static byte AnyToByte(object o)
		{
			if (o == null)
			{
				return 0;
			}
			byte result;
			try
			{
				byte b;
				if (!byte.TryParse(o.ToString(), out b))
				{
					result = 0;
				}
				else
				{
					result = byte.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public static bool AnyToBool(object o)
		{
			if (o == null)
			{
				return false;
			}
			bool result;
			try
			{
				if (Tools.AnyToString(o).ToLower() == "true")
				{
					result = true;
				}
				else if (Tools.AnyToInt(o) != 0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public static DateTime AnyToDateTime(object o)
		{
			return Tools.AnyToDateTime(o, new DateTime(1900, 1, 1));
		}

		public static DateTime AnyToDateTime(object o, DateTime defaultValue)
		{
			DateTime result;
			try
			{
				DateTime dateTime;
				if (!DateTime.TryParse(o.ToString(), out dateTime))
				{
					result = defaultValue;
				}
				else
				{
					result = DateTime.Parse(o.ToString());
				}
			}
			catch (Exception)
			{
				result = defaultValue;
			}
			return result;
		}

		public static string AnyToString(object o)
		{
			if (o == null)
			{
				return "";
			}
			return o.ToString();
		}

		public static Color AnyToColor(object o)
		{
			string text = Tools.AnyToString(o);
			Color result;
			try
			{
				if (Tools.LeftB(text, 1) == "#")
				{
					result = ColorTranslator.FromHtml(text);
				}
				else if (!Check.IsInt(text))
				{
					result = Color.FromName(text);
				}
				else
				{
					result = Color.FromArgb(Tools.AnyToInt(text));
				}
			}
			catch (Exception)
			{
				result = Color.Black;
			}
			return result;
		}

		public static string ToSQLLiteral(object o)
		{
			if (Check.IsEmptyString(o))
			{
				return "null";
			}
			return "'" + o.ToString().Replace("'", "''") + "'";
		}

		public static string ToSQLDateTime(object o)
		{
			if (!Check.IsDateTime(o))
			{
				return "null";
			}
			DateTime dateTime = Tools.AnyToDateTime(o);
			if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0 && dateTime.Millisecond == 0)
			{
				return "'" + dateTime.ToString("yyyy/MM/dd") + "'";
			}
			if (dateTime.Millisecond != 0)
			{
				return "'" + dateTime.ToString("yyyy/MM/dd HH:mm:ss") + "'";
			}
			return "'" + dateTime.ToString("yyyy/MM/dd HH:mm:ss.fff") + "'";
		}

		public static string ToSQLNumeric(object o)
		{
			if (Check.IsEmptyString(o))
			{
				return "null";
			}
			return o.ToString();
		}

		public static string ToSQLNumericNotNull(object o)
		{
			if (Check.IsEmptyString(o))
			{
				return "0";
			}
			return o.ToString();
		}

		public static string ByteArrayToString(byte[] array)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (array == null)
			{
				return "";
			}
			byte? b = null;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] >= 128)
				{
					byte? b2 = b;
					if ((b2.HasValue ? new int?((int)b2.GetValueOrDefault()) : null).HasValue)
					{
						stringBuilder.Append((char)((int)b << 256 + array[i]));
						b = null;
					}
					else
					{
						b = new byte?(array[i]);
					}
				}
				else
				{
					stringBuilder.Append((char)array[i]);
				}
			}
			return stringBuilder.ToString();
		}

		public static string Format(int value, string format)
		{
			return value.ToString(format);
		}

		public static string ToFormatCurrency(object o)
		{
			return Tools.AnyToDouble(o).ToString("#,##0;-#,##0");
		}

		public static string ToFormatDecimal(int decimals)
		{
			string result;
			if (decimals <= 0)
			{
				result = "#,##0";
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < decimals; i++)
				{
					stringBuilder.Append("0");
				}
				result = "#,##0." + stringBuilder.ToString();
			}
			return result;
		}

		public static string FormatDate(string source)
		{
			return Tools.FormatDate(source, "yyyy/MM/dd", false);
		}

		public static string FormatDate(string source, bool IsThrowException)
		{
			return Tools.FormatDate(source, "yyyy/MM/dd", IsThrowException);
		}

		public static string FormatDate(string source, string format, bool IsThrowException)
		{
			string text = source.Trim();
			if (text == "")
			{
				return "";
			}
			if (Check.IsDateTime(text))
			{
				return Convert.ToDateTime(text).ToString(format);
			}
			Regex regex = new Regex("^[0-9]{6}$");
			if (regex.IsMatch(text, 0))
			{
				text = text.Insert(2, "/").Insert(5, "/");
				if (Check.IsDateTime(text))
				{
					return Convert.ToDateTime(text).ToString(format);
				}
			}
			regex = new Regex("^[0-9]{8}$");
			if (regex.IsMatch(text, 0))
			{
				text = text.Insert(4, "/").Insert(7, "/");
				if (Check.IsDateTime(text))
				{
					return Convert.ToDateTime(text).ToString(format);
				}
			}
			if (IsThrowException)
			{
				throw new Exception("日付として認識出来ません。");
			}
			return source;
		}

		public static int LengthB(string source)
		{
			int result;
			try
			{
				Encoding encoding = Encoding.GetEncoding("shift-jis");
				result = encoding.GetByteCount(source);
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		private static string _implSubstringB(string source, int startIndex, int length)
		{
			string result;
			try
			{
				Encoding encoding = Encoding.GetEncoding("shift-jis");
				if (source == null || startIndex < 0 || length < 0)
				{
					result = "";
				}
				else
				{
					if (encoding.GetByteCount(source) < startIndex)
					{
						throw new ArgumentOutOfRangeException("startIndex");
					}
					if (encoding.GetByteCount(source) < length + startIndex)
					{
						throw new ArgumentOutOfRangeException("length");
					}
					string text = encoding.GetString(encoding.GetBytes(source), startIndex, length);
					int length2 = text.Length;
					int startIndex2;
					if (startIndex != 0)
					{
						string @string = encoding.GetString(encoding.GetBytes(source), 0, startIndex);
						if (@string.CompareTo(source.Substring(0, @string.Length)) == 0)
						{
							startIndex2 = @string.Length;
						}
						else
						{
							startIndex2 = @string.Length - 1;
						}
					}
					else
					{
						startIndex2 = 0;
					}
					string text2 = source.Substring(startIndex2, length2);
					if (text.CompareTo(text2) == 0)
					{
						result = text;
					}
					else
					{
						char[] array = text.ToCharArray();
						char[] array2 = text2.ToCharArray();
						StringBuilder stringBuilder = new StringBuilder();
						if (array[0].CompareTo(array2[0]) != 0)
						{
							array[0] = ' ';
						}
						if (array[array2.Length - 1].CompareTo(array2[array2.Length - 1]) != 0)
						{
							array[array2.Length - 1] = ' ';
						}
						text = stringBuilder.Append(array).ToString();
						result = text;
					}
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}

		public static string SubstringB(string source, int startIndex, int length)
		{
			if (length + startIndex > Tools.LengthB(source))
			{
				length = Tools.LengthB(source) - startIndex;
			}
			return Tools._implSubstringB(source, startIndex, length);
		}

		public static string LeftB(string source, int length)
		{
			return Tools.SubstringB(source, 0, length);
		}

		public static string RightB(string source, int length)
		{
			int num = Tools.LengthB(source);
			int num2 = num - length;
			if (num2 < 0)
			{
				num2 = 0;
			}
			return Tools.SubstringB(source, num2, length);
		}

		public static double ComputeRound(double d, int unit)
		{
			double num = 0.0;
			if (unit < 1 || unit > 4)
			{
				return d;
			}
			double result;
			try
			{
				int num2 = Math.Sign(d);
				double num3 = Math.Abs(d);
				switch (unit)
				{
				case 1:
					num = num3;
					break;
				case 2:
					num = num3 * 10.0;
					break;
				case 3:
					num = num3 * 100.0;
					break;
				case 4:
					num = num3 * 1000.0;
					break;
				}
				double num4 = Math.Floor(num + 0.500000001);
				switch (unit)
				{
				case 2:
					num4 /= 10.0;
					break;
				case 3:
					num4 /= 100.0;
					break;
				case 4:
					num4 /= 1000.0;
					break;
				}
				double num5 = num4 * (double)num2;
				result = num5;
			}
			catch
			{
				result = d;
			}
			return result;
		}

		public static double ComputeRoundUp(double d, int unit)
		{
			double a = 0.0;
			if (unit < 1 || unit > 4)
			{
				return d;
			}
			double result;
			try
			{
				int num = Math.Sign(d);
				double num2 = Math.Abs(d);
				switch (unit)
				{
				case 1:
					a = num2;
					break;
				case 2:
					a = num2 * 10.0;
					break;
				case 3:
					a = num2 * 100.0;
					break;
				case 4:
					a = num2 * 1000.0;
					break;
				}
				double num3 = Math.Ceiling(a);
				switch (unit)
				{
				case 2:
					num3 /= 10.0;
					break;
				case 3:
					num3 /= 100.0;
					break;
				case 4:
					num3 /= 1000.0;
					break;
				}
				double num4 = num3 * (double)num;
				result = num4;
			}
			catch
			{
				result = d;
			}
			return result;
		}

		public static double ComputeRoundDown(double d, int unit)
		{
			double d2 = 0.0;
			if (unit < 1 || unit > 4)
			{
				return d;
			}
			double result;
			try
			{
				int num = Math.Sign(d);
				double num2 = Math.Abs(d);
				switch (unit)
				{
				case 1:
					d2 = num2;
					break;
				case 2:
					d2 = num2 * 10.0;
					break;
				case 3:
					d2 = num2 * 100.0;
					break;
				case 4:
					d2 = num2 * 1000.0;
					break;
				}
				double num3 = Math.Floor(d2);
				switch (unit)
				{
				case 2:
					num3 /= 10.0;
					break;
				case 3:
					num3 /= 100.0;
					break;
				case 4:
					num3 /= 1000.0;
					break;
				}
				double num4 = num3 * (double)num;
				result = num4;
			}
			catch
			{
				result = d;
			}
			return result;
		}

		public static decimal ComputeRoundDec(decimal src, int destScale)
		{
			decimal result;
			try
			{
				int value = Math.Sign(src);
				decimal d = Math.Abs(src);
				decimal d2 = (decimal)Math.Pow(10.0, (double)(destScale - 1));
				decimal d3 = d * d2;
				decimal d4 = Math.Floor(d3 + 0.500000001m);
				d2 = (decimal)Math.Pow(10.0, (double)(-1 * (destScale - 1)));
				d4 *= d2;
				decimal num = d4 * value;
				result = num;
			}
			catch
			{
				result = src;
			}
			return result;
		}

		public static decimal ComputeRoundUpDec(decimal src, int destScale)
		{
			decimal result;
			try
			{
				int value = Math.Sign(src);
				decimal d = Math.Abs(src);
				decimal d2 = (decimal)Math.Pow(10.0, (double)(destScale - 1));
				decimal d3 = d * d2;
				decimal d4 = Math.Ceiling(d3);
				d2 = (decimal)Math.Pow(10.0, (double)(-1 * (destScale - 1)));
				d4 *= d2;
				decimal num = d4 * value;
				result = num;
			}
			catch
			{
				result = src;
			}
			return result;
		}

		public static decimal ComputeRoundDownDec(decimal src, int destScale)
		{
			decimal result;
			try
			{
				int value = Math.Sign(src);
				decimal d = Math.Abs(src);
				decimal d2 = (decimal)Math.Pow(10.0, (double)(destScale - 1));
				decimal d3 = d * d2;
				decimal d4 = Math.Floor(d3);
				d2 = (decimal)Math.Pow(10.0, (double)(-1 * (destScale - 1)));
				d4 *= d2;
				decimal num = d4 * value;
				result = num;
			}
			catch
			{
				result = src;
			}
			return result;
		}

		public static string GetComputerName()
		{
			return Environment.MachineName;
		}

		public static object NullStringToNUll(string o)
		{
			if (string.IsNullOrEmpty(o))
			{
				return null;
			}
			return o;
		}
	}
}
