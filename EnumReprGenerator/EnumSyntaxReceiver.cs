using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SandboxGenerator
{
    public class EnumSyntaxReceiver : ISyntaxReceiver
    {
        public List<EnumDeclarationSyntax> EnumDeclarationNodes { get; } = new();
        
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is EnumDeclarationSyntax enumDeclarationSyntax)
            {
                EnumDeclarationNodes.Add(enumDeclarationSyntax);
            }
        }
    }
}