using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortingVisualizer
{
    public partial class Form1 : Form
    {
        int[] theArray;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            PopulateDropdown();
            
        }

        private void PopulateDropdown()
        {
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).
                Where(x => typeof(ISortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach (string enrty in ClassList) 
            {
                comboBox1.Items.Add(enrty);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            Sort.Enabled = false;
            Reset.Enabled = false;
            comboBox1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();           
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            FillPanel();
        }


        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            FillPanel();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int selected = comboBox1.SelectedIndex;

            switch (selected)
            {
                case 0:
                    ISortEngine sortEngineB = new SortEngineBubble();
                    sortEngineB.doWork(theArray, g, panel1.Height);
                    break;
                case 1:
                    ISortEngine sortEngineM = new SortEngineMerge();
                    sortEngineM.doWork(theArray, g, panel1.Height);
                    break;
                case 2:
                    ISortEngine sortEngineQ = new SortEngineQuick();
                    sortEngineQ.doWork(theArray, g, panel1.Height);
                    break;
                case 3:
                    ISortEngine sortEngineS = new SortEngineSelection();
                    sortEngineS.doWork(theArray, g, panel1.Height);
                    break;
                default:
                    break;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Sort.Enabled = true;
            Reset.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            FillPanel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPanel();
        }

        // Clears & fills the panel with random ints
        private void FillPanel()
        {
            // Create graphics here to account for panel resizing
            g = panel1.CreateGraphics();

            // Clear graphics before showing new array
            g.Clear(Color.Black);

            // Set max values
            int numEntries = panel1.Width;
            int maxVal = panel1.Height;

            // Create array
            theArray = new int[numEntries];

            // Generate random numbers
            Random randNums = new Random();
            for (int i = 0; i < numEntries; i++)
            {
                theArray[i] = randNums.Next(0, maxVal);
            }
            for (int i = 0; i < numEntries; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Green), i, maxVal - theArray[i], 1, maxVal);
            }
        }
    }
}
