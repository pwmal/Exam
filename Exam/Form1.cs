namespace Exam
{
    public partial class Form1 : Form
    {
        public string id;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBCON.SQLtoDB($"SELECT * FROM users WHERE login = '{textBox1.Text}'");
                id = DBCON.dt.Rows[0][0].ToString();
                string login = DBCON.dt.Rows[0][1].ToString();
                string password = DBCON.dt.Rows[0][2].ToString();
                int role = Convert.ToInt32(DBCON.dt.Rows[0][3]);
                if (login == textBox1.Text && password == textBox2.Text)
                {
                    if (role == 1)
                    {
                        this.Hide();
                        Form3 form3 = new Form3(this);
                        form3.ShowDialog();
                    }
                    if (role == 2) 
                    {
                        this.Hide();
                        Form4 form4 = new Form4(this);
                        form4.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
