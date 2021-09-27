using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessor
{
    public class StringCleanser : IStringCleanser
    {
        public string CleanInputString(string inputString)
        {

            char[] inputCharArray = inputString.ToCharArray();

            var sb = new StringBuilder();

            for (int i = 0; i < inputCharArray.Length; i++)
            {
                //Replace Dollar Symbol with Pound Symbol
                if (inputCharArray[i] == '$') inputCharArray[i] = '£';

                //Exit Loop if character in question is a '4' or a '_'
                if ((inputCharArray[i] == '4') || (inputCharArray[i] == '_')) continue;

                if (i > 0)
                {
                    int j = i - 1;
                    if (inputCharArray[j] != inputCharArray[i])
                    {

                        sb = sb.Append(inputCharArray[i]);

                    }

                }
                else
                    sb = sb.Append(inputCharArray[i]);



                if (sb.Length == 15)
                    break;
            }

            return sb.ToString();

        }
    }
}
