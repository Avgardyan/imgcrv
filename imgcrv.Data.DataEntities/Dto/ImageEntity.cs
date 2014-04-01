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
            protected set
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
            protected set
            {
                width = value;
            }
        }
        private MagickImage image;
        public string imageUrl
        {
            get
            {
                return imageUrl;
            }
            protected set
            {
                imageUrl = value;
            }
        }

        public ImageEntity(string imageUrl)
        {
            this.imageUrl = imageUrl;
            ReadImageFromUrl();
        }

        public ImageEntity(MagickImage image, string imageUrl)
        {
            this.imageUrl = imageUrl;
            SetMagickImage(image);
        }

        private void SetSize()
        {
            //exception
            //sets ImageEntity properties to MagickImage properties
            this.height = image.Height;
            this.width = image.Width;            
        }

        MagickImage GetMagickImage()
        {
            if (image != null)
                return image;
            return null;
            //Exception here?
        }

        void SetMagickImage(MagickImage image)
        {
            if (image != null)
            {
                this.image = image;
                SetSize();
            }
        }

        void ReadImageFromUrl()
        {
            //Exception
            image.Read(imageUrl);
            SetSize();
        }

    }
}
