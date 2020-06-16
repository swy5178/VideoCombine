using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCombine
{
    public class VideoInfo
    {
        public string VideoPath { get; set; }
        public string VideoName { get; set; }
        public Image VideoImage { get; set; }
        public string VideoFormat { get; set; }
        public string VideoDuration { get; set; }
        public string VideoResolution { get; set; }
    }
}
