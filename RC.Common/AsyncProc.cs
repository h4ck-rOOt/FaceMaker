using System;
using System.ComponentModel;
using System.Threading;

namespace RC.Common
{
	public class AsyncProc : IAsyncProc, IDisposable
	{
		public delegate int AsyncMethod();

		protected ManualResetEvent _syncEventExiting = new ManualResetEvent(false);

		protected ManualResetEvent _syncEventExited = new ManualResetEvent(true);

		protected Thread _thread;

		private int _exitCode;

		public AsyncProc.AsyncMethod AsyncProcedure;

		public event EventHandler AsyncProcStarted;

		public event EventHandler AsyncProcStopped;

		public bool IsActive
		{
			get
			{
				return this._thread != null && !this._syncEventExited.WaitOne(0) && (this._thread.ThreadState & ThreadState.Stopped) != ThreadState.Stopped;
			}
		}

		public int ExitCode
		{
			get
			{
				return this._exitCode;
			}
		}

		public bool IsExitting
		{
			get
			{
				return this._syncEventExiting.WaitOne(0);
			}
		}

		public bool Start(int startWaitMilliSeconds)
		{
			if (this.IsActive)
			{
				return false;
			}
			this._thread = new Thread(new ParameterizedThreadStart(this.AsyncProcessParent), 0);
			this._thread.Start();
			if (this.AsyncProcStarted != null)
			{
				this.AsyncProcStarted(this, new EventArgs());
			}
			return true;
		}

		public bool Stop(int waitMilliSeconds)
		{
			if (!this.IsActive)
			{
				return false;
			}
			this._syncEventExiting.Set();
			bool flag = false;
			int tickCount = Environment.TickCount;
			bool flag2 = false;
			while (!flag)
			{
				if (this._syncEventExited.WaitOne(0))
				{
					flag = true;
				}
				else if (waitMilliSeconds == 0)
				{
					this._thread.Join();
				}
				else
				{
					int tickCount2 = Environment.TickCount;
					bool flag3 = false;
					if (tickCount2 - tickCount < 0)
					{
						long num = (long)(2147483647 + tickCount2);
						if (num - (long)tickCount > (long)waitMilliSeconds)
						{
							flag3 = true;
						}
					}
					else if (tickCount2 - tickCount > waitMilliSeconds)
					{
						flag3 = true;
					}
					if (flag3)
					{
						this._thread.Abort();
						flag = true;
						flag2 = true;
					}
					else
					{
						Thread.Sleep(5);
					}
				}
			}
			this._thread = null;
			return !flag2;
		}

		public AsyncProc() : this(null)
		{
		}

		public AsyncProc(AsyncProc.AsyncMethod asyncMethod)
		{
			this.AsyncProcedure = asyncMethod;
			EventHandler arg_2B_0 = this.AsyncProcStarted;
			EventHandler arg_32_0 = this.AsyncProcStopped;
		}

		public void Dispose()
		{
			if (this.IsActive)
			{
				this.Stop(0);
			}
		}

		private void AsyncProcessParent(object args)
		{
			this._syncEventExiting.Reset();
			this._syncEventExited.Reset();
			if (Tools.AnyToInt(args) > 0)
			{
				Thread.Sleep(Tools.AnyToInt(args));
			}
			this._exitCode = this.AsyncProcedure();
			this._syncEventExited.Set();
			if (this.AsyncProcStopped != null)
			{
				ISynchronizeInvoke synchronizeInvoke = this.AsyncProcStopped.Target as ISynchronizeInvoke;
				if (synchronizeInvoke != null)
				{
					synchronizeInvoke.Invoke(this.AsyncProcStopped, new object[]
					{
						this,
						new EventArgs()
					});
					return;
				}
				this.AsyncProcStopped(this, new EventArgs());
			}
		}
	}
}
