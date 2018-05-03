using Android.App;
using Android.Widget;
using Android.OS;

namespace WorldCup2018
{
    [Activity(Label = "WorldCup2018", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ImageView imgGrupos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            imgGrupos = FindViewById<ImageView>(Resource.Id.imageViewGrupo);
            imgGrupos.Click += ImgGrupos_Click;
        }

        private void ImgGrupos_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(GruposActivity));
        }
    }
}

