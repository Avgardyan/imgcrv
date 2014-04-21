using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imgcrv.Business.Services
{
    public class FileHandlerService
    {
        const string symbols = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
        const int symbolsLength = 60;
        const int nameLength = 6;

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

        public string GenerateRandomName()
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
            while (FileExists(name));
            return name;
        }

        bool FileExists(string nameUrl)
        {
            // 0 - doesn't exist, 1 - does exist
            return false;
        }


    }
}
