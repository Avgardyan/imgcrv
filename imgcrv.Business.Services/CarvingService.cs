using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using imgcrv.Data.DataEntities.Dto;

namespace imgcrv.Business.Services
{
    class CarvingService
    {

        private MagickImage image;

        
        double PixelToPercent(int before, int after)
        {
            return (double)after / before;
        }

        ImageEntity Carve(ImageEntity image, int height, int width)
        {
            //Sets the image entity to a rescaled version of itself
            //Use this one to keep recarving an image
            //(this allows to avoid reading from file every time)
            image.SetMagickImage
                (image.GetMagickImage().
                LiquidRescale
                    (PixelToPercent(image.height, height),
                     PixelToPercent(image.width, width)));
            return image;
        }
        
        ImageEntity ReCarve(ImageEntity image, int height, int width)
        {
            //Resets the image to the original version and carves again
            image.ReadImageFromUrl();
            return Carve(image, height, width);
        }
        
    }
}
