using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace kiroo
{
	public class Image
	{
		public const int WIDTH		= 1920;
		public const int HEIGHT		= 1080;

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
			var bmap = new Bitmap ( WIDTH, HEIGHT );
			var colors = RandomizeColors ();	// Color [WIDTH * HEIGHT]

			for ( int y = 0; y != HEIGHT; y++ )
			{
				for ( int x = 0; x != WIDTH; x++ )
				{
					bmap.SetPixel ( x, y, colors[WIDTH * y + x] );

				}
			}
			bmap.Save ( "img.png", ImageFormat.Png );
			return bmap;
		}

		private Color[] RandomizeColors ()
		{
			var bytes		= new byte [WIDTH * HEIGHT * 3];       // RGB pixel = 3 bytes
			var colors      = new Color[WIDTH * HEIGHT];
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
