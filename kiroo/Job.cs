using System;
using Quartz;

namespace kiroo
{
	internal class Job : IJob
	{
		/// <summary>
		/// Generates the images.
		/// Makes sure generated image is not already done.
		/// Tweets image.
		/// </summary>
		public void Execute ( IJobExecutionContext context )
		{
			
		}
	}
}