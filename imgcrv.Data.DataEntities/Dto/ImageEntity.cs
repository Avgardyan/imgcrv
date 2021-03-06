﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ImageMagick;

namespace imgcrv.Data.DataEntities.Dto
{
    public class ImageEntity
    {
        
        private MagickImage image;

        public ImageEntity(MagickImage image)
        {
            SetMagickImage(image);
        }

        public MagickImage GetMagickImage()
        {
            return image;
        }

        public void SetMagickImage(MagickImage image)
        {
            this.image = image;
        }

    }
}
