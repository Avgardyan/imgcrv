using System;
namespace imgcrv.Business.Services
{
    public interface ICarvingService
    {
        void Carve(imgcrv.Data.DataEntities.Dto.ImageEntity image, int height, int width);
    }
}
