using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using Android.Views;

namespace LoginSystem
{
    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
        private Button btnSignUp;
        private ProgressBar progBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            progBar = FindViewById<ProgressBar>(Resource.Id.progBar);

            btnSignUp.Click += (object sender, EventArgs args) =>
            {
                //Pull up Dialog Sign Up
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignUp SignUpDialog = new DialogSignUp();
                SignUpDialog.Show(transaction, "Dialog Fragment");

                SignUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;
            };
        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            progBar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeRequest);
            thread.Start();
        }
        private void ActLikeRequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { progBar.Visibility = ViewStates.Invisible; });
        }
    }
}

