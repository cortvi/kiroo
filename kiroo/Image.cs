using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace kiroo
{
	public class Image
	{
		public Image ()
		{
			Console.WriteLine ( " Rendering image..." );
			img = Render ();
			Console.WriteLine ( " Done." );
		}

		private Bitmap img;

		public byte[] GetBytes ()
		{
			ImageConverter converter = new ImageConverter();
			var array = ( byte[] ) converter.ConvertTo ( System.Drawing.Image.FromFile ( "img.png" ), typeof ( byte[] ) );

			return array;
		}

		private Bitmap Render ()
		{
			var bmap = new Bitmap ( 1920, 1080 );
			var colors = RandomizeColors ();	// Color [1920 * 1080]

			for ( int y = 0; y != 1080; y++ )
			{
				for ( int x = 0; x != 1920; x++ )
				{
					bmap.SetPixel ( x, y, colors[1920 * y + x] );

				}
			}
			bmap.Save ( "img.png", ImageFormat.Png );
			return bmap;
		}

		private Color[] RandomizeColors ()
		{
			var bytes		= new byte [1920 * 1080 * 3];       // RGB pixel = 3 bytes
			var colors      = new Color[1920 * 1080];
			var rnd			= RandomNumberGenerator.Create ();

			rnd.GetBytes ( bytes );

			var index = 0;
			for ( long i = 0; i != bytes.LongLength; i += 3 )
			{
				colors[index] = Color.FromArgb ( Convert.ToInt16 ( bytes[i] ),
												Convert.ToInt16 ( bytes[i+1] ),
												Convert.ToInt16 ( bytes[i+2] ) );
				index++;
			}

			return colors;
		}
	}
}
