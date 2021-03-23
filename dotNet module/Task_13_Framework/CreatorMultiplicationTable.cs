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
        /// /// <param name="tableSize">Размер таблицы.</param>
        public static void WithEarlyBinding(string pathOfFile, uint tableSize)
        {
            var excelApp = new Excel.Application() { Visible = true };
            BindingBody(excelApp, pathOfFile, tableSize);
        }

        /// <summary>
        /// Позднее связывание.
        /// </summary>
        /// <param name="pathOfFile">Путь с именем к нужному файлу для сохранения.</param>
        /// /// <param name="tableSize">Размер таблицы.</param>
        public static void WithLateBinding(string pathOfFile, uint tableSize)
        {
            dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID(
                                "Excel.Application"));
            excelApp.Visible = true;
            BindingBody(excelApp, pathOfFile, tableSize);
        }

        /// <summary>
        /// Общая часть кода реализована здесь.
        /// </summary>
        /// <param name="excelApp">Программа Excel.</param>
        /// <param name="pathOfFile">Путь к файлу.</param>
        /// <param name="tableSize">Размер таблицы.</param>
        private static void BindingBody(Excel.Application excelApp, string pathOfFile, uint tableSize)
        {
            excelApp.Workbooks.Add();
            var workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            for (int i = 2; i <= tableSize + 1; i++)
            {
                workSheet.Cells[1, i] = i - 1;
                workSheet.Cells[i, "A"] = i - 1;
            }

            workSheet.get_Range($"{workSheet.Cells[2, 2].Address}", $"{workSheet.Cells[tableSize + 1, tableSize + 1].Address}").Formula = "= $A2 * B$1";
            workSheet.SaveAs(pathOfFile);
        }
    }
}
