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
    public partial class entity_list : Form
    {
        public entity_list()
        {
            InitializeComponent();
        }

        private void fetchlistbutton_Click(object sender, EventArgs e)
        {
            Tree.Nodes.Clear();
            if (Memory.Process == null || Memory.Process.HasExited) return;

            int address = Memory.getPointerAddress(Memory.BaseAddress + 0x1384B4, 0x30,0);
            int ptr;

            while ((ptr = Memory.ReadInt32(address)) != 0)
            {
                Tree.Nodes.Add(ptr.ToString("X")+" - "+Memory.ReadInt32(ptr+0xC));

                address += 4;
            }
        }
    }
}
