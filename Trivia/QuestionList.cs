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
    public class QuestionList 
    {
        private int numOfQ;
        private Question[] arr;
        public QuestionList(int num)
        {
            Question Q1, Q2, Q3, Q4;
            this.numOfQ = 0;
            this.arr = new Question[5];
            if (num == 1)
            {
                Q1 = new Question("1+10", "1", "11", "3", "100", 'a', 2);
                Q2 = new Question("20+300+50*2", "400", "350", "20", "420", 'a', 4);
                Q3 = new Question("log10(100000)+log2(4096)", "15", "16", "13", "17", 'a', 2);
                Q4 = new Question("ln(7.38904)", "~2.718", "~14.5", "~10", "~2", 'a', 4);
            }
            else
            {
                Q1 = new Question("element No.1", "O", "F", "C", "H", 'b', 4);
                Q2 = new Question("1 mol", "3*10^23", "6*10^23", "24", "25", 'b', 2);
                Q3 = new Question("Melting temperature of diamond", "2023C°", "300C°", "4027C°", "25C°", 'b', 3);
                Q4 = new Question("S8 + CH2→", "2S2H + S2C", "8S + C+2H", "8CS2 + 8H2S", "F", 'b', 3);
            }
            this.arr[0] = Q1;
            this.arr[1] = Q2;
            this.arr[2] = Q3;
            this.arr[3] = Q4;
        }
        public Question[] GetQuestions()
        {
            return this.arr;
        }
        public int getNumOfQ()
        {
            return this.numOfQ;
        }
    }
}