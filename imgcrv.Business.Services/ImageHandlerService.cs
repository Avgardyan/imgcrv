using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using imgcrv.Data.DataEntities.Dto;

namespace imgcrv.Business.Services
{
    public class ImageHandlerService
    {
        CarvingService CarveService;

        public ImageHandlerService()
        {
            CarveService = new CarvingService();
        }
        //HTml api

        //Cache service
        private ImageEntity MakeImageEntity(string imageUrl)
        {
            //Jei bus naudojamas saugojimas ne failu sistemoje
            MagickImage image = new MagickImage(imageUrl);

            ImageEntity imageEnt = new ImageEntity(image);

            return imageEnt;
        }

        public Tuple<int, int> ReturnSize(string imageUrl)
        {
            ImageEntity image = MakeImageEntity(imageUrl);
            MagickImage magickImage = image.GetMagickImage();

            return Tuple.Create(magickImage.Height, magickImage.Width);
        }

        public void CarveAndSaveImage(string imageUrl, int height, int width)
        {
            ImageEntity image = MakeImageEntity(imageUrl);

            CarveService.Carve(image, height, width);
            MagickImage magickImage = image.GetMagickImage();

            magickImage.Write(imageUrl);
        }
    }
}