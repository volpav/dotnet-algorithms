/* Copyright (C) 2016 Kattis Team.
 * https://open.kattis.com/help/csharp
 */

using System;
using System.IO;

namespace Algorithms.IO
{
    /// <summary>
    /// Occurs when no more tokens can be read from the input stream.
    /// </summary>
    public class NoMoreTokensException : Exception { }

    /// <summary>
    /// Represents a tokenizer.
    /// </summary>
    public class Tokenizer
    {
        string[] tokens = new string[0];
        private int pos;
        StreamReader reader;

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        public Tokenizer() : this(Console.OpenStandardInput()) { }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="inStream">Input stream.</param>
        public Tokenizer(Stream inStream)
        {
            var bs = new BufferedStream(inStream);
            reader = new StreamReader(bs);
        }

        /// <summary>
        /// Returns the next available token or null if no more tokens can be read. The reader position is not advanced when calling this method.
        /// </summary>
        /// <returns>Token.</returns>
        private string PeekNext()
        {
            if (pos < 0)
            {
                // pos < 0 indicates that there are no more tokens
                return null;
            }
                
            if (pos < tokens.Length)
            {
                if (tokens[pos].Length == 0)
                {
                    ++pos;
                    return PeekNext();
                }
                return tokens[pos];
            }
            string line = reader.ReadLine();
            if (line == null)
            {
                // There is no more data to read
                pos = -1;
                return null;
            }
            // Split the line that was read on white space characters
            tokens = line.Split(null);
            pos = 0;
            return PeekNext();
        }

        /// <summary>
        /// Returns value indicating whether there's a next token to be read.
        /// </summary>
        /// <returns>Value indicating whether there's a next token to be read.</returns>
        public bool HasNext()
        {
            return (PeekNext() != null);
        }

        /// <summary>
        /// Returns the next token.
        /// </summary>
        /// <returns>Next token.</returns>
        /// <exception cref="NoMoreTokensException">Occurs when there are no more tokens to be read.</exception>
        public string Next()
        {
            string next = PeekNext();
            if (next == null)
                throw new NoMoreTokensException();
            ++pos;
            return next;
        }
    }

    /// <summary>
    /// Represents a scanner.
    /// </summary>
    public class Scanner : Tokenizer
    {
        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        public Scanner() : base() { }

        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        /// <param name="inStream">Input stream.</param>
        public Scanner(Stream inStream) : base(inStream) { }

        /// <summary>
        /// Reads the next token as 32-bit integer.
        /// </summary>
        /// <returns>Next token.</returns>
        public int NextInt()
        {
            return int.Parse(Next());
        }

        /// <summary>
        /// Reads the next token as 64-bit integer.
        /// </summary>
        /// <returns>Next token.</returns>
        public long NextLong()
        {
            return long.Parse(Next());
        }

        /// <summary>
        /// Reads the next token as 32-bit floating-point number.
        /// </summary>
        /// <returns>Next token.</returns>
        public float NextFloat()
        {
            return float.Parse(Next());
        }

        /// <summary>
        /// Reads the next token as 64-bit floating-point number.
        /// </summary>
        /// <returns>Next token.</returns>
        public double NextDouble()
        {
            return double.Parse(Next());
        }
    }

    /// <summary>
    /// Represents buffered writer that writes to standard output.
    /// </summary>
    public class BufferedStdoutWriter : StreamWriter
    {
        /// <summary>
        /// Initializes a new instance of an object.
        /// </summary>
        public BufferedStdoutWriter() : base(new BufferedStream(Console.OpenStandardOutput())) { }
    }
}