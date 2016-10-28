using Microsoft.CodeAnalysis;

namespace Algorithms.Bundler.SourceCode
{
    /// <summary>
    /// Removes namespaces from the given syntax node.
    /// </summary>
    public class RemoveNamespacesTask : SourceCodeRewriteTask
    {
        public override SyntaxNode Visit(SyntaxNode node)
        {
            return base.Visit(node);
        }
    }
}

