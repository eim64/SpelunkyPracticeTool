using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpelunkyPracticeTool
{
    public partial class TutorialPractice : Form
    {
        public TutorialPractice()
        {
            InitializeComponent();
        }

        private void TutorialPractice_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }
    }
}
