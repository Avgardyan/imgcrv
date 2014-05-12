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

        public void Carve(ImageEntity image, int height, int width)
        {
            //Sets the image entity to a rescaled version of itself
            //Use this one to keep recarving an image
            //(this allows to avoid reading from file every time)
            
            MagickImage temp = image.GetMagickImage();

            MagickGeometry geometry = new MagickGeometry(width, height);
            geometry.IgnoreAspectRatio = true;

            temp.LiquidRescale(geometry);
            image.SetMagickImage(temp);
        }
    }
}