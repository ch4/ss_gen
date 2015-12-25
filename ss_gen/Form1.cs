using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ss_gen {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            string url = textBox4.Text;
            string sessionId = textBox1.Text;
            string result = SSGetNumber(url, sessionId);
            textBox2.Text += result + "\r\n\r\n";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private string SSGetNumber(string backendURI, string sessionId) {

            using (var client = new WebClient()) {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //var data = new {
                //    CardType = "7",
                //    CumulativeLimit = "11.00",
                //    IssuerId = "1",
                //    CPNType = "MA",
                //    VCardId = "3652249",
                //    MsgNo = "5",
                //    Locale = "en",
                //    Request = "GetCPN",
                //    Version = "FLEXWEBCARD-BOFA_4_0_31_0",
                //    SessionId = sessionId,
                //    ValidFor = "2"
                //};
                string data =
                    "CardType=7&CumulativeLimit=26%2E00&IssuerId=1&CPNType=MA&VCardId=3652249&MsgNo=5&Locale=en&Request=GetCPN&Version=FLEXWEBCARD%2DBOFA%5F4%5F0%5F31%5F0&SessionId="+sessionId+"&ValidFor=2";
                var responseString = client.UploadString(backendURI, "POST", data);
                NameValueCollection responseCollection = HttpUtility.ParseQueryString(responseString);

                if (responseCollection["Action"] == "Error") {
                    return "";
                }

                string ccStr = responseCollection["PAN"];
                ccStr = ccStr.Substring(0, 4) + " " + ccStr.Substring(4, 4) + " " + ccStr.Substring(8, 4) + " " +
                        ccStr.Substring(12, 4);
                string expStr = responseCollection["Expiry"];
                string cvvStr = responseCollection["AVV"];
                string result = ccStr + "\r\n" + cvvStr + " " + expStr;

                return result;
            }

            return "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e) {

        }
    }
}
