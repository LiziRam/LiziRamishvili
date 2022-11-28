using System;
namespace Practice_18._2
{
	public static class RecursiveGetMessage
	{
		public static string GetLastInnerExMessage(Exception ex)
		{
			if(ex == null)
			{
				return "";
			}
			if(ex.InnerException == null)
			{
				return ex.Message;
			}
			return GetLastInnerExMessage(ex.InnerException);

        }

		public static string GetAllInnerExMessageTogether(Exception ex)
		{
            if (ex == null)
            {
                return "";
            }
            if (ex.InnerException == null)
            {
                return ex.Message;
            }
            return ex.Message + ", " + GetAllInnerExMessageTogether(ex.InnerException);
        }

    }
}

