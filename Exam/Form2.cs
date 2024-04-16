namespace Exam
{
    public partial class Form2 : Form
    {
        Form1 f1;

        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string login = "";
                DBCON.SQLtoDB($"SELECT EXISTS (SELECT true FROM users WHERE login = '{textBox1.Text}');");
                if (DBCON.dt.Rows[0][0].ToString() == "True")
                {
                    throw new Exception("Логин занят");
                }
                else
                {
                    if (textBox2.Text.Length <= 8)
                    {
                        throw new Exception("Пароль слишком короткий");
                    }
                    else
                    {
                        DBCON.SQLtoDBwithChanges($"INSERT INTO users (login, password, role) VALUES ('{textBox1.Text}', '{textBox2.Text}', 1);");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
