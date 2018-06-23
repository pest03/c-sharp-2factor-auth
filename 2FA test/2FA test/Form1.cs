using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Diagnostics;
using Google.Authenticator;


namespace _2FA_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            var setupInfo = tfa.GenerateSetupCode("google_auth_test", "Just a test", "secretkey", 300, 300); //the width and height of the Qr Code in pixels

            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl; //  assigning the Qr code information + URL to string
            string manualEntrySetupCode = setupInfo.ManualEntryKey; // show the Manual Entry Key for the users that don't have app or phone
            Process.Start(qrCodeImageUrl);// showing the qr code on the page "linking the string to image element"
            textBox1.Text = manualEntrySetupCode; // showing the manual Entry setup code for the users that can not use their phone
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user_enter = textBox2.Text;
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isCorrectPIN = tfa.ValidateTwoFactorPIN("secretkey", user_enter);
            if (isCorrectPIN == true)
            {
                MessageBox.Show("Passed");

            }
            else
            {

                MessageBox.Show("nah bro");
            }
        }
    }
}
