using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FeedbackPrinter
{
    public struct FeedbackData
    {
        public string studentName; //The name of the student
        public string topicName; //The name of the topic
        public DateTime date; //The date for the feedback
        public string teacherName; //The name of the teacher
        public string topicNote; //The small amount of text that comes after the teacher
        public string targetGrade; //The target grade of the student
        public string acheivedGrade; //The acheived grade of the student
        public string effortGrade; //The effort grade of the student
        public string[] topicsCovered; //The topics covered in the KMP - it is the bullet points below
        public string[] feedbackWWWs; //The WWWs that need to go in the topmost box
        public string[] feedbackTIFs; //The TIFs that need to go in the middle box

    }

    public struct FeedbackDocumentFonts
    {
        public Font title; //The font used for titles (underlined in the source document)
        public Font data; //The font used for the inputted fata in the feedback
        public Font dataDescriptor; //The font that you would like to use for the names of each piece of data, for example "Name: ", "Target Grade: 
        public Font topics; //The font that is used for the topics covered section.
        public Font feedback; //The font that is used for the feedback inside the boxes
        public Font teacher; //The font used for the teacher (underlined and bold in the source document)
    }
}