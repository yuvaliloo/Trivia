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
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        Button a1, a2, a3, a4, fin,ok;
        TextView Q, stat, pts, correct;
        LinearLayout LL;
        Question Qu;
        QuestionList QL;
        int current=0, score = 0;
        Intent i;
        ISharedPreferences sp;
        AlertDialog AD;
        Dialog d;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.GameLayout);
            // Create your application here
            a1 = (Button)FindViewById(Resource.Id.btna1);
            a2 = (Button)FindViewById(Resource.Id.btna2);
            a3 = (Button)FindViewById(Resource.Id.btna3);
            a4 = (Button)FindViewById(Resource.Id.btna4);
            Q = (TextView)FindViewById(Resource.Id.tvQ);
            stat = (TextView)FindViewById(Resource.Id.tvStatus);
            fin = (Button)FindViewById(Resource.Id.tvFinish);
            pts = (TextView)FindViewById(Resource.Id.tvPoints);
            LL = (LinearLayout)FindViewById(Resource.Id.main2);
            nextQuestion();
            a1.Click += A1_Click;
            a2.Click += A2_Click;
            a3.Click += A3_Click;
            a4.Click += A4_Click;
            fin.Click += Fin_Click;
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)
            {
                if (resultCode == Result.Ok)
                {
                    String s = data.Extras.GetString("Subjact");
                    if (s.Equals("math"))
                        QL = new QuestionList(1);
                    else
                        QL = new QuestionList(2);
                }
            }
        }
                    private void Fin_Click(object sender, EventArgs e)
        {
            createDialog();
        }
        public void createDialog()
        {
            AlertDialog.Builder b = new AlertDialog.Builder(this);
            b.SetTitle("in case u broke the last record, would u like to save your score?");
            b.SetCancelable(false);
            b.SetPositiveButton("Yes", OkAction);
            b.SetNegativeButton("No", CancelAction);
            AD = b.Create();
            AD.Show();
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            i = new Intent(this, typeof(MainActivity));
            i.PutExtra("score", score);
            i.PutExtra("save?", false);
            SetResult(Result.Ok, i);
            AD.Dismiss();
            Finish();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            i = new Intent(this, typeof(MainActivity));
            i.PutExtra("score", score);
            i.PutExtra("save?", true);
            SetResult(Result.Ok, i);
            AD.Dismiss();
            Finish();
        }
        public void createCorrect()
        {
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.correct);
            d.SetTitle("Correct Answer");
            d.SetCancelable(false);
            ok = (Button)d.FindViewById(Resource.Id.k);
            correct = (TextView)d.FindViewById(Resource.Id.cor);
            correct.Text = "" + Qu.getCorrectAns();
            ok.Click += Ok_Click;
            d.Show();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            d.Dismiss();
            nextQuestion();
        }

        private void A4_Click(object sender, EventArgs e)
        {
            if (current < 5)
            {
                if (Qu.getCorrectAns() == 4)
                {
                    score += current;
                    nextQuestion();
                }
                else
                {
                    createCorrect();
                }
                pts.Text = "points: "+score;
            }
        }

        private void A3_Click(object sender, EventArgs e)
        {
            if (current < 5)
            {
                if (Qu.getCorrectAns() == 3)
                {
                    score += current;
                    nextQuestion();
                }
                else
                {
                    createCorrect();
                }
                pts.Text = "points: " + score;
            }
        }

        private void A2_Click(object sender, EventArgs e)
        {
            if (current < 5)
            {
                if (Qu.getCorrectAns() == 2)
                {
                    score += current;
                    nextQuestion();
                }
                else
                {
                    createCorrect();
                }
                pts.Text = "points: " + score;
            }
        }

        private void A1_Click(object sender, EventArgs e)
        {
            if (current < 5)
            {
                if (Qu.getCorrectAns() == 1)
                {
                    score += current;
                    nextQuestion();
                }
                else
                {
                    createCorrect();
                }
                pts.Text = "points: " + score;
            }
        }

        public void nextQuestion()
        {
            Qu = QL.GetQuestions()[current];
            if (current < 4)
            {
                Q.Text = Qu.getQ();
                a1.Text = Qu.getAns1();
                a2.Text = Qu.getAns2();
                a3.Text = Qu.getAns3();
                a4.Text = Qu.getAns4();
                stat.Text = "Question number: "+(current+1);
            }
            else
                fin.Visibility = Android.Views.ViewStates.Visible;
            current++;
        }
    }
}