using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using YamlDotNet.RepresentationModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Расписание
{
    public partial class Form1 : Form
    {

        public class Group
        {
            public int id;
            public string name;

            public Group(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }

        public class Teacher
        {
            public int id;
            public string fio;

            public Teacher(int id, string fio)
            {
                this.id = id;
                this.fio = fio;
            }
        }

        public class Room
        {
            public int id;
            public string room;

            public Room(int id, string room)
            {
                this.id = id;
                this.room = room;
            }
        }

        public class Subject
        {
            public int id;
            public string name;
            public string date;
            public string group;
            public int lesson_number;
            public string step_group;
            public string teacher;
            public string room;

            public Subject(int id, string name, string date, string group, int lesson_number, string step_group, string teacher, string room)
            {
                this.id = id;
                this.name = name;
                this.date = date;
                this.group = group;
                this.lesson_number = lesson_number;
                this.step_group = step_group;
                this.teacher = teacher;
                this.room = room;
            }
        }

        List<Group> groups = new List<Group>();
        List<Teacher> teachers = new List<Teacher>();
        List<Room> rooms = new List<Room>();
        List<Subject> subjects = new List<Subject>();

        string request = "";
        string path_open = Path.Combine(Directory.GetCurrentDirectory(), "1.xlsx");

        public Form1()
        {
            InitializeComponent();
        }

        string[] connection_settings = ["", "", "", ""];

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "connection.txt")))
                {
                    var yaml = new YamlStream();
                    yaml.Load(reader);

                    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
                    for (int i = 0; i < mapping.Children.Count; i++)
                    {
                        connection_settings[i] = mapping.Children[i].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string connect_line = "Data Source=" + connection_settings[0] + ";Initial Catalog=" + connection_settings[1] + ";Persist Security Info=True;User ID=" + connection_settings[2] + ";Password=" + connection_settings[3] + ";Trust Server Certificate=True";
            SqlConnection connection = new SqlConnection(connect_line);

            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select Название from Все_Группы group by Название;", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            int i = 1;
                            while (reader.Read())
                            {
                                groups.Add(new Group(i - 1, reader.GetString(0)));
                                listGroups.Items.Add(groups[i - 1].name);
                                i++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Занятий нет", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        reader.Close();
                    };

                    using (SqlCommand command = new SqlCommand("select ФИО from Преподаватели group by ФИО;", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            int i = 1;
                            while (reader.Read())
                            {
                                teachers.Add(new Teacher(i - 1, reader.GetString(0)));
                                listTeachers.Items.Add(teachers[i - 1].fio);
                                i++;
                            }
                        }
                        reader.Close();
                    };

                    using (SqlCommand command = new SqlCommand("select Аудитория from Аудитории group by Аудитория;", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            int i = 1;
                            while (reader.Read())
                            {
                                rooms.Add(new Room(i - 1, reader.GetString(0)));
                                listRooms.Items.Add(rooms[i - 1].room);
                                i++;
                            }
                        }
                        reader.Close();
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateOneDay.Enabled = true;
            }
            else
            {
                dateOneDay.Value = DateTime.Now.Date;
                dateOneDay.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                datePeriodFrom.Enabled = true;
                datePeriodUntill.Enabled = true;
            }
            else
            {
                datePeriodFrom.Value = DateTime.Now.Date;
                datePeriodUntill.Value = DateTime.Now.Date;
                datePeriodFrom.Enabled = false;
                datePeriodUntill.Enabled = false;
            }
        }

        private void rbtnGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnGroup.Checked)
            {
                grGroups.Enabled = true;
                grGroups.BackColor = Color.Honeydew;
            }
            else
            {
                for (int i = 0; i < listGroups.Items.Count; i++)
                {
                    listGroups.SetItemChecked(i, false);
                    listGroups.SetSelected(i, false);
                    selectedGroups.Clear();
                }
                grGroups.Enabled = false;
                grGroups.BackColor = Color.Transparent;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                listGroups.Enabled = true;
            }
            else
            {
                for (int i = 0; i < listGroups.Items.Count; i++)
                {
                    listGroups.SetItemChecked(i, false);
                    listGroups.SetSelected(i, false);
                    selectedGroups.Clear();
                }
                listGroups.Enabled = false;
            }
        }

        List<string> selectedGroups = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            btnResult.Enabled = false;
            if ((rbtnGroup.Checked || rbtnTeacher.Checked || rbtnRoom.Checked) && (radioButton1.Checked || radioButton2.Checked))
            {
                if (rbtnGroup.Checked)
                {
                    if (radioButton3.Checked || radioButton4.Checked)
                    {
                        request_to_bd();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (rbtnTeacher.Checked)
                    {
                        if (radioButton5.Checked || radioButton6.Checked)
                        {
                            request_to_bd();
                        }
                        else
                        {
                            MessageBox.Show("Заполните все поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (rbtnRoom.Checked)
                        {
                            if (radioButton7.Checked || radioButton8.Checked)
                            {
                                request_to_bd();
                            }
                            else
                            {
                                MessageBox.Show("Заполните все поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnResult.Enabled = true;
        }

        string Add_date()
        {
            if (radioButton1.Checked)
            {
                return $" and DAY(Дата) = {dateOneDay.Value.Day} and MONTH(Дата) = {dateOneDay.Value.Month} and YEAR(Дата) = {dateOneDay.Value.Year}";
            }
            else
            {
                if (radioButton2.Checked)
                {
                    return $" and Дата between '{datePeriodFrom.Value.Date.ToString("yyyy-dd-MM")}' and '{datePeriodUntill.Value.Date.ToString("yyyy-dd-MM")}'";
                }
                else
                {
                    return "";
                }
            }
        }

        List<string> selectedDates = new List<string>();

        private void request_to_bd()
        {
            selectedDates.Clear();
            subjects.Clear();

            if (radioButton4.Checked)
            {
                selectedGroups.Clear();
                for (int i = 0; i < listGroups.Items.Count; i++)
                {
                    if (listGroups.GetItemChecked(i))
                    {
                        selectedGroups.Add(listGroups.Items[i].ToString()!);
                    }
                }
            }
            if (radioButton6.Checked)
            {
                selectedTeachers.Clear();
                for (int i = 0; i < listTeachers.Items.Count; i++)
                {
                    if (listTeachers.GetItemChecked(i))
                    {
                        selectedTeachers.Add(listTeachers.Items[i].ToString()!);
                    }
                }
            }

            if (radioButton8.Checked)
            {
                selectedRooms.Clear();
                for (int i = 0; i < listRooms.Items.Count; i++)
                {
                    if (listRooms.GetItemChecked(i))
                    {
                        selectedRooms.Add(listRooms.Items[i].ToString()!);
                    }
                }
            }

            if (radioButton1.Checked)
            {
                selectedDates.Add(dateOneDay.Value.ToString("dd.MM.yyyy"));
            }

            if (radioButton2.Checked)
            {
                selectedDates.Add(datePeriodFrom.Value.ToString("dd.MM.yyyy"));
                DateTime date = DateTime.Parse(datePeriodFrom.Value.ToString("dd.MM.yyyy"));
                DateTime date_until = DateTime.Parse(datePeriodUntill.Value.ToString("dd.MM.yyyy"));

                while (date != date_until)
                {
                    date = date.AddDays(1);
                    selectedDates.Add(date.ToString("dd.MM.yyyy"));
                }
            }

            string connect_line = "Data Source=" + connection_settings[0] + ";Initial Catalog=" + connection_settings[1] + ";Persist Security Info=True;User ID=" + connection_settings[2] + ";Password=" + connection_settings[3] + ";Trust Server Certificate=True";
            SqlConnection connection = new SqlConnection(connect_line);

            //формирование запроса

            if (rbtnGroup.Checked)
            {
                request = $"select CONVERT(date, Дата) as Дата, Название as Группа, НомерЗанятия, Дисциплина, iif(НомерПодгруппы = 0, '', iif(НомерПодгруппы = 1, 'п/г 1', 'п/г 2')) as Подгруппа, Преподаватель, Аудитория from Расписание, Все_Группы where Все_Группы.Код = Расписание.Код_Группы";
                request += Add_date();

                if (radioButton4.Checked)
                {
                    if (selectedGroups.Count == 0)
                    {
                        MessageBox.Show("Выберите группы", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        request = "";
                        return;
                    }
                    request += " and Название in (";
                    for (int i = 0; i < selectedGroups.Count; i++)
                    {
                        if (i != selectedGroups.Count - 1)
                        {
                            request += $" '{selectedGroups[i].ToString()}', ";
                        }
                        else
                        {
                            request += $" '{selectedGroups[i].ToString()}') ";
                        }
                    }
                }
                request += " order by Дата, Группа, НомерЗанятия asc;";
            }

            if (rbtnTeacher.Checked)
            {
                request = $"select CONVERT(date, Дата) as Дата, Преподаватель, Дисциплина, Название as Группа, iif(НомерПодгруппы = 0, '', iif(НомерПодгруппы = 1, 'п/г 1', 'п/г 2')) as Подгруппа, НомерЗанятия, Аудитория from Расписание, Все_Группы where Все_Группы.Код = Расписание.Код_Группы";
                request += Add_date();

                if (radioButton6.Checked)
                {
                    if (selectedTeachers.Count == 0)
                    {
                        MessageBox.Show("Выберите преподавателей", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        request = "";
                        return;
                    }
                    request += " and Преподаватель in (";
                    for (int i = 0; i < selectedTeachers.Count; i++)
                    {
                        if (i != selectedTeachers.Count - 1)
                        {
                            request += $" '{selectedTeachers[i].ToString()}', ";
                        }
                        else
                        {
                            request += $" '{selectedTeachers[i].ToString()}') ";
                        }
                    }
                }
                request += " order by Дата, Преподаватель, НомерЗанятия asc;";
            }

            if (rbtnRoom.Checked)
            {
                request = $"select CONVERT(date, Дата) as Дата, Название as Группа, НомерЗанятия, Дисциплина, iif(НомерПодгруппы = 0, '', iif(НомерПодгруппы = 1, 'п/г 1', 'п/г 2')) as Подгруппа, Преподаватель, Аудитория from Расписание, Все_Группы where Все_Группы.Код = Расписание.Код_Группы";
                request += Add_date();

                if (radioButton8.Checked)
                {
                    if (selectedRooms.Count == 0)
                    {
                        MessageBox.Show("Выберите аудитории", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        request = "";
                        return;
                    }
                    request += " and Аудитория in (";
                    for (int i = 0; i < selectedRooms.Count; i++)
                    {
                        if (i != selectedRooms.Count - 1)
                        {
                            request += $" '{selectedRooms[i].ToString()}', ";
                        }
                        else
                        {
                            request += $" '{selectedRooms[i].ToString()}') ";
                        }
                    }
                }
                request += " order by Дата, Аудитория, НомерЗанятия asc;";
            }

            //запрос в бд и формирование файла

            if (rbtnGroup.Checked)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                int i = 0;
                                while (reader.Read())
                                {
                                    subjects.Add(new Subject(i, reader.GetString(3), reader.GetDateTime(0).ToString("dd.MM.yyyy"), reader.GetString(1), reader.GetInt32(2), reader.GetString(4), //step
                                        reader.GetString(5), reader.GetString(6)));
                                    i++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Занятий нет", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            reader.Close();

                            Excel.Application excel = new Excel.Application();
                            Excel.Workbook workbook = excel.Workbooks.Open(path_open);
                            Excel.Worksheet worksheet = workbook.Worksheets[1];
                            worksheet.Name = "По группам";
                            worksheet.Cells[1, 1].Value = "Дата";
                            worksheet.Cells[1, 2].Value = "Пара";

                            int row = 2;
                            int col = 3;
                            int row_n = 2;
                            int count = 0;

                            for (int n = 0; n < selectedDates.Count; n++)
                            {
                                row = row_n;

                                for (int i = 1; i <= 7; i++)
                                {
                                    worksheet.Cells[row, 2].Value = i;
                                    worksheet.Cells[row, 1].Value = selectedDates[n];
                                    row++;
                                }

                                row = row_n;

                                for (int j = 0; j < selectedGroups.Count; j++)
                                {
                                    if (n == 0)
                                    {
                                        worksheet.Cells[1, col].Value = selectedGroups[j];
                                    }

                                    for (int i = 1; i <= 7; i++)
                                    {
                                        int check_item = (from subject in subjects
                                                          where subject.date.Substring(0, 10) == selectedDates[n] && subject.@group == selectedGroups[j] &&
                                               subject.lesson_number == i
                                                          select subject).Distinct().Count();

                                        switch (check_item)
                                        {
                                            case 0:
                                                {
                                                    row++;
                                                }
                                                break;
                                            case 1:
                                                {
                                                    var item = (from subject in subjects
                                                                where subject.date.Substring(0, 10) == selectedDates[n] && subject.@group == selectedGroups[j] &&
                                                                subject.lesson_number == i
                                                                select subject).First();

                                                    worksheet.Cells[row, col].Value = item.name;

                                                    if (item.step_group != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += " " + item.step_group;
                                                    }

                                                    if (item.teacher != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += "\n" + item.teacher;
                                                    }

                                                    if (item.room != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += "\n" + item.room;
                                                    }

                                                    row++;
                                                }
                                                break;
                                            default:
                                                {
                                                    var item = (from subject in subjects
                                                                where subject.date.Substring(0, 10) == selectedDates[n] && subject.@group == selectedGroups[j] &&
                                                                subject.lesson_number == i
                                                                select subject).ToList();

                                                    for (int q = 0; q < check_item; q++)
                                                    {
                                                        worksheet.Cells[row, col].Value += item[q].name;

                                                        if (item[q].step_group != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += " " + item[q].step_group;
                                                        }

                                                        if (item[q].teacher != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n" + item[q].teacher;
                                                        }

                                                        if (item[q].room != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n" + item[q].room;
                                                        }

                                                        if (q != check_item - 1)
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n";
                                                        }
                                                    }
                                                    row++;
                                                }
                                                break;
                                        }
                                        count++;
                                        label3.Text = ((count * 100) / (selectedDates.Count * selectedGroups.Count * 7)).ToString() + " % (" + count + " / " +
                                            (selectedDates.Count * selectedGroups.Count * 7).ToString() + ")";
                                    }
                                    col++;
                                    row = row_n;
                                }
                                if (n != 0)
                                {
                                    worksheet.Cells[row_n - 1, 3].Value = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(DateTime.Parse(selectedDates[n].ToString()).DayOfWeek).ToUpper();
                                    worksheet.Rows[row_n - 1].Borders.Item[3].Weight = XlBorderWeight.xlMedium;
                                }
                                row_n += 8;
                                col = 3;
                            }

                            save_file(worksheet, workbook, excel);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            if (rbtnTeacher.Checked)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                int i = 0;
                                while (reader.Read())
                                {
                                    subjects.Add(new Subject(i, reader.GetString(2), reader.GetDateTime(0).ToString("dd.MM.yyyy"), reader.GetString(3), reader.GetInt32(5), reader.GetString(4),
                                        reader.GetString(1), reader.GetString(6)));
                                    i++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Занятий нет", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            reader.Close();

                            Excel.Application excel = new Excel.Application();
                            Excel.Workbook workbook = excel.Workbooks.Open(path_open);
                            Excel.Worksheet worksheet = workbook.Worksheets[1];
                            worksheet.Name = "По преподавателям";
                            worksheet.Cells[1, 1].Value = "Дата";
                            worksheet.Cells[1, 2].Value = "Пара";

                            int row = 2;
                            int col = 3;
                            int row_n = 2;
                            int count = 0;

                            for (int n = 0; n < selectedDates.Count; n++)
                            {
                                row = row_n;

                                for (int i = 1; i <= 7; i++)
                                {
                                    worksheet.Cells[row, 2].Value = i;
                                    worksheet.Cells[row, 1].Value = selectedDates[n];
                                    row++;
                                }

                                row = row_n;

                                for (int j = 0; j < selectedTeachers.Count; j++)
                                {
                                    if (n == 0)
                                    {
                                        worksheet.Cells[1, col].Value = selectedTeachers[j];
                                    }

                                    for (int i = 1; i <= 7; i++)
                                    {
                                        int check_item = (from subject in subjects
                                                          where subject.date.Substring(0, 10) == selectedDates[n] && subject.teacher == selectedTeachers[j] &&
                                               subject.lesson_number == i
                                                          select subject).Distinct().Count();

                                        switch (check_item)
                                        {
                                            case 0:
                                                {
                                                    row++;
                                                }
                                                break;
                                            case 1:
                                                {
                                                    var item = (from subject in subjects
                                                                where subject.date.Substring(0, 10) == selectedDates[n] && subject.teacher == selectedTeachers[j] &&
                                                                subject.lesson_number == i
                                                                select subject).First();

                                                    worksheet.Cells[row, col].Value = item.group;

                                                    if (item.step_group != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += " " + item.step_group;
                                                    }

                                                    worksheet.Cells[row, col].Value += "\n" + item.name;

                                                    if (item.room != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += "\n" + item.room;
                                                    }

                                                    row++;
                                                }
                                                break;
                                            default:
                                                {
                                                    var item = (from subject in subjects
                                                                where subject.date.Substring(0, 10) == selectedDates[n] && subject.teacher == selectedTeachers[j] &&
                                                                subject.lesson_number == i
                                                                select subject).ToList();

                                                    for (int q = 0; q < check_item; q++)
                                                    {
                                                        worksheet.Cells[row, col].Value += item[q].group;

                                                        if (item[q].step_group != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += " " + item[q].step_group;
                                                        }

                                                        worksheet.Cells[row, col].Value += "\n" + item[q].name;

                                                        if (item[q].room != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n" + item[q].room;
                                                        }

                                                        if (q != check_item - 1)
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n";
                                                        }
                                                    }
                                                    row++;
                                                }
                                                break;
                                        }
                                        count++;
                                        label3.Text = ((count * 100) / (selectedDates.Count * selectedTeachers.Count * 7)).ToString() + " % (" + count + " / " +
                                            (selectedDates.Count * selectedTeachers.Count * 7).ToString() + ")";
                                    }
                                    col++;
                                    row = row_n;
                                }
                                if (n != 0)
                                {
                                    worksheet.Cells[row_n - 1, 3].Value = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(DateTime.Parse(selectedDates[n].ToString()).DayOfWeek).ToUpper();
                                    worksheet.Rows[row_n - 1].Borders.Item[3].Weight = XlBorderWeight.xlMedium;
                                }
                                row_n += 8;
                                col = 3;
                            }

                            save_file(worksheet, workbook, excel);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            if (rbtnRoom.Checked)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                int i = 0;
                                while (reader.Read())
                                {
                                    subjects.Add(new Subject(i, reader.GetString(3), reader.GetDateTime(0).ToString("dd.MM.yyyy"), reader.GetString(1), reader.GetInt32(2), reader.GetString(4),
                                        reader.GetString(5), reader.GetString(6)));
                                    i++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Занятий нет", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            reader.Close();

                            Excel.Application excel = new Excel.Application();
                            Excel.Workbook workbook = excel.Workbooks.Open(path_open);
                            Excel.Worksheet worksheet = workbook.Worksheets[1];
                            worksheet.Name = "По аудиториям";
                            worksheet.Cells[1, 1].Value = "Дата";
                            worksheet.Cells[1, 2].Value = "Пара";

                            int row = 2;
                            int col = 3;
                            int row_n = 2;
                            int count = 0;

                            for (int n = 0; n < selectedDates.Count; n++)
                            {
                                row = row_n;

                                for (int i = 1; i <= 7; i++)
                                {
                                    worksheet.Cells[row, 2].Value = i;
                                    worksheet.Cells[row, 1].Value = selectedDates[n];
                                    row++;
                                }

                                row = row_n;

                                for (int j = 0; j < selectedRooms.Count; j++)
                                {
                                    if (n == 0)
                                    {
                                        worksheet.Cells[1, col].Value = selectedRooms[j];
                                    }

                                    for (int i = 1; i <= 7; i++)
                                    {
                                        int check_item = (from subject in subjects
                                                          where subject.date.Substring(0, 10) == selectedDates[n] && subject.room == selectedRooms[j].ToString() &&
                                               subject.lesson_number == i
                                                          select subject).Distinct().Count();

                                        switch (check_item)
                                        {
                                            case 0:
                                                {
                                                    row++;
                                                }
                                                break;
                                            case 1:
                                                {
                                                    var item = (from subject in subjects
                                                                where subject.date.Substring(0, 10) == selectedDates[n] && subject.room == selectedRooms[j].ToString() &&
                                                                subject.lesson_number == i
                                                                select subject).First();

                                                    worksheet.Cells[row, col].Value = item.group;

                                                    if (item.step_group != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += " " + item.step_group;
                                                    }

                                                    worksheet.Cells[row, col].Value += "\n" + item.name;

                                                    if (item.teacher != "")
                                                    {
                                                        worksheet.Cells[row, col].Value += "\n" + item.teacher;
                                                    }

                                                    row++;
                                                }
                                                break;
                                            default:
                                                {
                                                    var item = (from subject in subjects
                                                                where subject.date.Substring(0, 10) == selectedDates[n] && subject.room == selectedRooms[j].ToString() &&
                                                                subject.lesson_number == i
                                                                select subject).ToList();



                                                    for (int q = 0; q < check_item; q++)
                                                    {
                                                        worksheet.Cells[row, col].Value += item[q].group;

                                                        if (item[q].step_group != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += " " + item[q].step_group;
                                                        }

                                                        worksheet.Cells[row, col].Value = "\n" + item[q].name;

                                                        if (item[q].teacher != "")
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n" + item[q].teacher;
                                                        }

                                                        if (q != check_item - 1)
                                                        {
                                                            worksheet.Cells[row, col].Value += "\n\n";
                                                        }
                                                    }
                                                    row++;
                                                }
                                                break;
                                        }
                                        count++;
                                        label3.Text = ((count * 100) / (selectedDates.Count * selectedRooms.Count * 7)).ToString() + " % (" + count + " / " +
                                            (selectedDates.Count * selectedRooms.Count * 7).ToString() + ")";
                                    }
                                    col++;
                                    row = row_n;
                                }
                                if (n != 0)
                                {
                                    worksheet.Cells[row_n - 1, 3].Value = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(DateTime.Parse(selectedDates[n].ToString()).DayOfWeek).ToUpper();
                                    worksheet.Rows[row_n - 1].Borders.Item[3].Weight = XlBorderWeight.xlMedium;
                                }
                                row_n += 8;
                                col = 3;
                            }

                            save_file(worksheet, workbook, excel);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void save_file(Excel.Worksheet worksheet, Excel.Workbook workbook, Excel.Application excel)
        {
            worksheet.Columns.ColumnWidth = 30;
            worksheet.Columns[1].AutoFit();
            worksheet.Columns[1].Font.Bold = true;
            worksheet.Columns[2].AutoFit();
            worksheet.Rows[1].Font.Bold = true;
            worksheet.Rows.AutoFit();
            worksheet.Cells.WrapText = true;
            worksheet.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            worksheet.Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
            worksheet.Application.ActiveWindow.SplitRow = 1;
            worksheet.Application.ActiveWindow.FreezePanes = true;

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(sfd.FileName);
            }
            workbook.Close(false, Type.Missing, Type.Missing);
            excel.Workbooks.Close();
            Marshal.ReleaseComObject(workbook);
            GC.Collect();
            excel.Quit();
            Marshal.FinalReleaseComObject(excel);
            MessageBox.Show("Файл создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                listTeachers.Enabled = true;
            }
            else
            {
                for (int i = 0; i < listTeachers.Items.Count; i++)
                {
                    listTeachers.SetItemChecked(i, false);
                    listTeachers.SetSelected(i, false);
                    selectedTeachers.Clear();
                }
                listTeachers.Enabled = false;
            }
        }

        List<string> selectedTeachers = new List<string>();

        private void rbtnTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTeacher.Checked)
            {
                grTeachers.Enabled = true;
                grTeachers.BackColor = Color.Honeydew;
            }
            else
            {
                for (int i = 0; i < listTeachers.Items.Count; i++)
                {
                    listTeachers.SetItemChecked(i, false);
                    listTeachers.SetSelected(i, false);
                    selectedTeachers.Clear();
                }
                grTeachers.Enabled = false;
                grTeachers.BackColor = Color.Transparent;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                listRooms.Enabled = true;
            }
            else
            {
                for (int i = 0; i < listRooms.Items.Count; i++)
                {
                    listRooms.SetItemChecked(i, false);
                    listRooms.SetSelected(i, false);
                    selectedRooms.Clear();
                }
                listRooms.Enabled = false;
            }
        }

        List<string> selectedRooms = new List<string>();

        private void rbtnRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRoom.Checked)
            {
                grRooms.Enabled = true;
                grRooms.BackColor = Color.Honeydew;
            }
            else
            {
                for (int i = 0; i < listRooms.Items.Count; i++)
                {
                    listRooms.SetItemChecked(i, false);
                    listRooms.SetSelected(i, false);
                    selectedRooms.Clear();
                }
                grRooms.Enabled = false;
                grRooms.BackColor = Color.Transparent;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            selectedGroups.Clear();
            for (int i = 0; i < listGroups.Items.Count; i++)
            {
                selectedGroups.Add(listGroups.Items[i].ToString()!);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            selectedTeachers.Clear();
            for (int i = 0; i < listTeachers.Items.Count; i++)
            {
                selectedTeachers.Add(listTeachers.Items[i].ToString()!);
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            selectedRooms.Clear();
            for (int i = 0; i < listRooms.Items.Count; i++)
            {
                selectedRooms.Add(listRooms.Items[i].ToString()!);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutProgram aboutProgram = new aboutProgram();
            aboutProgram.Show();
        }
    }
}