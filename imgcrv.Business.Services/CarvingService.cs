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

        double PixelToPercent(int before, int after)
        {
            return (double)after / before;
        }

        public void Carve(ImageEntity image, int height, int width)
        {
            //Sets the image entity to a rescaled version of itself
            //Use this one to keep recarving an image
            //(this allows to avoid reading from file every time)       
            
            MagickImage temp = image.GetMagickImage();
            temp.LiquidRescale(new MagickGeometry(
                (Percentage)PixelToPercent(image.height, height),
                (Percentage)PixelToPercent(image.width, width)));
            image.SetMagickImage(temp);
        }
        
        
        
    }
}
