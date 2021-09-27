using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessor
{
     
    public interface IStringCleanser
    {
        // string InputString { get; }

        //string OutputString { get; set; }

        string CleanInputString(string inputString);
    }
}
