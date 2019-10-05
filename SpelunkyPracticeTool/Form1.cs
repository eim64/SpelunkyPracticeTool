using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpelunkyPracticeTool
{

    enum Items
    {
        ankh = 124,
		bookofthedead = 123,
		hejet = 121,
		udjateye = 122,
		climbinggloves = 115,
		compass = 112,
		crysknife = 128,
		kapala = 120,
		parachute = 113,
		paste = 125,
		pitchersmitt = 116,
		spectacles = 119,
		spikeshoes = 118,
		springshoes = 117,
		vladsamulet = 129
	};

    enum Holdables
    {
        Mine = 92,
        Rock = 112,
        Pot = 113,
        Skull = 114,
        Boulder = 120,
        Arrow = 122,
        Gold_Key = 154,
        Lamp = 162,
        Snow_Ball = 164,
        Broken_Mattock = 210,
        Broken_Arrow = 216,
        Unlit_Torch = 246,
        Eggplant = 252,
        Mattock = 510,
        Boomerang = 511,
        Machete = 512,
        Web_Gun = 514,
        Shotgun = 515,
        Freeze_Ray = 516,
        Plasma_Cannon = 517,
        Camera = 518,
        Teleporter = 519,
        Cape = 521,
        Jetpack = 522,
        Shield = 523,
        Scepter = 530,
    }

    public partial class Form1 : Form
    {
        Core core;

        entity_list entlist;
        public TutorialPractice TutorialWindow;

        public int TutorialBombs { get { return (int)TutorialWindow.nmBombs.Value; } }
        public int TutorialRopes { get { return (int)TutorialWindow.nmRopes.Value; } }
        public int TutorialHP { get { return (int)TutorialWindow.nmHP.Value; } }
        public int TutorialLevel { get { return (int)TutorialWindow.nmLevel.Value; } }

        public bool TutorialTimer { get { return TutorialWindow.cbTimer.Checked; } }

        public bool CustomLevelStart;
        public int StartLevel = 1;

        const int WaitInterval = 500;
        const int ActiveInterval = 16;

        public Form1()
        {
            InitializeComponent();
            core = new Core(this);
            TutorialWindow = new TutorialPractice();
            TutorialWindow.Show();
        }

        public Process FindProcess()
        {
            return Process.GetProcessesByName("Spelunky").FirstOrDefault();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Holdables)))
                HoldItem.Items.Add(item.ToString());
            HoldItem.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Memory.CloseHandle();

            if (entlist?.IsDisposed == false)
                entlist.Close();
        }


        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if(Memory.Process == null || Memory.Process.HasExited)
            {
                StatusTimer.Interval = WaitInterval;
                statusLbl.Text = "Status: Can't find process";

                Memory.LoadProcess(FindProcess());

                return;
            }

            if (StatusTimer.Interval == WaitInterval)
            {
                statusLbl.Text = "Status: Found process";
                StatusTimer.Interval = ActiveInterval;
            }

            core.Update();
        }

        private void CheckBoxBM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLevel_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LevelStart_CheckChanged(object sender, EventArgs e)
        {
            CustomLevelStart = textBoxLevel.Enabled = checkBoxStart.Checked;
        }

        private void textBoxLevel_Enter(object sender, EventArgs e)
        {
            textBoxLevel.Text = "_ - _";
            num1 = num2 = -1;
        }

        int num1 = -1, num2 = -1;

        private void textBoxLevel_Leave(object sender, EventArgs e)
        {
            if(num2 < 0 || num1 < 0)
            {
                textBoxLevel.Text = "1 - 1";
                StartLevel = 1;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxLevel_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void statusLbl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(entlist == null || entlist.IsDisposed)
                entlist = new entity_list();

            entlist.Show();
            entlist.Focus();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void cbStartLevel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBoxLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar)) return;

            var n = (int)Char.GetNumericValue(e.KeyChar);
            if (n > 5) return;

            if (textBoxLevel.Text[0] == '_')
            {
                num1 = n;
            }
            else if (n < 5)
            {
                num2 = n;
                StartLevel = ((num1-1)*4) + num2;
                statusLbl.Focus();
            }

            textBoxLevel.Text = (num1 < 0 ? "_" : num1.ToString())+" - "+ (num2 < 0 ? "_" : num2.ToString());
        }
    }
}
