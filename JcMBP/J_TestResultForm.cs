using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class J_TestResultForm : Form
    {
        DataSweep ds;
        bool isdbm;
        public J_TestResultForm(DataSweep ds,bool b)
        {
            InitializeComponent();
            this.ds = ds;
            isdbm = b;
        }

        private void J_TestResultForm_Load(object sender, EventArgs e)
        {
            label2.Text = ds.sxy.str_data;
            time_tB_valMax.Text = ds.sxy.max.ToString("0.00");
            time_tB_valMin.Text = ds.sxy.min.ToString("0.00");
            if (ds.sxy.result == "FAIL")
            {
                time_lbl_limitResulte.Text = "FAIL";
                time_lbl_limitResulte.ForeColor = Color.Red;
            }
            freq_dgvPim.DataSource = ds.dt;
            if (!isdbm)
            {
                freq_dgvPim.DataSource = ds.dtc;
                label68.Text = "最大(dBc):";
                label67.Text = "最小(dBc):";
                time_tB_valMax.Text = (ds.sxy.max - 43).ToString("0.00");
                time_tB_valMin.Text = (ds.sxy.min - 43).ToString("0.00");
                freq_dgvPim.Columns[6].HeaderText = "P_im(dBc)";
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
