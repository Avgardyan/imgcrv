using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imgcrv.Presentation.Web.Models
{
    public class CarveViewModel
    {
        public string imageName { get; set; }
        public string originalPath { get; set; }
        public string carvedPath { get; set; }
        public string displayPath { get; set; }

        
        public int imageHeight { get; set; }
        public int imageWidth { get; set; }
    }
}