using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RC.Common
{
	public class Crypt
	{
		private Crypt()
		{
		}

		public static string Encrypt(string str)
		{
			return Crypt.Encrypt(str, Tools.ByteArrayToString(Constants.DEFAULT_CRYPT_KEY));
		}

		public static string Encrypt(string str, string key)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes2 = Encoding.UTF8.GetBytes(key);
			dESCryptoServiceProvider.Key = Crypt.ResizeBytesArray(bytes2, dESCryptoServiceProvider.Key.Length);
			dESCryptoServiceProvider.IV = Crypt.ResizeBytesArray(bytes2, dESCryptoServiceProvider.IV.Length);
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = dESCryptoServiceProvider.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			cryptoStream.Close();
			memoryStream.Close();
			return Convert.ToBase64String(inArray);
		}

		public static string Decrypt(string str)
		{
			return Crypt.Decrypt(str, Tools.ByteArrayToString(Constants.DEFAULT_CRYPT_KEY));
		}

		public static string Decrypt(string str, string key)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes = Encoding.UTF8.GetBytes(key);
			dESCryptoServiceProvider.Key = Crypt.ResizeBytesArray(bytes, dESCryptoServiceProvider.Key.Length);
			dESCryptoServiceProvider.IV = Crypt.ResizeBytesArray(bytes, dESCryptoServiceProvider.IV.Length);
			byte[] buffer = Convert.FromBase64String(str);
			MemoryStream memoryStream = new MemoryStream(buffer);
			ICryptoTransform transform = dESCryptoServiceProvider.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			StreamReader streamReader = new StreamReader(cryptoStream, Encoding.UTF8);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			cryptoStream.Close();
			memoryStream.Close();
			return result;
		}

		public static List<byte> ComputeMD5(string filePath)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			List<byte> list = new List<byte>();
			List<byte> result;
			try
			{
				using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					list.AddRange(mD5CryptoServiceProvider.ComputeHash(fileStream));
					fileStream.Close();
				}
				result = list;
			}
			catch (Exception)
			{
				result = new List<byte>
				{
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				};
			}
			return result;
		}

		public static bool IsEqualMD5(string sourceFilePath, string destFilePath)
		{
			List<byte> list = Crypt.ComputeMD5(sourceFilePath);
			List<byte> list2 = Crypt.ComputeMD5(destFilePath);
			for (int i = 0; i < 16; i++)
			{
				if (list[i] != list2[i])
				{
					return false;
				}
			}
			return true;
		}

		private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
		{
			byte[] array = new byte[newSize];
			if (bytes.Length < newSize)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					array[i] = bytes[i];
				}
			}
			else
			{
				int num = 0;
				for (int j = newSize; j < bytes.Length; j++)
				{
					byte[] arg_2F_0 = array;
					int expr_2B = num++;
					arg_2F_0[expr_2B] ^= bytes[j];
					if (num >= array.Length)
					{
						num = 0;
					}
				}
			}
			return array;
		}
	}
}
