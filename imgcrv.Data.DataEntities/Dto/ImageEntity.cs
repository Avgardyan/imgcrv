using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace imgcrv.Data.DataEntities.Dto
{
    class ImageEntity
    {
        private MagickImage img;
        int height;
        int width;

        public ImageEntity(MagickImage image)
        {
            img = image;
            height = img.Height;
            width = img.Width;
        }

        MagickImage GetMagickImage()
        {
            return img;
        }
    }
}
