using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FeedbackPrinter
{
    struct FeedBackData
    {
        public string studentName; //The name of the student
        public string topicName;
        public DateTime date;
        public string teacherName;
        public string topicNote;
        public string targetGrade;
        public string acheivedGrade;
        public string effortGrade;
        public string[] topicsCovered;
        public string[] feedbackWWW;
        public string[] feedbackTIF;

    }

    struct Fonts
    {
        public Font titles;
        public Font normal;
        public Font title;
        public Font feedback;
    }
}