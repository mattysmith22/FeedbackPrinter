using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace FeedbackPrinter
{
    public class FeedbackPrinterDocument : PrintDocument
    {
        private FeedbackData data;
        public FeedbackDocumentFonts fonts;

        public FeedbackPrinterDocument(FeedbackData data) : base()
        {
            generateFonts();
            this.data = data;
        }

        private void generateFonts()
        {
            fonts = new FeedbackDocumentFonts();

            fonts.data = new Font("Calibri", 12, FontStyle.Regular);
            fonts.dataDescriptor = new Font("Calibri", 12, FontStyle.Regular);
            fonts.topics = new Font("Calibri", 12, FontStyle.Regular);
            fonts.feedback = new Font("Calibri", 12, FontStyle.Regular);
            fonts.teacher = new Font("Calibri", 12, FontStyle.Underline | FontStyle.Bold);
        }

        protected override void OnBeginPrint(PrintEventArgs e) //Runs when the page starts printing
        {
            base.OnBeginPrint(e);
        }

        protected override void OnPrintPage(PrintPageEventArgs e) //Runs when the page starts printing
        {
            base.OnPrintPage(e);
        }
    }
}