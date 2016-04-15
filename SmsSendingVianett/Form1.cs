using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmsSendingVianett
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var web = new System.Net.WebClient())
            {
                try
                {
                    string userName = txtUserName.Text;
                    string userPassword = txtUserPassword.Text;
                    string msgRecepient = txtPhNumber.Text;
                    string msgText = txtMessage.Text;
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src="+msgRecepient +
                        "&dst="+msgRecepient +
                        "&msg="+System.Web.HttpUtility.UrlEncode(msgText,System.Text.Encoding.GetEncoding("ISO-8859-1")) +
                        "&username=" + System.Web.HttpUtility.UrlEncode(userName) +
                        "&password="+userPassword;
                    string result = web.DownloadString(url);
                    if(result.Contains("OK")){
                        MessageBox.Show("Sms sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else{
                        MessageBox.Show("Some issue delivering","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    }
}
