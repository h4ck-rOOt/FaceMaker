using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RC.Common
{
	public class DataBase : IDisposable
	{
		public class RecordColumn
		{
			public string Name
			{
				get;
				internal set;
			}

			public int Index
			{
				get;
				internal set;
			}
		}

		public class RecordColumnCollection : List<DataBase.RecordColumn>
		{
			public DataBase.RecordColumn FindFromIndex(int index)
			{
				for (int i = 0; i < base.Count; i++)
				{
					if (base[i].Index == index)
					{
						return base[i];
					}
				}
				return null;
			}
		}

		public class RecordValue
		{
			internal string Name
			{
				get;
				set;
			}

			internal int Index
			{
				get;
				set;
			}

			public object Value
			{
				get;
				set;
			}

			public bool IsDBNull
			{
				get;
				set;
			}

			public override string ToString()
			{
				return Tools.AnyToString(this.Value);
			}
		}

		public class RecordValueCollenction : List<DataBase.RecordValue>
		{
			public DataBase.RecordValue this[string columnName]
			{
				get
				{
					return this.FindFromColumnName(columnName);
				}
			}

			public DataBase.RecordValue FindFromIndex(int index)
			{
				for (int i = 0; i < base.Count; i++)
				{
					if (base[i].Index == index)
					{
						return base[i];
					}
				}
				return null;
			}

			public DataBase.RecordValue FindFromColumnName(string columnName)
			{
				for (int i = 0; i < base.Count; i++)
				{
					if (base[i].Name == columnName)
					{
						return base[i];
					}
				}
				return null;
			}
		}

		public class RecordSet
		{
			public DataBase.RecordColumnCollection Columns
			{
				get;
				internal set;
			}

			public List<DataBase.RecordValueCollenction> Rows
			{
				get;
				internal set;
			}

			public DataBase.RecordValueCollenction this[int i]
			{
				get
				{
					return this.Rows[i];
				}
			}

			internal RecordSet()
			{
				this.Columns = new DataBase.RecordColumnCollection();
				this.Rows = new List<DataBase.RecordValueCollenction>();
			}
		}

		private string serverName;

		private string schemaName;

		private bool useTrustedConnection;

		private string userName;

		private string passString;

		private int timeoutCount;

		private string applicationName;

		private bool useKeepAlive;

		private string optString;

		private string lastErrorCD;

		private string lastErrorDescription;

		private string parametedConnString;

		private bool throwExceptions;

		private SqlConnection sqlConn;

		private SqlTransaction sqlTran;

		public string ServerName
		{
			get
			{
				return this.serverName;
			}
		}

		public string SchemaName
		{
			get
			{
				return this.schemaName;
			}
		}

		public bool TrustedConnection
		{
			get
			{
				return this.useTrustedConnection;
			}
		}

		public string UserName
		{
			get
			{
				return this.userName;
			}
		}

		public string Password
		{
			get
			{
				return this.passString;
			}
		}

		public int Timeout
		{
			get
			{
				return this.timeoutCount;
			}
		}

		public string ApplicationName
		{
			get
			{
				return this.applicationName;
			}
		}

		public bool KeepAlive
		{
			get
			{
				return this.useKeepAlive;
			}
		}

		public string OptionalString
		{
			get
			{
				return this.optString;
			}
		}

		public string LastErrorCD
		{
			get
			{
				return this.lastErrorCD;
			}
		}

		public bool ThrowExceptions
		{
			get
			{
				return this.throwExceptions;
			}
			set
			{
				this.throwExceptions = value;
			}
		}

		public string LastDescription
		{
			get
			{
				return this.lastErrorDescription;
			}
		}

		public SqlCommand SqlCommand
		{
			get
			{
				if (this.sqlConn == null)
				{
					return null;
				}
				this.ClearError();
				if (!this.Connect())
				{
					return null;
				}
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = this.sqlConn;
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandTimeout = this.timeoutCount;
				if (this.sqlTran != null)
				{
					sqlCommand.Transaction = this.sqlTran;
				}
				return sqlCommand;
			}
		}

		private DataBase()
		{
		}

		public DataBase(string connString)
		{
			this.ParseConnectionString(connString);
			this.sqlConn = null;
			this.sqlTran = null;
			this.throwExceptions = true;
			this.ClearError();
		}

		public DataBase(string server, string database, int timeout, string appName, bool keepAlive, string opt)
		{
			this.serverName = server;
			this.schemaName = ((database == null) ? "master" : database);
			this.useTrustedConnection = true;
			this.timeoutCount = timeout;
			this.applicationName = ((appName == null) ? "ADO.NET client Application" : appName);
			this.useKeepAlive = keepAlive;
			this.optString = ((opt == null) ? "" : opt);
			this.userName = "";
			this.passString = "";
			this.sqlConn = null;
			this.sqlTran = null;
			this.throwExceptions = true;
			this.ClearError();
		}

		public DataBase(string server, string database, string user, string password, int timeout, string appName, bool keepAlive, string opt)
		{
			this.serverName = server;
			this.schemaName = ((database == null) ? "master" : ((database == "") ? "master" : database));
			this.userName = user;
			this.passString = password;
			this.useTrustedConnection = false;
			this.timeoutCount = timeout;
			this.applicationName = ((appName == null) ? "ADO.NET client Application" : ((appName == "") ? "ADO.NET client Application" : appName));
			this.useKeepAlive = keepAlive;
			this.optString = ((opt == null) ? "" : opt);
			this.sqlConn = null;
			this.sqlTran = null;
			this.throwExceptions = true;
			this.ClearError();
		}

		void IDisposable.Dispose()
		{
			if (this.sqlTran != null)
			{
				this.sqlTran.Rollback();
				this.sqlTran.Dispose();
			}
			this.sqlConn.Close();
			this.sqlConn.Dispose();
			GC.Collect();
		}

		public bool Connect()
		{
			if (this.sqlConn != null && this.sqlConn.State != ConnectionState.Closed)
			{
				return true;
			}
			if (this.sqlConn != null)
			{
				this.sqlConn.Dispose();
			}
			this.ClearError();
			bool result;
			try
			{
				this.sqlConn = new SqlConnection(this.CreateConnectionString());
				this.sqlConn.Open();
				result = true;
			}
			catch (Exception ex)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = false;
			}
			return result;
		}

		public bool IsConnected()
		{
			return this.sqlConn != null && this.sqlConn.State != ConnectionState.Closed;
		}

		public bool BeginTransaction()
		{
			return this.BeginTransaction(IsolationLevel.Serializable);
		}

		public bool BeginTransaction(IsolationLevel level)
		{
			if (this.sqlConn == null)
			{
				return false;
			}
			if (this.sqlTran != null)
			{
				return false;
			}
			this.ClearError();
			bool result;
			try
			{
				if (this.sqlConn.State == ConnectionState.Closed && !this.Connect())
				{
					result = false;
				}
				else
				{
					this.sqlTran = this.sqlConn.BeginTransaction(level);
					result = true;
				}
			}
			catch (Exception ex)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = false;
			}
			return result;
		}

		public bool CommitTransaction()
		{
			if (!this.IsConnected())
			{
				return false;
			}
			if (this.sqlConn.State == ConnectionState.Closed)
			{
				return false;
			}
			if (this.sqlTran == null)
			{
				return false;
			}
			this.ClearError();
			bool result;
			try
			{
				this.sqlTran.Commit();
				this.sqlTran.Dispose();
				this.sqlTran = null;
				result = true;
			}
			catch (Exception ex)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = false;
			}
			return result;
		}

		public bool RollbackTransaction()
		{
			if (!this.IsConnected())
			{
				return false;
			}
			if (this.sqlConn.State == ConnectionState.Closed)
			{
				return false;
			}
			if (this.sqlTran == null)
			{
				return false;
			}
			this.ClearError();
			bool result;
			try
			{
				this.sqlTran.Rollback();
				this.sqlTran.Dispose();
				this.sqlTran = null;
				result = true;
			}
			catch (Exception ex)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = false;
			}
			return result;
		}

		public int ExecuteCommand(string SQL)
		{
			if (this.sqlConn == null)
			{
				return -1;
			}
			if (SQL == null || SQL == "")
			{
				return -1;
			}
			this.ClearError();
			int result;
			try
			{
				if (!this.Connect())
				{
					result = -1;
				}
				else
				{
					int num;
					using (SqlCommand sqlCommand = new SqlCommand(SQL, this.sqlConn))
					{
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandTimeout = this.timeoutCount;
						sqlCommand.Parameters.Add("@RETURN", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
						if (this.sqlTran != null)
						{
							sqlCommand.Transaction = this.sqlTran;
						}
						sqlCommand.ExecuteNonQuery();
						num = Tools.AnyToInt(sqlCommand.Parameters["@RETURN"].Value);
					}
					result = num;
				}
			}
			catch (SqlException ex)
			{
				this.lastErrorCD = Tools.AnyToString(ex.ErrorCode);
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = ex.ErrorCode;
			}
			catch (Exception ex2)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex2.Message;
				result = -1;
			}
			return result;
		}

		public DataTable GetDataTable(string SQL)
		{
			int num;
			return this.GetDataTable(SQL, out num);
		}

		public DataTable GetDataTable(string SQL, out int intErrorCode)
		{
			intErrorCode = 0;
			if (this.sqlConn == null)
			{
				return null;
			}
			if (SQL == string.Empty)
			{
				return null;
			}
			this.ClearError();
			DataTable result;
			try
			{
				if (!this.Connect())
				{
					result = null;
				}
				else
				{
					DataTable dataTable = new DataTable();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, this.sqlConn);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
					sqlDataAdapter.SelectCommand.CommandTimeout = this.timeoutCount;
					sqlDataAdapter.SelectCommand.Parameters.Add("@RETURN", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
					if (this.sqlTran != null)
					{
						sqlDataAdapter.SelectCommand.Transaction = this.sqlTran;
					}
					sqlDataAdapter.Fill(dataTable);
					intErrorCode = Tools.AnyToInt(sqlDataAdapter.SelectCommand.Parameters["@RETURN"]);
					result = dataTable;
				}
			}
			catch (SqlException ex)
			{
				this.lastErrorCD = Tools.AnyToString(ex.ErrorCode);
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = null;
			}
			catch (Exception ex2)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex2.Message;
				if (this.throwExceptions)
				{
					throw ex2;
				}
				result = null;
			}
			return result;
		}

		public SqlDataReader GetDataReader(string SQL)
		{
			int num;
			return this.GetDataReader(SQL, out num);
		}

		public SqlDataReader GetDataReader(string SQL, out int intErrorCode)
		{
			intErrorCode = 0;
			if (this.sqlConn == null)
			{
				return null;
			}
			if (SQL == string.Empty)
			{
				return null;
			}
			this.ClearError();
			SqlDataReader result;
			try
			{
				if (!this.Connect())
				{
					result = null;
				}
				else
				{
					using (SqlCommand sqlCommand = new SqlCommand(SQL, this.sqlConn))
					{
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandTimeout = this.timeoutCount;
						sqlCommand.Parameters.Add("@RETURN", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
						if (this.sqlTran != null)
						{
							sqlCommand.Transaction = this.sqlTran;
						}
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						result = sqlDataReader;
					}
				}
			}
			catch (SqlException ex)
			{
				this.lastErrorCD = Tools.AnyToString(ex.ErrorCode);
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = null;
			}
			catch (Exception ex2)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex2.Message;
				if (this.throwExceptions)
				{
					throw ex2;
				}
				result = null;
			}
			return result;
		}

		public DataBase.RecordSet GetRecordSet(string SQL)
		{
			int num;
			return this.GetRecordSet(SQL, out num);
		}

		public DataBase.RecordSet GetRecordSet(string SQL, out int intErrorCD)
		{
			DataBase.RecordSet result;
			using (SqlDataReader dataReader = this.GetDataReader(SQL, out intErrorCD))
			{
				if (!Check.IsValidDataReader(dataReader))
				{
					result = new DataBase.RecordSet();
				}
				else
				{
					DataBase.RecordSet recordSet = new DataBase.RecordSet();
					for (int i = 0; i < dataReader.FieldCount; i++)
					{
						DataBase.RecordColumn recordColumn = new DataBase.RecordColumn();
						recordColumn.Index = i;
						recordColumn.Name = dataReader.GetName(i);
						recordSet.Columns.Add(recordColumn);
					}
					while (dataReader.Read())
					{
						DataBase.RecordValueCollenction recordValueCollenction = new DataBase.RecordValueCollenction();
						for (int j = 0; j < recordSet.Columns.Count; j++)
						{
							recordValueCollenction.Add(new DataBase.RecordValue
							{
								Index = j,
								Name = recordSet.Columns[j].Name,
								Value = dataReader[j],
								IsDBNull = (dataReader[j] == DBNull.Value)
							});
						}
						recordSet.Rows.Add(recordValueCollenction);
					}
					dataReader.Close();
					result = recordSet;
				}
			}
			return result;
		}

		public bool Close()
		{
			if (this.sqlConn == null)
			{
				return true;
			}
			bool result;
			try
			{
				if (this.sqlTran != null)
				{
					this.sqlTran.Rollback();
					this.sqlTran.Dispose();
					this.sqlTran = null;
				}
				this.sqlConn.Close();
				result = true;
			}
			catch (Exception ex)
			{
				this.lastErrorCD = "";
				this.lastErrorDescription = ex.Message;
				if (this.throwExceptions)
				{
					throw ex;
				}
				result = false;
			}
			return result;
		}

		private void ClearError()
		{
			this.lastErrorCD = "";
			this.lastErrorDescription = "";
		}

		private string CreateConnectionString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Application Name=" + this.applicationName + ";");
			stringBuilder.Append("Data Source=" + this.serverName + ";");
			stringBuilder.Append("Initial Catalog=" + this.schemaName + ";");
			if (this.useTrustedConnection)
			{
				stringBuilder.Append("Trusted_Connection=true;");
			}
			else
			{
				stringBuilder.Append("Trusted_Connection=false;");
				stringBuilder.Append("User ID=" + this.userName + ";");
				stringBuilder.Append("Password=" + this.passString + ";");
			}
			stringBuilder.Append("Pooling=" + (this.useKeepAlive ? "true" : "false"));
			if (this.optString != "")
			{
				stringBuilder.Append(";" + this.optString);
			}
			return stringBuilder.ToString();
		}

		private bool ParseConnectionString(string connString)
		{
			string[] array = connString.Split(new char[]
			{
				';'
			});
			string text5;
			string text4;
			string text3;
			string text2;
			string text = text2 = (text3 = (text4 = (text5 = "")));
			bool flag = true;
			bool flag2 = false;
			int num = 0;
			if (array.Length <= 0)
			{
				return false;
			}
			int i = 0;
			while (i < array.Length)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'='
				});
				if (array2.Length < 2)
				{
					i++;
				}
				else
				{
					string text6 = array2[0].Replace(";", "").Trim();
					string text7 = array2[1].Replace(";", "").Trim();
					string key;
					switch (key = text6)
					{
					case "Application Name":
						text2 = text7;
						break;
					case "Connect Timeout":
					case "Connection Timeout":
						num = Tools.AnyToInt(text7);
						break;
					case "Data Source":
					case "Server":
					case "Address":
					case "Addr":
					case "Network Address":
						text = text7;
						break;
					case "Initial Catalog":
					case "Database":
						text3 = text7;
						break;
					case "Integrated Security":
					case "Trusted_Connection":
						flag = (text7.ToLower() == "yes" || text7.ToLower() == "sspi" || text7.ToLower() == "true");
						break;
					case "Password":
					case "Pwd":
						text5 = text7;
						break;
					case "User ID":
						text4 = text7;
						break;
					case "Pooling":
						flag2 = (text7.ToLower() == "yes" || text7.ToLower() == "true");
						break;
					}
					i++;
				}
			}
			this.serverName = text;
			this.schemaName = ((text3 == null) ? "master" : text3);
			this.useTrustedConnection = (text5.Length == 0 && flag);
			this.userName = text4;
			this.passString = text5;
			this.timeoutCount = num;
			this.applicationName = ((text2 == null) ? "ADO.NET client Application" : text2);
			this.useKeepAlive = flag2;
			this.optString = "";
			this.parametedConnString = connString;
			return true;
		}

		public DataTable GetSchema(string collectionName)
		{
			if (this.sqlConn == null)
			{
				return null;
			}
			if (!this.IsConnected())
			{
				return null;
			}
			return this.sqlConn.GetSchema(collectionName);
		}

		public DataTable GetSchema(string catalog, string owner, string tableName, string tableType, string collectionName)
		{
			if (this.sqlConn == null)
			{
				return null;
			}
			if (!this.IsConnected())
			{
				return null;
			}
			string[] restrictionValues = new string[]
			{
				(catalog == string.Empty) ? null : catalog,
				(owner == string.Empty) ? null : owner,
				(tableName == string.Empty) ? null : tableName,
				(tableType == string.Empty) ? null : tableType
			};
			return this.sqlConn.GetSchema(collectionName, restrictionValues);
		}
	}
}
