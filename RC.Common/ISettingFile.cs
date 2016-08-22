using System;

namespace RC.Common
{
	public interface ISettingFile
	{
		int ReadInt(string sectionName, string keyName);

		string ReadString(string sectionName, string keyName);

		byte[] ReadBinary(string sectionName, string keyName);

		bool WriteInt(string sectionName, string keyName, int value);

		bool WriteString(string sectionName, string keyName, string value);

		bool WriteBinary(string sectionName, string keyName, byte[] value);
	}
}
