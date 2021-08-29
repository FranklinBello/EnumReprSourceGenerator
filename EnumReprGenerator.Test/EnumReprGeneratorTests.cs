using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;
using Xunit.Abstractions;

namespace SandboxGenerator.Test
{
    public class EnumReprGeneratorTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public EnumReprGeneratorTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShouldProduceSource()
        {
            var inputCompilation = CreateCompilation(@"
using System;

namespace MyProject.Domain.Enums
{
    public enum Numbers { One, Two, Three }
    public enum Colors { Red, Green, Blue }
}

namespace MyProject
{
    public static void Main()
    {
        var number = Numbers.One;
        Console.WriteLine(number.ToString());
    }
}
");
            var generator = new EnumReprGenerator();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation,
                out var diagnostics);

            var runResult = driver.GetRunResult();
            var generatorResult = runResult.Results[0];
            _testOutputHelper.WriteLine(generatorResult.GeneratedSources.First().SourceText.ToString());
        }
        
        private static Compilation CreateCompilation(string source)
            => CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    }
}