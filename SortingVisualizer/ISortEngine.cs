using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer
{
    internal interface ISortEngine
    {
        void doWork(int[] theArray, Graphics g, int maxVal);
    }
}
