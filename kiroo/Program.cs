using System;
using Tweetinvi;
using Tweetinvi.Models;
using Quartz;
using Quartz.Impl;

namespace kiroo
{
	class Program
	{
		public static ITwitterCredentials user;

		static void Main ( string[] args )
		{
			// -1 = ERROR
			user = Auth.SetUserCredentials ( "tde1z6Ch1X7KyRbKWR0bG9w63", "zMB2xIjNoanRrfZeY9OZZpRb8jmPX73Watkto1CEBo1V8VVWZL",
									"812845327925604352-vjRaGZiaOgPh8knj4vxinLOK2BkL0Mu", "lOR0jOvPVqgaOIUR18ibQDHFKzO2YkgK1Qks8NC5u8X5m" );
			// Personal tests
			Menu.Start ();

			// AppHarbor
			//CreateJob ();
		}

		static void CreateJob ()
		{
			// construct a scheduler
			var schedulerFactory = new StdSchedulerFactory ();
			var scheduler = schedulerFactory.GetScheduler ();
			scheduler.Start ();

			var job = JobBuilder.Create<Job> ().Build ();

			// Runs every 10 minuts
			// Enough time to render, compare, save and tweet
			// ?
			var trigger = TriggerBuilder.Create ()
							.WithSimpleSchedule (x => x.WithIntervalInSeconds( 60 * 1 ).RepeatForever () )
							.Build ();

			scheduler.ScheduleJob ( job, trigger );
		}
	}
}
