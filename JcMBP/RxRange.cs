using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class RxRange : Form
    {
        public float _rxs;
        public float _rxe;
        float rxmax;
        float rxmin;
        public RxRange(float rxs,float rxe,float rmax,float rmin)
        {
            InitializeComponent();
            this._rxe = rxe;
            this._rxs = rxs;
            rxmax = rmax;
            rxmin = rmin;
        }

        private void time_btn_start_b_Click(object sender, EventArgs e)
        {
            _rxs = Convert.ToSingle(numericUpDown1.Value);
            _rxe = Convert.ToSingle(numericUpDown2.Value);
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void RxRange_Load(object sender, EventArgs e)
        {
            OfftenMethod.NudValue(numericUpDown1, numericUpDown2, Convert.ToDecimal(rxmin), Convert.ToDecimal(rxmax));
            numericUpDown1.Value = Convert.ToDecimal(_rxs);
            numericUpDown2.Value = Convert.ToDecimal(_rxe);
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }

        private void numericUpDown2_MouseClick(object sender, MouseEventArgs e)
        {
            OfftenMethod.Formula(sender);
        }
    }
}
