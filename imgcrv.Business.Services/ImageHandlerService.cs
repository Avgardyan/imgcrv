using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using imgcrv.Data.DataEntities.Dto;

namespace imgcrv.Business.Services
{
    class ImageHandlerService
    {
        CarvingService CarveService;

        public ImageHandlerService()
        {
            CarveService = new CarvingService();
        }
        //HTml api


        //Cache service
        public ImageEntity MakeImageEntity(string imageUrl)
        {
            //Jei bus naudojamas saugojimas ne failu sistemoje
            MagickImage image = new MagickImage(imageUrl);

            ImageEntity imageEnt = new ImageEntity(image);

            imageEnt.height = image.Height;
            imageEnt.width = image.Width;
            return imageEnt;
        }

        public void CarveImage(ImageEntity image, int height, int width)
        {
            CarveService.Carve(image, height, width);
            SetSize(image);
        }


        public void SetSize(ImageEntity image)
        {
            image.height = image.GetMagickImage().Height;
            image.width = image.GetMagickImage().Width;
        }

    }
}
