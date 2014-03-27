using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace imgcrv.Business.Services
{
    class ImageHandlerService
    {
        private string imageUrl { get; private set; }
        private double imageWidth;
        private double imageHeight;

        struct percentages
        {
            public double width;
            public double height;
        }

        public ImageHandlerService(string imageUrl)
        {
            this.imageUrl = imageUrl;
            Initialize();
        }

        private void Initialize()
        {
            using (MagickImage image = new MagickImage(imageUrl))
            {
                imageWidth = image.BaseWidth;
                imageHeight = image.BaseHeight;
            }
        }

        private percentages PixelsToPercentages(int widthPixels, int heightPixels)
        {
            percentages percs = new percentages();
            percs.width = imageWidth / widthPixels;
            percs.height = imageHeight / heightPixels;

            return percs;
        }

        

        bool CarveImage(int widthPixels, int heightPixels)
        {
            if (widthPixels > 0 && heightPixels > 0)
            {
                percentages percs = new percentages();
                percs = PixelsToPercentages(widthPixels, heightPixels);
                CarveImage(percs.width, percs.height);
            }
            return false;
        }

        bool CarveImage(double widthPercent, double heightPercent)
        {
            if (widthPercent > 0 && heightPercent > 0)
            {
                using (MagickImage image = new MagickImage())
                {
                    image.LiquidRescale(new MagickGeometry(widthPercent, heightPercent));
                    
                }
            }
            return false;
        }
    }
}
