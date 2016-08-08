using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JcMBP
{
    public partial class SingleTestData : Form
    {
        public SingleTestData()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        bool isdbm = false;

        public SingleTestData(DataTable dt,bool isdbm)
        {
            InitializeComponent();
            this.dt = dt;
            this.isdbm = isdbm;
        }

        private void SingleTestData_Load(object sender, EventArgs e)
        {
            freq_dgvPim.DataSource = dt;
            if(isdbm)
                freq_dgvPim.Columns[6].HeaderText = "P_im(dBm)";
            else
                freq_dgvPim.Columns[6].HeaderText = "P_im(dBc)";
        }


    }
}
