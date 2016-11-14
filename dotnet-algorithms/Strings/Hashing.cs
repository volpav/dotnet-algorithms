using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Strings
{
    public interface IHashCoefficientTable
    {
        int[] Values
        {
            get;
        }
    }

    public sealed class SimpleHashCoefficientTable : IHashCoefficientTable
    {
        private readonly int[] _values;

        public int[] Values
        {
            get { return _values; }
        }

        public SimpleHashCoefficientTable()
        {
            _values = new int[1 << 16];

            for (int i = 0; i < Values.Length; i++)
            {
                _values[i] = i;
            }
        }
    }

    public sealed class RandomizedHashCoefficientTable : IHashCoefficientTable
    {
        private readonly int[] _values;

        public int[] Values
        {
            get { return _values; }
        }

        public RandomizedHashCoefficientTable()
        {
            Random r = new Random();

            _values = new int[1 << 16];

            for (int i = 0; i < Values.Length; i++)
            {
                _values[i] = r.Next();
            }
        }
    }

    public class RabinKarpHash 
    {
        private sealed class RabinKarpHashEnumerable : IEnumerable<int>
        {
            private readonly string _input;
            private readonly int _blockSize;
            private readonly IHashCoefficientTable _hasher;

            public RabinKarpHashEnumerable(string s, int blockSize, IHashCoefficientTable hasher)
            {
                _input = s;
                _blockSize = blockSize;
                _hasher = hasher;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new RabinKarpHashEnumerator(_input, _blockSize, _hasher);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private sealed class RabinKarpHashEnumerator : IEnumerator<int>
        {
            private readonly string _input;
            private readonly int _blockSize;
            private readonly IHashCoefficientTable _hasher;

            private RabinKarpHash _hash;
            private bool _wasReset;
            private int _offset;

            public int Current
            {
                get { return _hash.Value; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public RabinKarpHashEnumerator(string s, int blockSize, IHashCoefficientTable hasher)
            {
                _input = s;
                _blockSize = blockSize;
                _hasher = hasher;

                if (s.Length < _blockSize)
                {
                    throw new ArgumentException("Block size cannot be smaller than input string length.", "blockSize");
                }

                Reset();
            }

            public bool MoveNext()
            {
                if (_wasReset)
                {
                    _wasReset = false;
                    return true;
                }
                else
                {
                    _offset += 1;
                    
                    if (_offset >= (_input.Length - _blockSize + 1))
                    {
                        return false;
                    }
                    else
                    {
                        _hash.Update(_input[_offset - 1], _input[_blockSize + _offset - 1]);

                        return true;
                    }
                }
            }

            bool IEnumerator.MoveNext()
            {
                return this.MoveNext();
            }

            public void Reset()
            {
                _wasReset = true;
                _offset = 0;

                _hash = new RabinKarpHash(_blockSize, _hasher);

                for (int i = 0; i < _blockSize; i++)
                {
                    _hash.Add(_input[i]);
                }
            }

            void IEnumerator.Reset()
            {
                this.Reset();
            }

            public void Dispose() { }
        }

        private readonly int _n;
        private readonly int _b = 31;
        private readonly int _b2n;
        private readonly IHashCoefficientTable _hasher;

        private int _value = 0;

        public int Value
        {
            get { return _value; }
        }

        public int BlockSize
        {
            get { return _n; }
        }

        public RabinKarpHash(int blockSize) : this(blockSize, new SimpleHashCoefficientTable()) { }

        public RabinKarpHash(int blockSize, IHashCoefficientTable hasher)
        {
            int b2n = 1;

            _n = blockSize;
            _hasher = hasher;

            for (int i = 0; i < _n; i++) 
            {
                b2n *= _b;
            }

            _b2n = b2n;
        }

        public int Add(char c)
        {
            _value = _b * _value + _hasher.Values[c];
 
            return _value;
        }

        public int Update(char remove, char add)
        {
            _value = _b * _value +_hasher.Values[add] - _b2n * _hasher.Values[remove];
		    
            return _value;
        }

        public static IEnumerable<int> RollOver(string s, int blockSize)
        {
            return new RabinKarpHashEnumerable(s, blockSize, new SimpleHashCoefficientTable());
        }
    }
}