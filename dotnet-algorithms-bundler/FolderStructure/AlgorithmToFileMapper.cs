using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Bundler.FolderStructure
{
    /// <summary>
    /// Represents algorithm to file mapper.
    /// </summary>
    public class AlgorithmToFileMapper
    {
        /// <summary>
        /// Represents algorithm info.
        /// </summary>
        private class AlgorithmInfo
        {
            /// <summary>
            /// Gets or sets the list of aliases.
            /// </summary>
            public IEnumerable<string> Aliases { get; set; }

            /// <summary>
            /// Gets or sets the file name in which algorithm resides.
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// Gets or sets algorithm description.
            /// </summary>
            public string Description { get; set; }
        }

        public IEnumerable<string> ResolveFiles(IEnumerable<string> aliases)
        {
            var mapping = BuildAliasToFileMapping();

            var files = aliases.Select(alias => mapping.ContainsKey(alias) ? mapping[alias] : null)
                .Where(file => file != null)
                .Distinct();

            files = ReorderFiles(files);

            return files;
        }

        /// <summary>
        /// Reorders files so that the concatenated output has better logical structure.
        /// </summary>
        /// <param name="files">Files to order.</param>
        /// <returns>Reordered files.</returns>
        private IEnumerable<string> ReorderFiles(IEnumerable<string> files)
        {
            var array = files.ToArray();

            for (var i = 1; i < array.Length; i++)
            {
                // Moving I/O helper to the top.
                if (array[i].EndsWith("Scanner.cs", StringComparison.OrdinalIgnoreCase))
                {
                    var temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;

                    break;
                }
            }

            return array;
        }

        private IDictionary<string, string> BuildAliasToFileMapping()
        {
        }
    }
}
