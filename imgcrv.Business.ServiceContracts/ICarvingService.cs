using System;
namespace imgcrv.Business.ServiceContracts
{
    public interface ICarvingService
    {
        void Carve(imgcrv.Data.DataEntities.Dto.ImageEntity image, int height, int width);
    }
}
