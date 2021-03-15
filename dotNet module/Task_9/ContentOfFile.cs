using System.Collections;
using System.Collections.Generic;

namespace Task_9
{
    /// <summary>
    /// Содержит список строк из файла txt формата
    /// </summary>
    public class ContentOfFile : IEnumerable
    {
        public List<string> ContentList { get; }

        public ContentOfFile(string content)
        {
            this.ContentList = new List<string>(content.Split("\n"));
        }

        public IEnumerator GetEnumerator()
        {
            return new ContentEnumerator(this.ContentList);
        }
    }
}