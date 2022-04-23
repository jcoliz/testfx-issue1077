using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

namespace testfx_issue1077;

[TestClass]
public class UnitTest1
{
    public static IEnumerable<object[]> Values => Enumerable.Range(1,100).Select(x => new object[] { x });

    private byte[] MakeHash(int value)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = Enumerable.Repeat<byte>((byte)(value%255),1024).ToArray();        
        return md5.ComputeHash(inputBytes);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Property)]
    public void Hash1(int value)
    {
        var hash = MakeHash(value);
        Console.WriteLine("{0}", Convert.ToHexString(hash));
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Property)]
    public void Hash2(int value)
    {
        var hash = MakeHash(value);
        Console.WriteLine("{0}", Convert.ToHexString(hash));
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Property)]
    public void Hash3(int value)
    {
        var hash = MakeHash(value);
        Console.WriteLine("{0}", Convert.ToHexString(hash));
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Property)]
    public void Hash4(int value)
    {
        var hash = MakeHash(value);
        Console.WriteLine("{0}", Convert.ToHexString(hash));
    }
}