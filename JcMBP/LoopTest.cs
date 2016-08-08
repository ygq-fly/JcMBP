using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class LoopTest : Form
    {
        ClsUpLoad cul;
        public LoopTest(ClsUpLoad cul)
        {
            InitializeComponent();
            this.cul = cul;
        }

        private void LoopTest_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < cul.BandNames.Count; i++)
			{
                checkedListBox1.Items.Add(cul.BandNames[i] + "A");
                checkedListBox1.Items.Add(cul.BandNames[i] + "B");
			}

        }
    }
}
