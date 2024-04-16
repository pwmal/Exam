namespace Exam
{
    public partial class Form5 : Form
    {
        int id;
        Form4 f4;

        public Form5(int id, Form4 f4)
        {
            InitializeComponent();
            this.id = id;
            comboBox1.Items.AddRange(new string[] { "ПОДАНО", "ГОТОВО", "В ДОРАБОТКУ" });
            this.f4 = f4;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DBCON.SQLtoDB($"SELECT * FROM requests WHERE id = {id}");
            textBox9.Text = DBCON.dt.Rows[0][1].ToString();
            textBox1.Text = DBCON.dt.Rows[0][2].ToString();
            textBox2.Text = DBCON.dt.Rows[0][3].ToString();
            textBox3.Text = DBCON.dt.Rows[0][4].ToString();
            textBox4.Text = DBCON.dt.Rows[0][5].ToString();
            textBox5.Text = DBCON.dt.Rows[0][6].ToString();
            textBox6.Text = DBCON.dt.Rows[0][7].ToString();
            textBox7.Text = DBCON.dt.Rows[0][8].ToString();
            textBox8.Text = DBCON.dt.Rows[0][9].ToString();
            textBox10.Text = DBCON.dt.Rows[0][10].ToString();

            textBox11.Text = DBCON.dt.Rows[0][12].ToString();

            if (DBCON.dt.Rows[0][13].ToString() == "ПОДАНО")
            {
                comboBox1.SelectedIndex = 0;
            }
            if (DBCON.dt.Rows[0][13].ToString() == "ГОТОВО")
            {
                comboBox1.SelectedIndex = 1;
            }
            if (DBCON.dt.Rows[0][13].ToString() == "В ДОРАБОТКУ")
            {
                comboBox1.SelectedIndex = 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBCON.SQLtoDBwithChanges($"UPDATE requests SET description = '{textBox11.Text}', status = '{comboBox1.Text}' WHERE id = {id}");
            f4.requestsToUser();
            this.Close();
        }
    }
}
