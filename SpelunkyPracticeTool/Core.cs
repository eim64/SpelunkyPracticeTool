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

        public void Update()
        {
            //Stupid way of checking whether or not the game restarted
            if(Values.Time.TotalSeconds == 0 && Values.Time.TotalMinutes == 0)
            {

                if (Form.CheckBoxBM.Checked) Values.Level.ForceBM = true;
                if (Form.checkBoxCOG.Checked) Values.Level.ForceCOG = true;
                if (Form.cbCastle.Checked) Values.Level.ForceCastle = true;
                if (Form.cbWorm.Checked) Values.Level.ForceWorm = true;
                if (Form.cbSpaceship.Checked) Values.Level.ForceSpaceship = true;
                if (Form.cbJetpack.Checked) Values.Level.JetPack = true;
                if (Form.cbCape.Checked) Values.Level.Cape = true;
                if (Form.cbVladsCape.Checked) Values.Level.VladCape = true;
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
