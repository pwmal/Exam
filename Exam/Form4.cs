namespace Exam
{
    public partial class Form4 : Form
    {
        Form1 f1;
        string sql = "SELECT * FROM requests ORDER BY id ASC";

        public Form4(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            requestsToUser();
        }

        public void requestsToUser()
        {
            flowLayoutPanel1.Controls.Clear();
            DBCON.SQLtoDB(sql);
            for (int i = 0; i < DBCON.dt.Rows.Count; i++)
            {
                UserControl1 temp = new UserControl1(Convert.ToInt32(DBCON.dt.Rows[i][0]), this);
                temp.Size = new Size(530, 150);
                temp.label1.Text = DBCON.dt.Rows[i][3].ToString();
                temp.textBox1.Text = DBCON.dt.Rows[i][12].ToString();
                temp.label3.Text = DBCON.dt.Rows[i][13].ToString();
                temp.label4.Text = DBCON.dt.Rows[i][14].ToString();
                flowLayoutPanel1.Controls.Add(temp);
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text.Length != 10)
            {
                sql = "SELECT * FROM requests ORDER BY id ASC";
                requestsToUser();
            }
            else
            {
                sql = $"SELECT * FROM requests WHERE date = '{maskedTextBox1.Text}' ORDER BY id ASC";
                requestsToUser();
            }
        }
    }
}
