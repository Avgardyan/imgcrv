using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Collections;

namespace imgcrv.Business.Services
{
    public class FileHandlerService
    {
        //Add error checks to see if config file is OK
        private string symbols = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
        private int symbolsLength = 60;
        private int nameLength = 6;
        private string originalUploadDir = @"D:\imgcrvImages\Original";
        private string carvedUploadDir = @"D:\imgcrvImages\Carved";
        string attributeTestString = "";

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        public FileHandlerService()
        {
            SetSettings();
        }

        private void SetSettings()
        {
            string attribute;

            attribute = ConfigurationManager.AppSettings.Get("FileNameAvailableCharacters");
            if (attribute != "")
            {
                symbols = attribute;
            }

            attribute = ConfigurationManager.AppSettings.Get("FileNameLength");
            int tempLength;
            int.TryParse(attribute, out tempLength);
            if (tempLength != 0)
            {
                nameLength = tempLength;
            }

            attribute = ConfigurationManager.AppSettings.Get("OriginalImageSaveLocation");
            if (attribute != "")
            {
                if (Directory.Exists(attribute))
                {
                    originalUploadDir = attribute;
                }
            }

            attribute = ConfigurationManager.AppSettings.Get("CarvedImageSaveLocation");
            if (attribute != "")
            {
                if (Directory.Exists(attribute))
                {
                    carvedUploadDir = attribute;
                }
            }

            NameValueCollection sAll ;
            sAll = ConfigurationManager.AppSettings;

            foreach (string s in sAll.AllKeys)
                attributeTestString = attributeTestString + " Key: " + s + " Value: " + sAll.Get(s) + " ";
        }

        public string GenerateRandomNameAddExtention(string extention)
        {
            int i = 0;
            string name;
            do
            {
                name = "";
                for (i = 0; i < nameLength; i++)
                {
                    name += symbols[GetRandomNumber(0, symbolsLength)];
                }
            }
            while (FileExists(name + extention));
            return name + extention;
        }

        bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string GetOrigninalUploadLocation()
        {
            return originalUploadDir;
        }

        public string GetCarvedUploadLocation()
        {
            return carvedUploadDir;
        }

        public string GetAllAttributes()
        {
            return attributeTestString;
        }
    }
}
