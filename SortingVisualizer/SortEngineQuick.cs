using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer
{
    internal class SortEngineQuick : ISortEngine
    {
        int maxVal;
        Graphics g;
        Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void doWork(int[] theArray, Graphics g, int maxVal)
        {
            this.g = g;
            this.maxVal = maxVal;

            Sort(theArray, 0, theArray.Length - 1);
            
        }

        public void Sort(int[] theArray, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(theArray, low, high);

                Sort(theArray, low, partitionIndex - 1);
                Sort(theArray, partitionIndex + 1, high);
            }
        }

        public int Partition(int[] theArray, int low, int high)
        {
            int pivot = theArray[high];

            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (theArray[j] < pivot)
                {
                    i++;
                    Swap(theArray, i, j);
                }
            }
            Swap(theArray, i + 1, high);
            return (i + 1);
        }

        public void Swap(int[] theArray, int i, int j)
        {
            int temp = theArray[i];
            theArray[i] = theArray[j];
            theArray[j] = temp;

            // Fill old values
            g.FillRectangle(BlackBrush, i, 0, 1, maxVal);
            g.FillRectangle(BlackBrush, j, 0, 1, maxVal);

            // Draw new values
            g.FillRectangle(GreenBrush, i, maxVal - theArray[i], 1, maxVal);
            g.FillRectangle(GreenBrush, j, maxVal - theArray[j], 1, maxVal);

        }
    }
}
