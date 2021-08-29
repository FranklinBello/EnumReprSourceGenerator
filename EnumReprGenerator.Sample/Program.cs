using System;
using EnumExtension;
using SandboxGenerator.Sample.Enums;

namespace SandboxGenerator.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Numbers.One.Repr());
            Console.WriteLine(Letters.A.Repr());
        }
    }
}