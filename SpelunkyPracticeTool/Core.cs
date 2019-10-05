using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpelunkyPracticeTool
{
    class Core
    {
        

        public Form1 Form;
        public Core(Form1 form)
        {
            Form = form;
        }
        int TutorialTime = 0;
        int PreviousState = 0;

        public void Update()
        {

            //checking whether or not it's currently the tutorial
            Memory.WriteInt(0, Memory.BaseAddress + 0x1384B4, 0x440629);
            

            if(Values.Level.CurrentState == 26)
            {
                if (Form.TutorialWindow.WindowState == FormWindowState.Minimized)
                    Form.TutorialWindow.Focus();

                Form.TutorialWindow.WindowState = FormWindowState.Normal;

                if (TutorialTime == 0)
                {
                    Values.Player.Bombs = Form.TutorialBombs;
                    Values.Player.Ropes = Form.TutorialRopes;
                    Values.Player.HP = Form.TutorialHP;
                }

                TutorialTime += Form.StatusTimer.Interval;

                if (Form.TutorialTimer)
                {
                    Values.Time.TotalMilliseconds = TutorialTime % 1000;
                    Values.Time.TotalSeconds = (TutorialTime / 1000) % 60;
                    Values.Time.TotalMinutes = ((TutorialTime / 1000) / 60);
                }

                PreviousState = Values.Level.CurrentState;
                return;
            }

            if (PreviousState == 26)
            {
                if (Values.Level.CurrentState == 3)
                {
                    Values.Level.CurrentLevel = Form.TutorialLevel - (Memory.ReadBool(Memory.BaseAddress + 0x1384B4, 0x4405CE) ? 0 : 1);
                    Memory.WriteInt(777, Memory.BaseAddress + 0x1384B4, 0xC0);
                }
            }

            //Loading Screen
            if (Values.Level.CurrentState == 1)
            {
                TutorialTime = 0;
            }


            PreviousState = Values.Level.CurrentState;

            //Stupid way of checking whether or not the game restarted
            if(Values.Time.TotalMilliseconds == 0 && Values.Time.TotalSeconds == 0 && Values.Time.TotalMinutes == 0)
            {

                if (Form.CheckBoxBM.Checked) Values.Level.ForceBM = true;
                if (Form.checkBoxCOG.Checked) Values.Level.ForceCOG = true;
                if (Form.cbCastle.Checked) Values.Level.ForceCastle = true;
                if (Form.cbWorm.Checked) Values.Level.ForceWorm = true;
                if (Form.cbSpaceship.Checked) Values.Level.ForceSpaceship = true;
                if (Form.cbJetpack.Checked) Values.Level.JetPack = true;
                if (Form.cbCape.Checked) Values.Level.Cape = true;
                if (Form.cbVladsCape.Checked) Values.Level.VladCape = true;
                if (Form.cbSA.Checked) Values.Level.ShopkeeperAggro = true;
                if (Form.cbAN2.Checked) Values.Level.AnubisAggro = true;
                if (Form.cbLookdown.Checked) Values.Camera.LookdownSpeed = 1;
                if (Form.CustomLevelStart) Values.Level.CurrentLevel = Form.StartLevel;

                Values.Player.HP = (int)Form.nmHP.Value;
                Values.Player.Bombs = (int)Form.nmBombs.Value;
                Values.Player.Ropes = (int)Form.nmRopes.Value;

                foreach(Control ctr in Form.ItemBox.Controls)
                {
                    var ctrl = ctr as CheckBox;
                    if (ctrl == null || !ctrl.Checked) continue;

                    Items n;
                    if(Enum.TryParse(ctrl.Text.Replace(" ", "").ToLower(),out n))
                        Values.Player.EquipItem(n);
                }

                if(Form.HoldItem.SelectedIndex > 0)
                    Values.Player.HoldItem = (int)Enum.Parse(typeof(Holdables),(string)Form.HoldItem.SelectedItem);
            }

        }

    }
}
