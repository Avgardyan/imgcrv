using System;
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
        public int height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        private MagickImage image;
        private MagickImage origImage;
        
        public ImageEntity(MagickImage image)
        {
            //Do it in the service
            //this.origImage = image;
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

        public MagickImage GetOriginalMagickImage()
        {
            return origImage;
        }
    }
}
