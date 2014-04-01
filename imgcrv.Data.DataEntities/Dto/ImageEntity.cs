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
        int height { get; private set; }
        int width { get; private set; }
        private MagickImage image;
        private string imageUrl;

        public ImageEntity(string imageUrl)
        {
            this.image = new MagickImage(imageUrl);
            SetSize();
        }

        public ImageEntity(MagickImage image, string imageUrl)
        {
            this.image = image;
            SetSize();
        }

        private void SetSize()
        {
            //exception
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
            this.image = image;
        }

        void SetImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
        }

        void ReadImageFromUrl()
        {
            this.image = new MagickImage(imageUrl);
        }

        int GetHeight()
        {
            return height;
        }

        int GetWidth()
        {
            return width;
        }
    }
}
