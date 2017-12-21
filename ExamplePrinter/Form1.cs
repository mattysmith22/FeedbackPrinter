using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FeedbackPrinter; //You need to import it in references. It is on the "Projects" tab on the left

namespace ExamplePrinter
{
    public partial class Form1 : Form
    {
        private FeedbackData data;

        public Form1()
        {
            InitializeComponent();

            data = new FeedbackData();
            data.acheivedGrade = "..."; //populate the struct
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if(printDialog.ShowDialog() == DialogResult.OK) //Runs the printer dialog and checks if the user pressed "OK" before printing
            {
                FeedbackPrinterDocument print = new FeedbackPrinterDocument(data);
                print.PrinterSettings = printDialog.PrinterSettings;
                print.Print();
            }
        }
    }
}
