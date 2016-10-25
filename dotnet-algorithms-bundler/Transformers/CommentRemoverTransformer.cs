using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Algorithms.Bundler.Transformers
{
    /// <summary>
    /// Removes comments from the given syntax node.
    /// </summary>
    public class CommentRemoverTransformer : SourceTransformer
    {
        /// <summary>
        /// Visits the given syntax trivia.
        /// </summary>
        /// <param name="trivia">Trivia to visit.</param>
        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia.IsKind(SyntaxKind.SingleLineCommentTrivia) || 
                trivia.IsKind(SyntaxKind.MultiLineCommentTrivia))
            {
                return default(SyntaxTrivia);
            }

            return trivia;
        }
    }
}

