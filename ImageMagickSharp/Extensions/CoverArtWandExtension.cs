using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp.Extensions
{
	public static class CoverArtWandExtension
	{
		public static void CoverArtStack(this MagickWand wand, double xIncrement, double yIncrement, double width, double height, params string[] images)
		{
			using (var draw = new DrawingWand())
			{
				double x = 0;
				double y = 0;
				using (var wandimages = new MagickWand(images))
				{
					foreach (ImageWand imageWand in wandimages.ImageList)
					{
						imageWand.BorderImage("black", 2, 2);
						draw.DrawComposite(CompositeOperator.AtopCompositeOp, x, y, width, height, imageWand);
						x += xIncrement;
						y += yIncrement;
					}
				}
				wand.CurrentImage.DrawImage(draw);
			}
		}
	}
}
