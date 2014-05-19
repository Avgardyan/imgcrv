using System;
namespace imgcrv.Business.ServiceContracts
{
    public interface IImageHandlerService
    {
        void CarveAndSaveImage(string imageUrl, int height, int width);
        void ResetCarvedToOriginal(string originalUrl, string carvedUrl);
        Tuple<int, int> ReturnSize(string imageUrl);
    }
}
