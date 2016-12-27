using System;
using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace kiroo
{
	internal static class Menu
	{
		public static async void Start ()
		{
			while ( true )
			{
				Console.Clear ();
				Console.WriteLine ( "\n KIROO HERE \n ===========================================| \n\n" );
				Console.Write ( " kiroo @> " );

				var cmd = Console.ReadLine ().Split ( new char[] { ' ' }, 2 );

				// Exit app
				if			( cmd[0] == "exit"  )	Environment.Exit (0);

				// Tweet
				else if		( cmd[0] == "tweet" )
				{
					Tweet.PublishTweet ( cmd[1] );
					Console.WriteLine ( "\n Done. " );
				}

				// generate empty progress-file
				else if		( cmd[0] == "reset" )	;

				// generate image, tweet
				else if		( cmd[0] == "run"   )
				{
					var img = new Image ();
					Console.Write ( "\n\n Tweet? [y/n] @> " );

					if ( Console.ReadLine () == "y" )
					{
						Auth.ExecuteOperationWithCredentials ( Program.user, () =>
						{
							var binary = System.IO.File.ReadAllBytes ( "img.png" );
							var media = Upload.UploadImage ( binary );
							Tweet.PublishTweet ( "TEST", new PublishTweetOptionalParameters
							{
								Medias = new List<IMedia> { media }
							} );
						} );
						Console.WriteLine ( " Tweeted." );
					}

					Console.WriteLine ( "_________________________." );
				}

				// Default
				else Console.WriteLine ( "Command unknown" );


				// Wait input before cleaning loop
				Console.ReadLine ();
			}
		}
	}
}
