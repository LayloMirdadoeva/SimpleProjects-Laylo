using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Data;

namespace ProjectsDataGridView
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("firstName", "Имя");
            dataGridView1.Columns.Add("lastName", "Фамилия");
            dataGridView1.Columns.Add("age", "Возрасть");

            Form1 form1 = (Form1)Application.OpenForms["form1"];
            dataGridView1.Rows.Add(form1.firstName, form1.lastName, form1.age);
        }

        private void ExportToExel(System.Windows.Forms.DataGridView dataGridView1, string filePath)
        {
            // Создание нового пакета Excel
            using (var package = new ExcelPackage())
            {
                // Добавление листа в пакет
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                ExcelFont font = worksheet.Cells["A1"].Style.Font;
                font.Bold = true;
                font.Size = 20;
                font.Name = "Palatino Linotype";

                worksheet.Cells["A1:H1"].Merge = true;
                worksheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:H1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1:H1"].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                worksheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(Color.White);
                int k = 1;
                // Заполнение заголовков
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = "Сотрудники";
                    worksheet.Cells[2, i].Value = dataGridView1.Columns[i - 1].HeaderText;
                    worksheet.Cells[3, i].Value = k; k++;
                }

                // Заполнение данных
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 4, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                // Автоматическое изменение ширины столбцов
                worksheet.Cells.AutoFitColumns();


                //HashSet<string> uniqueUsers = new HashSet<string>();
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    string userName = row.Cells["firstName"].Value != null ? row.Cells["firstName"].Value.ToString() : "";
                //    uniqueUsers.Add(userName);
                //}
                //int lastRow = worksheet.Dimension.End.Row;
                //int currentRow = lastRow + 1;


                //int startColumn = 1;
                //int endColumn = 7; // Используйте endColumn, чтобы указать конечную колонку

                //foreach (string user in uniqueUsers)
                //{
                //    // Объединяем ячейки только для первого пользователя
                //    if (startColumn == 1 && endColumn == 7)
                //    {
                //        worksheet.Cells[7, startColumn, 7, endColumn].Merge = true;
                //    }

                //    worksheet.Cells[currentRow, startColumn].Value = user;
                //    worksheet.Cells[currentRow, startColumn, currentRow, endColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //    worksheet.Cells[currentRow, startColumn, currentRow, endColumn].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                //    worksheet.Cells[currentRow, startColumn, currentRow, endColumn].Style.Font.Name = "Palatino Linotype";
                //    worksheet.Cells[currentRow, startColumn, currentRow, endColumn].Style.Font.Size = 10;
                //    worksheet.Cells[currentRow, startColumn, currentRow, endColumn].Style.Font.Bold = true;


                //    currentRow++; // Увеличиваем значение currentRow для следующей строки
                //}
                // Сохранение файла Excel
                package.SaveAs(new FileInfo(filePath));

            }
            MessageBox.Show("Данные успешно экспортированы в Excel!", "Экспорт данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();

        }

        private void ExportToExcelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // или LicenseContext.Commercial, в зависимости от типа вашей лицензии

                    ExportToExel(dataGridView1, saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}


