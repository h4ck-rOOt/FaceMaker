using System;
using System.IO;
using System.Text;
using System.Xml;

namespace RC.Common
{
	public class SettingConfigFile : SettingFileBase
	{
		private string rootSection = "Settings";

		public SettingConfigFile(string fileName) : this(fileName, "", false, null)
		{
		}

		public SettingConfigFile(string fileName, string rootSectionName) : this(fileName, rootSectionName, false, null)
		{
		}

		public SettingConfigFile(string fileName, bool useEncryption) : this(fileName, "", useEncryption, null)
		{
		}

		public SettingConfigFile(string fileName, string rootSectionName, bool useEncryption) : this(fileName, rootSectionName, useEncryption, null)
		{
		}

		public SettingConfigFile(string fileName, string rootSectionName, bool useEncryption, string encryptionKey)
		{
			this.fileName = fileName;
			if (rootSectionName != string.Empty)
			{
				this.rootSection = rootSectionName;
			}
			this.encryptionSetting = useEncryption;
			if (useEncryption)
			{
				if (encryptionKey != null && encryptionKey != string.Empty)
				{
					this.encryptionKey = encryptionKey;
					return;
				}
				this.encryptionKey = Tools.ByteArrayToString(Constants.DEFAULT_CRYPT_KEY);
			}
		}

		public override int ReadInt(string sectionName, string keyName)
		{
			return Tools.AnyToInt(this.ReadString(sectionName, keyName));
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
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this.fileName);
				if (xmlDocument.GetElementsByTagName(this.rootSection).Count != 0)
				{
					XmlNode xmlNode = xmlDocument.SelectSingleNode(this.rootSection);
					XmlNode xmlNode2 = null;
					for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
					{
						if (xmlNode.ChildNodes[i].Name == sectionName)
						{
							xmlNode2 = xmlNode.ChildNodes[i];
							break;
						}
					}
					if (xmlNode2 == null)
					{
						result = "";
					}
					else
					{
						XmlNode xmlNode3 = null;
						for (int j = 0; j < xmlNode2.ChildNodes.Count; j++)
						{
							if (xmlNode2.ChildNodes[j].Name == keyName)
							{
								xmlNode3 = xmlNode2.ChildNodes[j];
								break;
							}
						}
						if (xmlNode3 == null)
						{
							result = "";
						}
						else
						{
							string text = Tools.AnyToString(xmlNode3.InnerText);
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
					}
				}
				else
				{
					result = "";
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
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this.fileName);
				if (xmlDocument.GetElementsByTagName(this.rootSection).Count != 0)
				{
					XmlNode xmlNode = xmlDocument.SelectSingleNode(this.rootSection);
					XmlNode xmlNode2 = null;
					for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
					{
						if (xmlNode.ChildNodes[i].Name == sectionName)
						{
							xmlNode2 = xmlNode.ChildNodes[i];
							break;
						}
					}
					if (xmlNode2 == null)
					{
						result = null;
					}
					else
					{
						XmlNode xmlNode3 = null;
						for (int j = 0; j < xmlNode2.ChildNodes.Count; j++)
						{
							if (xmlNode2.ChildNodes[j].Name == keyName)
							{
								xmlNode3 = xmlNode2.ChildNodes[j];
								break;
							}
						}
						if (xmlNode3 == null)
						{
							result = null;
						}
						else
						{
							string text = Tools.AnyToString(xmlNode3.InnerText);
							if (text == string.Empty)
							{
								result = null;
							}
							else
							{
								result = Convert.FromBase64String(text);
							}
						}
					}
				}
				else
				{
					result = null;
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
				if (!File.Exists(this.fileName))
				{
					using (XmlTextWriter xmlTextWriter = new XmlTextWriter(this.fileName, Encoding.UTF8))
					{
						xmlTextWriter.WriteStartDocument();
						xmlTextWriter.WriteStartElement(this.rootSection);
						xmlTextWriter.WriteEndElement();
						xmlTextWriter.WriteEndDocument();
						xmlTextWriter.Close();
					}
				}
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this.fileName);
				XmlNode xmlNode;
				if (xmlDocument.GetElementsByTagName(this.rootSection).Count != 0)
				{
					xmlNode = xmlDocument.SelectSingleNode(this.rootSection);
				}
				else
				{
					xmlNode = xmlDocument.AppendChild(xmlDocument.CreateElement(sectionName));
				}
				XmlNode xmlNode2 = null;
				for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
				{
					if (xmlNode.ChildNodes[i].Name == sectionName)
					{
						xmlNode2 = xmlNode.ChildNodes[i];
						break;
					}
				}
				if (xmlNode2 == null)
				{
					xmlNode2 = xmlNode.AppendChild(xmlDocument.CreateElement(sectionName));
				}
				XmlNode xmlNode3 = null;
				for (int j = 0; j < xmlNode2.ChildNodes.Count; j++)
				{
					if (xmlNode2.ChildNodes[j].Name == keyName)
					{
						xmlNode3 = xmlNode2.ChildNodes[j];
						break;
					}
				}
				if (xmlNode3 == null)
				{
					xmlNode3 = xmlNode2.AppendChild(xmlDocument.CreateElement(keyName));
				}
				string innerText;
				if (this.encryptionSetting)
				{
					innerText = Crypt.Encrypt(value, this.encryptionKey);
				}
				else
				{
					innerText = value;
				}
				xmlNode3.InnerText = innerText;
				xmlDocument.Save(this.fileName);
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
			bool result;
			try
			{
				if (!File.Exists(this.fileName))
				{
					using (XmlTextWriter xmlTextWriter = new XmlTextWriter(this.fileName, Encoding.UTF8))
					{
						xmlTextWriter.WriteStartDocument();
						xmlTextWriter.WriteStartElement(this.rootSection);
						xmlTextWriter.WriteEndElement();
						xmlTextWriter.WriteEndDocument();
						xmlTextWriter.Close();
					}
				}
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(this.fileName);
				XmlNode xmlNode;
				if (xmlDocument.GetElementsByTagName(this.rootSection).Count != 0)
				{
					xmlNode = xmlDocument.SelectSingleNode(this.rootSection);
				}
				else
				{
					xmlNode = xmlDocument.AppendChild(xmlDocument.CreateElement(sectionName));
				}
				XmlNode xmlNode2 = null;
				for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
				{
					if (xmlNode.ChildNodes[i].Name == sectionName)
					{
						xmlNode2 = xmlNode.ChildNodes[i];
						break;
					}
				}
				if (xmlNode2 == null)
				{
					xmlNode2 = xmlNode.AppendChild(xmlDocument.CreateElement(sectionName));
				}
				XmlNode xmlNode3 = null;
				for (int j = 0; j < xmlNode2.ChildNodes.Count; j++)
				{
					if (xmlNode2.ChildNodes[j].Name == keyName)
					{
						xmlNode3 = xmlNode2.ChildNodes[j];
						break;
					}
				}
				if (xmlNode3 == null)
				{
					xmlNode3 = xmlNode2.AppendChild(xmlDocument.CreateElement(keyName));
				}
				string innerText = Convert.ToBase64String(value);
				xmlNode3.InnerText = innerText;
				xmlDocument.Save(this.fileName);
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
