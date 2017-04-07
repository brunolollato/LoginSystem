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

namespace LoginSystem
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }

    class DialogSignUp : DialogFragment
    {
        private EditText mFirstName;
        private EditText mEmail;
        private EditText mPassword;
        private Button mDialogSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            
            mFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mDialogSignUp = view.FindViewById<Button>(Resource.Id.btnDialogSignUp);

            mDialogSignUp.Click += MDialogSignUp_Click;

            return view;
        }

        private void MDialogSignUp_Click(object sender, EventArgs e)
        {
            //User has clicked to sign up button.
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mFirstName.Text, mEmail.Text, mPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//Set the tittle bar invisible.
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//Set the animation.
        }
    }
}