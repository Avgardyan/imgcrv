using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using imgcrv.Data.DataEntities.Dto;

namespace imgcrv.Business.Services
{
    public class CarvingService : imgcrv.Business.Services.ICarvingService
    {

        double PixelToPercent(int before, int after)
        {
            return (double)after / before * 100;
        }

        public void Carve(ImageEntity image, int height, int width)
        {
            //Sets the image entity to a rescaled version of itself
            //Use this one to keep recarving an image
            //(this allows to avoid reading from file every time)
            
            MagickImage temp = image.GetMagickImage();

            Percentage heightPercent = (Percentage)PixelToPercent(temp.Height, height);
            Percentage widthPercent = (Percentage)PixelToPercent(temp.Width, width);

            temp.LiquidRescale(new MagickGeometry(widthPercent, heightPercent));
            image.SetMagickImage(temp);
        }
    }
}