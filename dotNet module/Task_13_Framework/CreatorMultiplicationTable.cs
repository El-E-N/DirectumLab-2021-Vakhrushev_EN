using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Task_13_Framework
{
    /// <summary>
    /// Создать в excel таблицу умножения 9x9.
    /// </summary>
    public static class CreatorMultiplicationTable
    {
        /// <summary>
        /// Раннее связывание.
        /// </summary>
        /// <param name="pathOfFile">Путь с именем к нужному файлу для сохранения.</param>
        public static void WithEarlyBinding(string pathOfFile)
        {
            string[] letters = { "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            var number = 1;
            var excelApp = new Excel.Application() { Visible = true };
            excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = excelApp.ActiveSheet;

            foreach (var letter in letters)
            {
                workSheet.Cells[1, letter] = number;
                number++;
            }

            for (int i = 2; i <= 10; i++)
                workSheet.Cells[i, "A"] = i - 1;

            workSheet.get_Range("B2", "J10").Formula = "= $A2 * B$1";
            workSheet.SaveAs(pathOfFile);
        }

        /// <summary>
        /// Позднее связывание.
        /// </summary>
        /// <param name="pathOfFile">Путь с именем к нужному файлу для сохранения.</param>
        public static void WithLateBinding(string pathOfFile)
        {
            dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID(
                                "Excel.Application"));
            excelApp.Visible = true;
            string[] letters = { "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            var number = 1;
            excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = excelApp.ActiveSheet;

            foreach (var letter in letters)
            {
                workSheet.Cells[1, letter] = number;
                number++;
            }

            for (int i = 2; i <= 10; i++)
                workSheet.Cells[i, "A"] = i - 1;

            workSheet.get_Range("B2", "J10").Formula = "= $A2 * B$1";
            workSheet.SaveAs(pathOfFile);
        }
    }
}
