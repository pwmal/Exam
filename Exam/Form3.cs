namespace Exam
{
    public partial class Form3 : Form
    {
        Form1 f1;
        DateTime thisDay = DateTime.Today;

        public Form3(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            comboBox1.Items.AddRange(new string[] { "СПО", "Бакалавриат", "Специалитет", "Магистратура" });
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label9.Text = "Средний балл аттестата";
                textBox6.Enabled = true;
                textBox6.ReadOnly = false;

                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(new string[] { "11.01.01 Монтажник радиоэлектронной аппаратуры и приборов",
                                                        "08.02.01 Строительство и эксплуатация зданий и сооружений",
                                                        "08.02.05 Строительство и эксплуатация автомобильных дорог и аэродромов",
                                                        "08.02.08 Монтаж и эксплуатация оборудования и систем газоснабжения",
                                                        "08.02.13 Монтаж и эксплуатация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции",
                                                        "09.02.01 Компьютерные системы и комплексы"});
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label9.Text = "Баллы ЕГЭ";
                textBox6.Enabled = false;
                textBox6.ReadOnly = true;

                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(new string[] { "07.03.01 Архитектура Профиль: «Архитектура»",
                                                        "07.03.02  Реконструкция и реставрация архитектурного наследия Профиль: «Реконструкция и реставрация архитектурного наследия»",
                                                        "07.03.03 Дизайн архитектурной среды Профиль: «Дизайн архитектурной среды»",
                                                        "07.03.04 Градостроительство Профиль: «Градостроительное проектирование»"});
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label9.Text = "Баллы ЕГЭ";
                textBox6.Enabled = false;
                textBox6.ReadOnly = true;

                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(new string[] { "10.05.02 Информационная безопасность телекоммуникационных систем",
                                                        "11.05.01 Радиоэлектронные системы и комплексы",
                                                        "24.05.02 Проектирование авиационных и ракетных двигателей",
                                                        "24.05.07 Самолето- и вертолетостроение"});
            }

            if (comboBox1.SelectedIndex == 3)
            {
                label9.Text = "Средний балл диплома";
                textBox6.Enabled = false;
                textBox6.ReadOnly = true;

                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(new string[] { "07.04.01 Архитектура Программа «Актуальные направления теории и практики архитектуры»",
                                                        "07.04.02 Реконструкция и реставрация архитектурного наследия Программа «Реконструкция и реставрация архитектурного наследия»",
                                                        "07.04.03 Дизайн архитектурной среды Программа «Дизайн архитектурной среды»"});
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text.Trim(' ') != "" &&
                    textBox2.Text.Trim(' ') != "" &&
                    textBox3.Text.Trim(' ') != "" &&
                    textBox4.Text.Trim(' ') != "" &&
                    textBox5.Text.Trim(' ') != "" &&
                    textBox6.Text.Trim(' ') != "" &&
                    textBox7.Text.Trim(' ') != "" &&
                    textBox8.Text.Trim(' ') != "" &&
                    comboBox1.SelectedIndex != -1 &&
                    comboBox2.SelectedIndex != -1)
                {
                    DBCON.SQLtoDBwithChanges($"INSERT INTO public.requests(education_level, name, passport, snils, email, phone_number, parent_name, student_education_level, final_grade, direction_of_preparation, user_id, status, date)" +
                        $"VALUES ('{comboBox1.Text}', '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}', '{textBox8.Text}', '{comboBox2.Text}', {f1.id}, 'ПОДАНО', '{thisDay.ToString("d")}');");
                }
            }
            else
            {
                if (textBox1.Text.Trim(' ') != "" &&
                    textBox2.Text.Trim(' ') != "" &&
                    textBox3.Text.Trim(' ') != "" &&
                    textBox4.Text.Trim(' ') != "" &&
                    textBox5.Text.Trim(' ') != "" &&
                    textBox7.Text.Trim(' ') != "" &&
                    textBox8.Text.Trim(' ') != "" &&
                    comboBox1.SelectedIndex != -1 &&
                    comboBox2.SelectedIndex != -1)
                {
                    DBCON.SQLtoDBwithChanges($"INSERT INTO public.requests(education_level, name, passport, snils, email, phone_number, student_education_level, final_grade, direction_of_preparation, user_id, status, date)" +
                        $"VALUES ('{comboBox1.Text}', '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox7.Text}', '{textBox8.Text}', '{comboBox2.Text}', {f1.id}, 'ПОДАНО', '{thisDay.ToString("d")}');");
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) 
            {
                DBCON.SQLtoDB($"SELECT * FROM requests WHERE user_id = '{f1.id}'");
                for(int i = 0; i < DBCON.dt.Rows.Count; i++) 
                {
                    textBox9.Text += $"Дата: {DBCON.dt.Rows[i][14]} Статус: {DBCON.dt.Rows[i][13]} Комментарий: {DBCON.dt.Rows[i][12]} " + Environment.NewLine;
                }
            }
        }
    }
}
