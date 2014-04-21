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

            imageEnt.height = image.Height;
            imageEnt.width = image.Width;
            return imageEnt;
        }

        public void CarveAndSaveImage(string imageUrl, int height, int width)
        {
            ImageEntity image = MakeImageEntity(imageUrl);

            CarveService.Carve(image, height, width);
            SetSize(image);
            image.GetMagickImage().Write(imageUrl);
        }


        public void SetSize(ImageEntity image)
        {
            image.height = image.GetMagickImage().Height;
            image.width = image.GetMagickImage().Width;
        }

    }
}
