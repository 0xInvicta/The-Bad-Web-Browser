using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //This is ran when the user selects the file>exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Program was made by: Mateusz Peplinski", "About");
        }

        //On click this will navigate to the text in the NavBar
        private void button1_Click(object sender, EventArgs e)
        {
            navigateToPage();
        }

        // Core navigate function
        private void navigateToPage()
        {
            toolStripStatusLabel1.Text = "Navigating has Begun";

            button1.Enabled = false;
            textBox1.Enabled = false;
            webBrowser1.Navigate(textBox1.Text);

        }

        //this code will run when a user presses a key when while in the text box 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)ConsoleKey.Enter)
            {
                navigateToPage();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Complete";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if(e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
            
        }
    }
}
