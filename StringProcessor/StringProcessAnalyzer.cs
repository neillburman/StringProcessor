using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessor
{
    public class StringProcessorAnalyzer
    {
        private readonly IStringCleanser _stringCleanser;
        public StringProcessorAnalyzer(IStringCleanser stringCleanser)
        {
            _stringCleanser = stringCleanser;
        }

        public string CleanInputString(string inputString)
        {
            return _stringCleanser.CleanInputString(inputString);
        }

    }
}
