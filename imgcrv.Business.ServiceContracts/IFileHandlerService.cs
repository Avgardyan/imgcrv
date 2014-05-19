using System;
namespace imgcrv.Business.ServiceContracts
{
    public interface IFileHandlerService
    {
        string GenerateRandomNameAddExtention(string extention);
        string GetAllAttributes();
        string GetCarvedUploadLocation();
        string GetOrigninalUploadLocation();
    }
}
