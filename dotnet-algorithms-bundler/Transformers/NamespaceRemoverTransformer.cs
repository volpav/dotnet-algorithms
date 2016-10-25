using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algorithms.Bundler.Transformers
{
    /// <summary>
    /// Removes namespaces from the given syntax node.
    /// </summary>
    public class NamespaceRemoverTransformer : SourceTransformer
    {
        
    }
}

