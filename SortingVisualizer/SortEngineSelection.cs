using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer
{
    internal class SortEngineSelection : ISortEngine
    {
        Graphics g;
        Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void doWork(int[] theArray, Graphics g, int maxVal)
        {
            this.g = g;

            for (int i = 1; i < theArray.Length - 1; i++)
            {
                int swapValue = i;

                for (int j = i + 1; j < theArray.Length; j++)
                {
                    if (theArray[j] < theArray[swapValue])
                    {
                        swapValue = j;
                    }
                }

                Swap(swapValue, theArray, i, maxVal);

            }
        }

        public void Swap(int swapValue, int[] theArray, int i, int maxVal)
        {
            int tempValue = theArray[swapValue];
            theArray[swapValue] = theArray[i];
            theArray[i] = tempValue;

            // Fill old values
            g.FillRectangle(BlackBrush, swapValue, 0, 1, maxVal);
            g.FillRectangle(BlackBrush, i, 0, 1, maxVal);

            // Draw new values
            g.FillRectangle(GreenBrush, swapValue, maxVal - theArray[swapValue], 1, maxVal);
            g.FillRectangle(GreenBrush, i, maxVal - theArray[i], 1, maxVal);
        }
    }
}
