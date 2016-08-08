using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class FrmEnableSwitch : Form
    {
        ClsUpLoad cul;
        readonly Dictionary<int, string> dic;
        int[] check;
        CheckBox[] cb = new CheckBox[8];
        public FrmEnableSwitch(ClsUpLoad cul)
        {
            InitializeComponent();
          
        }

    
    }
}
