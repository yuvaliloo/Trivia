using Android.Graphics;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
namespace Trivia
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        LinearLayout main;
        TextView finale, tv2;
        Dialog d;
        Button save;
        EditText name;
        RadioButton math, chem;
        Android.Content.Intent intent;
        ISharedPreferences sp;
        int highS=0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            main = (LinearLayout)FindViewById(Resource.Id.main1);
            math = (RadioButton)FindViewById(Resource.Id.math);
            chem = (RadioButton)FindViewById(Resource.Id.chem);
            TextView tv = new TextView(this);
            tv2 = new TextView(this);
            Button start = new Button(this);
            Button hs = new Button(this);
            LinearLayout.LayoutParams LP = new LinearLayout.LayoutParams(300, 150);
            finale = new TextView(this);
            sp=this.GetSharedPreferences("Details", Android.Content.FileCreationMode.Private);
            highS = sp.GetInt("HS", 0);
            start.LayoutParameters = LP;
            start.SetBackgroundColor(Android.Graphics.Color.ParseColor("#31d500"));
            start.Text = "Start";
            hs.LayoutParameters = LP;
            hs.SetBackgroundColor(Android.Graphics.Color.ParseColor("#31d500"));
            hs.Text = "Highscore";
            tv.Text = "Trivia";
            tv.TextSize = 30;
            tv2.TextSize = 30;
            tv2.Text = "Highscore: " + sp.GetString("Name", null) + " - " + sp.GetInt("HS", 0);
            tv2.Visibility = Android.Views.ViewStates.Invisible;
            finale.TextSize = 30;
            finale.Text = "Finale Score: ";
            tv.Gravity = Android.Views.GravityFlags.CenterHorizontal;
            tv2.Gravity = Android.Views.GravityFlags.CenterHorizontal;
            finale.Gravity = Android.Views.GravityFlags.CenterHorizontal;
            main.AddView(tv);
            main.AddView(start);
            main.AddView(finale);
            main.AddView(hs);
            main.AddView(tv2);
            intent = new Android.Content.Intent(this, typeof(GameActivity));
            hs.Click += Hs_Click;
            start.Click += Start_Click;

        }

        private void Hs_Click(object sender, EventArgs e)
        {
            tv2.Text = "Highscore: "+sp.GetString("Name",null)+" - "+sp.GetInt("HS", 0);
            tv2.Visibility = Android.Views.ViewStates.Visible;
        }
        public void createSave()
        {
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.nameSave);
            d.SetTitle("Save name");
            d.SetCancelable(false);
            name = (EditText)d.FindViewById(Resource.Id.name);
            save = (Button)d.FindViewById(Resource.Id.save);
            save.Click += Save_Click;
            d.Show();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            tv2.Visibility = Android.Views.ViewStates.Invisible;
            d.Dismiss();
            if (math.Checked)
                intent.PutExtra("Subjact", "math");
            else
                intent.PutExtra("Subjact", "chem");
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)
            {
                if (resultCode == Result.Ok)
                {
                    int points = data.Extras.GetInt("score");
                    Boolean ifSave = data.Extras.GetBoolean("save?");
                    finale.Text = "Finale Score: "+points;
                    var editor = sp.Edit();
                    if (points > highS && ifSave)
                    {
                        editor.PutInt("HS", points);
                        editor.PutString("Name", name.Text);
                    }
                    editor.Commit();
                }
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            createSave();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}