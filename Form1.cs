using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicoDucky
{
    public partial class Form1 : Form
    {
        GlobalHook globalHook;

        public Form1()
        {
            InitializeComponent();
            globalHook = new GlobalHook(this);
            globalHook.SubscribeGlobal();
            FormClosing += Main_Closing;
        }

        private void Main_Closing(object sender, CancelEventArgs e)
        {
            globalHook.Unsubscribe();
        }
    }
}
