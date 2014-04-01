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

            return image;
        }
        
    }
}
