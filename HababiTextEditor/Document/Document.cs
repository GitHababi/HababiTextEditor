using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTE.Document
{
    public class Document
    {
        private List<char> chars;

        public bool WordWrap { get; set; }

        public Document(string initialText) 
        {
            chars = new List<char>(initialText);
            WordWrap = false;
        }

        public Document() : this("") { }

    }
}
