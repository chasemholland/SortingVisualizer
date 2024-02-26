using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SortingVisualizer
{
    internal class SortEngineBubble : ISortEngine
    {
        private int[] theArray;
        private Graphics g;
        private int maxVal;
        private bool _sorted = false;
        Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void doWork(int[] theArray, Graphics g, int maxVal)
        {
            this.theArray = theArray;
            this.g = g;
            this.maxVal = maxVal;

            while (!_sorted)
            {
                for (int i = 0; i < theArray.Count() - 1; i++)
                {
                    if (theArray[i] > theArray[i + 1])
                    {
                        Swap(i, i + 1);
                    }
                }
                _sorted = IsSorted();
            }
        }

        private void Swap(int i, int p)
        {
            int temp = theArray[i];
            theArray[i] = theArray[i + 1];
            theArray[i + 1] = temp;

            // Remove values from visual array
            g.FillRectangle(BlackBrush, i, 0, 1, maxVal);
            g.FillRectangle(BlackBrush, p, 0, 1, maxVal);


            // Show values in visual array
            g.FillRectangle(GreenBrush, i, maxVal - theArray[i], 1, maxVal);
            g.FillRectangle(GreenBrush, p, maxVal - theArray[p], 1, maxVal);

        }

        public bool IsSorted()
        {
            for (int i = 0; i < theArray.Count() - 1; i++)
            {
                if (theArray[i] > theArray[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
