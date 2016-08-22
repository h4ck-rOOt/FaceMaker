using System;

namespace RC.Common
{
	public abstract class SettingFileBase : ISettingFile
	{
		protected string fileName = "";

		protected bool encryptionSetting;

		protected string encryptionKey = "";

		public abstract int ReadInt(string sectionName, string keyName);

		public abstract string ReadString(string sectionName, string keyName);

		public abstract byte[] ReadBinary(string sectionName, string keyName);

		public abstract bool WriteInt(string sectionName, string keyName, int value);

		public abstract bool WriteString(string sectionName, string keyName, string value);

		public abstract bool WriteBinary(string sectionName, string keyName, byte[] value);
	}
}
