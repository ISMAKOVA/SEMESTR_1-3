using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TaskLibrary.Tests
{
    [TestClass()]
    public class MyClassTests
    {


        [TestMethod()]
        public void getCombinationsTest()
        {
            var digits = new string[]{"0", "2"};
            var actual = Methods.CartesianProduct(digits).OrderBy(x=>x).ToList();
            var expected = new List<string> { "(0,0)","(0,2)","(2,0)","(2,2)" };
            CollectionAssert.AreEqual(actual, expected);
        }

    }
}