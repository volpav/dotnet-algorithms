using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Algorithms.Bundler.SourceCode
{
    /// <summary>
    /// Represents source code rewrite task.
    /// </summary>
    public abstract class SourceCodeRewriteTask : CSharpSyntaxRewriter
    {
        /// <summary>
        /// Rewrites the given syntax tree and returns a rewritten one.
        /// </summary>
        /// <param name="tree">Syntax tree to rewrite.</param>
        public SyntaxTree Rewrite(SyntaxTree tree)
        {
            return CSharpSyntaxTree.Create(Visit(tree.GetRoot()) as CSharpSyntaxNode);
        }

        /// <summary>
        /// Rewrites the given syntax tree by using all the source code rewriters passed as a list.
        /// </summary>
        /// <param name="tree">Syntax tree to rewrite.</param>
        /// <param name="rewriters">Rewriters to apply.</param>
        public static SyntaxTree RewriteWithAll(SyntaxTree tree, IList<SourceCodeRewriteTask> rewriters)
        {
            var ret = tree;
            var q = new Queue<SourceCodeRewriteTask>();

            foreach (var rw in rewriters)
            {
                q.Enqueue(rw);
            }

            while (q.Count > 0)
            {
                var rw = q.Dequeue();
                ret = rw.Rewrite(ret);
            }

            return ret;
        }
    }
}