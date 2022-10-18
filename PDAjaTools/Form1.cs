using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDAjaTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            var Output = Encryptor.Encrypt(rtb_input.Text);
            rtb_output.Text = Output;
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            var Output = Encryptor.Decrypt(rtb_input.Text);
            rtb_output.Text = Output;
        }
    }
}
