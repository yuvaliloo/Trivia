using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Trivia
{
    public class Question
    {
        protected String Q;
        protected String ans1;
        protected String ans2;
        protected String ans3;
        protected String ans4;
        protected char categ;
        protected int correctAns;
        public Question(String Q, String ans1, String ans2, String ans3, String ans4, char categ, int correctAns)
        {
            this.Q = Q;
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.ans4 = ans4;
            this.categ = categ;
            this.correctAns = correctAns;
        }
        public String getQ()
        {
            return this.Q;
        }
        public String getAns1()
        {
            return this.ans1;
        }
        public String getAns2()
        {
            return this.ans2;
        }
        public String getAns3()
        {
            return this.ans3;
        }
        public String getAns4()
        {
            return this.ans4;
        }
        public char getCateg()
        {
            return this.categ;
        }
        public int getCorrectAns()
        {
            return this.correctAns;
        }
    }
}