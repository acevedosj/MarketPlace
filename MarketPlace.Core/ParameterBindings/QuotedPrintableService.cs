using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarketPlace.Core.ParameterBindings
{
    public class QuotedPrintableService
    {
        public QuotedPrintableService()
        {
        }

        public string Decode(string input)
        {
            input = input.Replace("=\r\n", "");
            Regex hexRegex = new Regex("=[0-9A-F]{2}", RegexOptions.Multiline);
            input = hexRegex.Replace(input, new MatchEvaluator(this.HexDecoderEvaluator));
            return input;
        }

        public bool HeaderIsPresent(HttpContent content)
        {
            IEnumerable<string> values;
            bool flag;
            flag = (!content.Headers.TryGetValues("Content-Transfer-Encoding", out values) ? false : values.FirstOrDefault<string>() == "quoted-printable");
            return flag;
        }

        private string HexDecoderEvaluator(Match m)
        {
            string value = m.Value;
            byte[] bytes = new byte[value.Length / 3];
            for (int i = 0; i < (int)bytes.Length; i++)
            {
                string hex = value.Substring(i * 3 + 1, 2);
                int iHex = Convert.ToInt32(hex, 16);
                bytes[i] = Convert.ToByte(iHex);
            }
            return Encoding.Default.GetString(bytes);
        }
    }
}
