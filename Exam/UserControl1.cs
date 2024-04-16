using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class UserControl1 : UserControl
    {
        int id;
        Form4 f4;

        public UserControl1(int id, Form4 f4)
        {
            InitializeComponent();
            this.id = id;
            this.f4 = f4;
        }

        private void UserControl1_DoubleClick(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(id, f4);
            f5.ShowDialog();
        }
    }
}
