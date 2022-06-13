using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge_Detector.Detectors
{
    internal interface Detector
    {
        Bitmap Detect();
    }
}
