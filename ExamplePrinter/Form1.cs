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
        private FeedbackData data, data1;

        public Form1()
        {
            InitializeComponent();

            data = new FeedbackData();
            data.acheivedGrade = "A*"; //populate the struct
            data.date = DateTime.Now;
            data.effortGrade = "1";
            data.feedbackTIFs = "TIFLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ut hendrerit enim. Mauris facilisis vitae lacus in tempor. Cras non elit nec purus tincidunt imperdiet et a justo. " + Environment.NewLine + " Fusce tellus neque, vehicula et efficitur ut, ullamcorper ac eros. Morbi congue consectetur luctus. Nullam vel erat commodo, venenatis tellus vitae, tincidunt metus. Aenean imperdiet facilisis ante non venenatis. Pellentesque vel auctor sem.";
            data.feedbackWWWs = "WWWLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ut hendrerit enim. Mauris facilisis vitae lacus in tempor. Cras non elit nec purus tincidunt imperdiet et a justo. " + Environment.NewLine + " Fusce tellus neque, vehicula et efficitur ut, ullamcorper ac eros. Morbi congue consectetur luctus. Nullam vel erat commodo, venenatis tellus vitae, tincidunt metus. Aenean imperdiet facilisis ante non venenatis. Pellentesque vel auctor sem.";
            data.studentName = "John Smith";
            data.targetGrade = "B";
            data.teacherName = "Mr Paffley";
            data.topicName = "Binary addition";
            data.topicNote = "Test 3 of 5";
            data.topicsCovered = new string[] { "Binary addition of signed integers", "Binary addition of unsigned integers", "Converting between binary and denary" };
            data.facultyName = "Faculty of Business and Computing";

            data1 = new FeedbackData();
            data1.acheivedGrade = "B"; //populate the struct
            data1.date = DateTime.Now;
            data1.effortGrade = "2";
            data1.feedbackTIFs = "TIFLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ut hendrerit enim. Mauris facilisis vitae lacus in tempor. Cras non elit nec purus tincidunt imperdiet et a justo. " + Environment.NewLine + " Fusce tellus neque, vehicula et efficitur ut, ullamcorper ac eros. Morbi congue consectetur luctus. Nullam vel erat commodo, venenatis tellus vitae, tincidunt metus. Aenean imperdiet facilisis ante non venenatis. Pellentesque vel auctor sem.";
            data1.feedbackWWWs = "WWWLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ut hendrerit enim. Mauris facilisis vitae lacus in tempor. Cras non elit nec purus tincidunt imperdiet et a justo. " + Environment.NewLine + " Fusce tellus neque, vehicula et efficitur ut, ullamcorper ac eros. Morbi congue consectetur luctus. Nullam vel erat commodo, venenatis tellus vitae, tincidunt metus. Aenean imperdiet facilisis ante non venenatis. Pellentesque vel auctor sem.";
            data1.studentName = "Jack Smith";
            data1.targetGrade = "B";
            data1.teacherName = "Mr Paffley";
            data1.topicName = "Binary addition";
            data1.topicNote = "Test 4 of 5";
            data1.topicsCovered = new string[] { "Binary addition of signed integers", "Binary addition of unsigned integers", "Converting between binary and denary" };
            data1.facultyName = "Faculty of Business and Computing";
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK) //Runs the printer dialog and checks if the user pressed "OK" before printing
            {
                FeedbackPrinterDocument print;
                if (checkBoxMultiple.Checked)
                {
                    FeedbackData[] dataArray = { data, data1 };
                    print = new FeedbackPrinterDocument(dataArray);
                }
                else
                {
                    print = new FeedbackPrinterDocument(data);
                }

                print.PrinterSettings = printDialog.PrinterSettings;
                print.Print();

                this.Close();
            }
        }
    }
}
