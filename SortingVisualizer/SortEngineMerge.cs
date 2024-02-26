using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer
{
    internal class SortEngineMerge : ISortEngine
    {
        Graphics g;
        Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void doWork(int[] theArray, Graphics g, int maxVal)
        {
            this.g = g;

            Sort(theArray, 0, theArray.Length - 1, maxVal);
        }

        public void Sort(int[] theArray, int left, int right, int maxVal)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                Sort(theArray, left, mid, maxVal);
                Sort(theArray, mid + 1, right, maxVal);

                Merge(theArray, left, mid, right, maxVal);
            }
        }

        public void Merge(int[] theArray, int left, int mid, int right, int maxVal)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create two temp arrays
            int[] l = new int[n1];
            int[] r = new int[n2];

            // Copy data to temp arrays
            for (int i = 0; i < n1; i++)
            {
                l[i] = theArray[left + i];
            }
            for (int j = 0; j < n2; j++)
            {
                r[j] = theArray[mid + 1 + j];
            }

            // Merge the temp arrays back into the array
            int k = left;
            int x = 0, y = 0;
            while (x < n1 && y < n2)
            {
                if (l[x] <= r[y])
                {
                    // Fill old value
                    g.FillRectangle(BlackBrush, k, 0, 1, maxVal);

                    theArray[k] = l[x];
                    x++;
                }
                else
                {
                    // Fill old value
                    g.FillRectangle(BlackBrush, k, 0, 1, maxVal);

                    theArray[k] = r[y];
                    y++;
                }
                k++;
            }

            // Copy the remaining elements of l[]
            while (x < n1)
            {
                // Fill old value
                g.FillRectangle(BlackBrush, k, 0, 1, maxVal);

                theArray[k] = l[x];
                x++;
                k++;
            }

            // copy the remaining elements of r[]
            while (y < n2)
            {
                // Fill old value
                g.FillRectangle(BlackBrush, k, 0, 1, maxVal);

                theArray[k] = r[y];
                y++;
                k++;
            }

            for (int i = 0; i < theArray.Length - 1; i++)
            {
                g.FillRectangle(GreenBrush, i, maxVal - theArray[i], 1, maxVal);
            }
        }
    }
}
