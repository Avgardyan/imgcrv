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
        public ImageHandlerService()
        {
            
        }

        ImageEntity MakeImageEntity(string imageUrl)
        {
            return new ImageEntity(imageUrl);
        }

        ImageEntity CarveImage(ImageEntity image, int height, int width)
        {
            CarvingService CarveService = new CarvingService();
            
            return CarveService.Carve(image, height, width);
        }
    }
}
