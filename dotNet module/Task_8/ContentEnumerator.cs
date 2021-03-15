using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_8
{
    /// <summary>
    /// Реализация Enumerator для содержимого файла txt
    /// </summary>
    public class ContentEnumerator : IEnumerator
    {
        public List<string> ContentList { get; }

        private int position = -1;

        public ContentEnumerator(List<string> content)
        {
            this.ContentList = content;
        }

        public object Current
        {
            get
            {
                if (this.position == -1 || this.position >= this.ContentList.Count)
                    throw new InvalidOperationException();
                return this.ContentList[this.position];
            }
        }

        public bool MoveNext()
        {
            if (this.position < this.ContentList.Count - 1)
            {
                this.position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}