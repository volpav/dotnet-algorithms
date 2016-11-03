/* Copyright (C) 2016 Kattis Team.
 * https://open.kattis.com/help/csharp
 */

using System;
using System.IO;

namespace Algorithms.IO
{
    public class NoMoreTokensException : Exception { }

    public class Tokenizer
    {
        string[] _tokens = new string[0];
        private int _pos;
        StreamReader _reader;

        public Tokenizer() : this(Console.OpenStandardInput()) { }

        public Tokenizer(Stream inStream)
        {
            _reader = new StreamReader(new BufferedStream(inStream));
        }

        private string PeekNext()
        {
            if (_pos < 0)
            {
                return null;
            }
                
            if (_pos < _tokens.Length)
            {
                if (_tokens[_pos].Length == 0)
                {
                    ++_pos;
                    return PeekNext();
                }

                return _tokens[_pos];
            }

            string line = _reader.ReadLine();

            if (line == null)
            {
                _pos = -1;
                return null;
            }

            _tokens = line.Split(null);
            _pos = 0;

            return PeekNext();
        }

        public bool HasNext()
        {
            return (PeekNext() != null);
        }

        public string Next()
        {
            string next = PeekNext();

            if (next == null)
            {
                throw new NoMoreTokensException();
            }
                
            ++_pos;

            return next;
        }
    }

    public class Scanner : Tokenizer
    {
        public Scanner() : base() { }

        public Scanner(Stream inStream) : base(inStream) { }

        public int NextInt()
        {
            return int.Parse(Next());
        }

        public long NextLong()
        {
            return long.Parse(Next());
        }

        public float NextFloat()
        {
            return float.Parse(Next());
        }

        public double NextDouble()
        {
            return double.Parse(Next());
        }
    }

    public class BufferedStdoutWriter : StreamWriter
    {
        public BufferedStdoutWriter() : base(new BufferedStream(Console.OpenStandardOutput())) { }
    }
}