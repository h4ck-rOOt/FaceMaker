using System;

namespace RC.Common
{
	public interface IAsyncProc
	{
		bool IsActive
		{
			get;
		}

		bool Start(int startWaitMilliSeconds);

		bool Stop(int waitMilliSeconds);
	}
}
