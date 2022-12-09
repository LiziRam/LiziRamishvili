using System;
namespace Practice_23
{
	public class Publisher
	{
		public event EventHandler ProcessCompleted;

		public void StartProcess()
		{
			Console.WriteLine("Publisher: Answer has been entered.");
            OnProcessCompleted();
		}

		protected virtual void OnProcessCompleted()
		{
			Console.WriteLine("Publisher: Answer received.");
			if(ProcessCompleted != null)
			{
				ProcessCompleted.Invoke(this,null);
			}
		}
	}
}

