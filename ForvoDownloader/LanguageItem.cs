using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForvoDownloader
{
    class LanguageItem
    {
        private string name = "";
        private string code = "";

        public string Code
        {
            get { return code; }
           
        }

        public LanguageItem(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        public override string ToString()
        {
            return code + ": " + name;
        }
    }
}
