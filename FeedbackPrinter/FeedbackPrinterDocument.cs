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
        public FeedbackDocumentConfig config;

        public FeedbackPrinterDocument(FeedbackData data) : base()
        {
            populateStructs();
            this.data = data;
        }

        private void populateStructs()
        {
            fonts = new FeedbackDocumentFonts();

            fonts.data = new Font("Calibri", 12, FontStyle.Regular);
            fonts.dataDescriptor = new Font("Calibri", 12, FontStyle.Regular);
            fonts.topics = new Font("Calibri", 12, FontStyle.Regular);
            fonts.feedback = new Font("Calibri", 12, FontStyle.Regular);
            fonts.title = new Font("Calibri", 12, FontStyle.Underline);

            config = new FeedbackDocumentConfig();

            config.brush = Brushes.Black;
            config.bulletString = "\u2022";
            config.minimumMRIHeight = 50;
            config.maximumMRIHeight = 200;
            config.padding = 10;
            config.tablePadding = 5;
            config.tableWidth = 1;
        }

        protected override void OnBeginPrint(PrintEventArgs e) //Runs when the page starts printing
        {
            base.OnBeginPrint(e);
        }

        protected override void OnPrintPage(PrintPageEventArgs e) //Runs when the page starts printing
        {
            base.OnPrintPage(e);

            int printHeight = DefaultPageSettings.PaperSize.Height - DefaultPageSettings.Margins.Top - DefaultPageSettings.Margins.Bottom;
            int printWidth = DefaultPageSettings.PaperSize.Width - DefaultPageSettings.Margins.Left - DefaultPageSettings.Margins.Right;

            int leftMargin = DefaultPageSettings.Margins.Left;
            int topMargin = DefaultPageSettings.Margins.Top;

            PointF cursor = new PointF(leftMargin, topMargin); //in essence where I am currently editing
            PointF cornerRectangle;

            SizeF measuredSize; //Used to store the results from measurements of string size
            SizeF totalSize; //Used to store the size of the entire line, used to calculate spacing
            string textToDraw;
            SizeF bulletSize = e.Graphics.MeasureString(config.bulletString, fonts.topics); //The size of the bullet point being used, used to determine spacings,

            #region Printing the faculty name

            textToDraw = data.facultyName;

            measuredSize = e.Graphics.MeasureString(textToDraw, fonts.title, printWidth);

            cursor.X = (DefaultPageSettings.PaperSize.Width - measuredSize.Width) / 2;

            e.Graphics.DrawString(textToDraw, fonts.title, config.brush, new RectangleF(cursor, measuredSize));

            cursor.Y += measuredSize.Height + config.padding;
            cursor.X = leftMargin;

            #endregion

            #region Printing the topic name

            textToDraw = "Topic: " + data.topicName;

            measuredSize = e.Graphics.MeasureString(textToDraw, fonts.title, printWidth);

            cursor.X = (DefaultPageSettings.PaperSize.Width - measuredSize.Width) / 2;

            e.Graphics.DrawString(textToDraw, fonts.title, config.brush, cursor);

            cursor.Y += measuredSize.Height + config.padding;
            cursor.X = leftMargin;

            #endregion

            #region Printing the feedback details

            textToDraw = data.teacherName + " - " + data.topicNote + " / " + data.date.ToString(@"dd\/MM\/yyyy");

            measuredSize = e.Graphics.MeasureString(textToDraw, fonts.title, printWidth);

            cursor.X = (DefaultPageSettings.PaperSize.Width - measuredSize.Width) / 2;

            e.Graphics.DrawString(textToDraw, fonts.title, config.brush, cursor);

            cursor.Y += measuredSize.Height + config.padding;
            cursor.X = leftMargin;

            #endregion

            #region Printing the name line

            totalSize = e.Graphics.MeasureString("Name: ", fonts.dataDescriptor);

            e.Graphics.DrawString("Name: ", fonts.dataDescriptor, config.brush, cursor);

            cursor.X += totalSize.Width;
            totalSize.Height = measuredSize.Height;

            totalSize = e.Graphics.MeasureString(data.studentName, fonts.data);

            e.Graphics.DrawString(data.studentName, fonts.data, config.brush, cursor);

            totalSize.Height = Math.Max(totalSize.Height, measuredSize.Height);

            cursor.X = leftMargin;
            cursor.Y += totalSize.Height + config.padding;

            #endregion

            #region Printing the grades line

            measuredSize = e.Graphics.MeasureString("Target grade: ", fonts.dataDescriptor);
            e.Graphics.DrawString("Target grade: ", fonts.dataDescriptor, config.brush, cursor);
            cursor.X += measuredSize.Width;

            e.Graphics.DrawString(data.targetGrade, fonts.dataDescriptor, config.brush, cursor);
            cursor.X = DefaultPageSettings.PaperSize.Width / 2;

            measuredSize = e.Graphics.MeasureString("Acheived grade: ", fonts.dataDescriptor);
            e.Graphics.DrawString("Acheived grade: ", fonts.dataDescriptor, config.brush, cursor);

            cursor.X += measuredSize.Width;

            e.Graphics.DrawString(data.acheivedGrade, fonts.data, config.brush, cursor);

            cursor.X = leftMargin;
            cursor.Y += Math.Max(fonts.data.Height, fonts.dataDescriptor.Height) + config.padding;

            #endregion

            #region Printing the effort line

            measuredSize = e.Graphics.MeasureString("Effort: ", fonts.dataDescriptor);

            e.Graphics.DrawString("Effort: ", fonts.dataDescriptor, config.brush, cursor);

            cursor.X += measuredSize.Width;

            e.Graphics.DrawString(data.effortGrade, fonts.data, config.brush, cursor);

            cursor.X = leftMargin;
            cursor.Y += Math.Max(fonts.data.Height, fonts.dataDescriptor.Height) + config.padding;

            #endregion

            #region Printing the topics covered

            e.Graphics.DrawString("During this topic you have covered: ", fonts.dataDescriptor, config.brush, cursor);

            cursor.Y += fonts.dataDescriptor.Height + config.padding;

            foreach (string topic in data.topicsCovered)
            {
                e.Graphics.DrawString(config.bulletString, fonts.topics, config.brush, cursor);
                cursor.X += bulletSize.Width;
                measuredSize = e.Graphics.MeasureString(topic, fonts.topics, (int)(printWidth - bulletSize.Width));
                e.Graphics.DrawString(topic, fonts.topics, config.brush, new Rectangle(Point.Round(cursor), new Size((int)(printWidth - bulletSize.Width), DefaultPageSettings.PaperSize.Height)));
                cursor.Y += measuredSize.Height;
                cursor.X = leftMargin;
            }

            cursor.Y += config.padding;

            #endregion

            #region Printing the WWWs

            cornerRectangle = cursor;
            cursor.Y += config.tablePadding;
            cursor.X += config.tablePadding;

            e.Graphics.DrawString("Feedback and strengths (WWW):", fonts.dataDescriptor, config.brush, cursor);
            cursor.Y += fonts.dataDescriptor.Height;
            measuredSize = e.Graphics.MeasureString(data.feedbackWWWs, fonts.feedback, printWidth - 2 * config.tablePadding);
            e.Graphics.DrawString(data.feedbackWWWs, fonts.feedback, config.brush, new RectangleF(cursor, measuredSize));
            cursor.Y += measuredSize.Height + config.tablePadding;

            e.Graphics.DrawRectangle(new Pen(config.brush, config.tableWidth), new Rectangle(Point.Round(cornerRectangle), new Size(printWidth, (int)(cursor.Y - cornerRectangle.Y))));

            cursor.Y += config.padding;
            cursor.X = leftMargin;

            #endregion

            #region Printing the TIFs

            cornerRectangle = cursor;
            cursor.Y += config.tablePadding;
            cursor.X += config.tablePadding;

            e.Graphics.DrawString("To improve further (TIF):", fonts.dataDescriptor, config.brush, cursor);
            cursor.Y += fonts.dataDescriptor.Height;
            measuredSize = e.Graphics.MeasureString(data.feedbackTIFs, fonts.feedback, printWidth - 2 * config.tablePadding);
            e.Graphics.DrawString(data.feedbackTIFs, fonts.feedback, config.brush, new RectangleF(cursor, measuredSize));
            cursor.Y += measuredSize.Height + config.tablePadding;

            e.Graphics.DrawRectangle(new Pen(config.brush, config.tableWidth), new Rectangle(Point.Round(cornerRectangle), new Size(printWidth, (int)(cursor.Y - cornerRectangle.Y))));

            cursor.Y += config.padding;
            cursor.X = leftMargin;

            #endregion

            #region Printing the MRI Box

            measuredSize = new SizeF(printWidth, Math.Min(DefaultPageSettings.PaperSize.Height - DefaultPageSettings.Margins.Bottom - cursor.Y, config.maximumMRIHeight));

            if(DefaultPageSettings.PaperSize.Height - DefaultPageSettings.Margins.Bottom - cursor.Y > config.minimumMRIHeight)
            {
                e.Graphics.DrawString("My Response Is (MRI):", fonts.dataDescriptor, config.brush, PointF.Add(cursor, new Size(config.tablePadding, config.tablePadding)));
                e.Graphics.DrawRectangle(new Pen(config.brush, config.tableWidth), new Rectangle(Point.Round(cursor), Size.Round(measuredSize)));
            }

            #endregion
        }
    }
}