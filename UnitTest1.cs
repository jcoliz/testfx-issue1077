using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testfx_issue1077;

[TestClass]
public class UnitTest1
{
    public static IEnumerable<object[]> Values => Enumerable.Range(1,10000).Select(x => new object[] { x });

    [DynamicData(nameof(Values), DynamicDataSourceType.Property)]
    [DataTestMethod]
    public void TestMethod1(int value)
    {
        for(int i = 0; i < value; i++)
            Console.WriteLine(i);
    }
}