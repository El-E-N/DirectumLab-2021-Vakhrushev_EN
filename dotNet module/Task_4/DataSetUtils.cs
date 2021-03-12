using System.Data;
using System.Text;

namespace Task_4
{
    public class DataSetUtils
    {
        /// <summary>
        /// Перевод данных о DataSet в String
        /// </summary>
        /// <param name="dataSet">Сам DataSet</param>
        /// <param name="separateOfRow">Разделитель для записей</param>
        /// <param name="separateOfColumn">Разделитель для колонок</param>
        /// <param name="separateOfTable">Разделитель для таблиц</param>
        /// <returns>Строка с информацией от DataSet</returns>
        public static string ConvertToString(DataSet dataSet, string separateOfRow, string separateOfColumn, string separateOfTable)
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables[i].Rows.Count; j++)
                {
                    for (int k = 0; k < dataSet.Tables[i].Rows[j].ItemArray.Length; k++)
                    {
                        strBuilder.Append(dataSet.Tables[i].Rows[j].ItemArray[k]);
                        if (k != dataSet.Tables[i].Rows[j].ItemArray.Length - 1)
                            strBuilder.Append(separateOfColumn);
                    }
                    if (j != dataSet.Tables[i].Rows.Count - 1)
                        strBuilder.Append(separateOfRow);
                }
                if (i != dataSet.Tables.Count - 1)
                    strBuilder.Append(separateOfTable);
            }
            return strBuilder.ToString();
        }
    }
}