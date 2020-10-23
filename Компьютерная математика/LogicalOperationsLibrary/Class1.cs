using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace LogicalOperationsLibrary
{
    public class LogicalOperations
    {
        public static BitArray And(BitArray X, BitArray Y)
        {
            BitArray n = X.And(Y);
            return n;
        }

        public static BitArray Or(BitArray X, BitArray Y)
        {
            BitArray n = X.Or(Y);
            return n;
        }

        public static BitArray Not(BitArray X)
        {
            BitArray n = X.Not();
            return n;
        }

        public static BitArray Dif(BitArray X, BitArray Y)
        {
            BitArray n = And(X, Not(Y));
            return n;
        }

    }
}
