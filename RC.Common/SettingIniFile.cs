using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RC.Common
{
	public class SettingIniFile : SettingFileBase
	{
		[DllImport("kernel32.dll")]
		private static extern uint GetPrivateProfileString(string lpApplicationName, string lpEntryName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

		[DllImport("kernel32.dll")]
		private static extern uint WritePrivateProfileString(string lpApplicationName, string lpEntryName, string lpEntryString, string lpFileName);

		public SettingIniFile(string fileName) : this(fileName, false, null)
		{
		}

		public SettingIniFile(string fileName, bool useEncryption) : this(fileName, useEncryption, null)
		{
		}

		public SettingIniFile(string fileName, bool useEncryption, string encryptionKey)
		{
			this.fileName = fileName;
			this.encryptionSetting = useEncryption;
			if (useEncryption && encryptionKey != null && encryptionKey != string.Empty)
			{
				this.encryptionKey = encryptionKey;
			}
		}

		public override int ReadInt(string sectionName, string keyName)
		{
			if (this.fileName == "")
			{
				return 0;
			}
			int result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				SettingIniFile.GetPrivateProfileString(sectionName, keyName, "", stringBuilder, (uint)stringBuilder.Capacity, this.fileName);
				string text = Tools.AnyToString(stringBuilder.ToString());
				if (text == string.Empty)
				{
					result = 0;
				}
				else if (this.encryptionSetting)
				{
					result = Tools.AnyToInt(Crypt.Decrypt(text));
				}
				else
				{
					result = Tools.AnyToInt(text);
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public override string ReadString(string sectionName, string keyName)
		{
			if (this.fileName == "")
			{
				return "";
			}
			string result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				SettingIniFile.GetPrivateProfileString(sectionName, keyName, "", stringBuilder, (uint)stringBuilder.Capacity, this.fileName);
				string text = Tools.AnyToString(stringBuilder.ToString());
				if (text == string.Empty)
				{
					result = "";
				}
				else if (this.encryptionSetting)
				{
					result = Crypt.Decrypt(text);
				}
				else
				{
					result = text;
				}
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}

		public override byte[] ReadBinary(string sectionName, string keyName)
		{
			if (this.fileName == "")
			{
				return null;
			}
			byte[] result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				SettingIniFile.GetPrivateProfileString(sectionName, keyName, "", stringBuilder, (uint)stringBuilder.Capacity, this.fileName);
				string text = Tools.AnyToString(stringBuilder.ToString());
				if (text == string.Empty)
				{
					result = null;
				}
				else
				{
					byte[] array = Convert.FromBase64String(text);
					result = array;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public override bool WriteInt(string sectionName, string keyName, int value)
		{
			return this.WriteString(sectionName, keyName, Tools.AnyToString(value));
		}

		public override bool WriteString(string sectionName, string keyName, string value)
		{
			if (this.fileName == "")
			{
				return false;
			}
			bool result;
			try
			{
				string lpEntryString;
				if (this.encryptionSetting)
				{
					lpEntryString = Crypt.Encrypt(value, this.encryptionKey);
				}
				else
				{
					lpEntryString = value;
				}
				SettingIniFile.WritePrivateProfileString(sectionName, keyName, lpEntryString, this.fileName);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public override bool WriteBinary(string sectionName, string keyName, byte[] value)
		{
			if (this.fileName == "")
			{
				return false;
			}
			if (value == null)
			{
				return false;
			}
			bool result;
			try
			{
				string lpEntryString = Convert.ToBase64String(value);
				SettingIniFile.WritePrivateProfileString(sectionName, keyName, lpEntryString, this.fileName);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
