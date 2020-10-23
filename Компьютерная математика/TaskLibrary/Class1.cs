using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
    public class Methods
    {
        public static void Hash(String[] S, HashSet<string> A)
        {
            for (int k = 0; k < S.Length; k++)
            {
                A.Add(S[k]);
            }
        }

        public static HashSet<string> CartesianProduct(string[] mas)
        {
            int l = mas.Length;
            string s;
            HashSet<String> result = new HashSet<String>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    s = "(" + mas[i] + "," + mas[j] + ")";
                    result.Add(s);
                }

            }
            return result;
        }

    }
}
