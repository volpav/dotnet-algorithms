using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Algorithms.Bundler.SourceCode
{
    /// <summary>
    /// Removes comments from the given syntax node.
    /// </summary>
    public class RemoveCommentsTask : SourceCodeRewriteTask
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

