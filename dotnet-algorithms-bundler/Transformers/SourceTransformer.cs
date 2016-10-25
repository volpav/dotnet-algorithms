using System.Linq;
using System.Collection.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algorithms.Bundler.Transformers
{
    /// <summary>
    /// Represents source code transformer.
    /// </summary>
    public abstract class SourceTransformer : CSharpSyntaxRewriter
    {
        /// <summary>
        /// Transforms the given syntax tree and returns a transformed one.
        /// </summary>
        /// <param name="tree">Syntax tree to transform.</param>
        public SyntaxTree Transform(SyntaxTree tree)
        {
            return CSharpSyntaxTree.Create(Visit(tree.GetRoot()) as CSharpSyntaxNode);
        }

        /// <summary>
        /// Transforms the given syntax tree by using all the source transformers passed as a list.
        /// </summary>
        /// <param name="tree">Syntax tree to transform.</param>
        /// <param name="transformers">Transformers to apply.</param>
        public static SyntaxTree TransformWithAll(SyntaxTree tree, IList<SourceTreeTransformer> transformers)
        {
            var ret = tree;
            var q = new Queue<SourceTreeTransformer>();

            foreach (var t in transformers)
            {
                q.Enqueue(t);
            }

            while (q.Count > 0)
            {
                var t = q.Dequeue();
                ret = t.Transform(ret);
            }

            return ret;
        }
    }
}