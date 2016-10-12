using System;
using System.Text;
using System.IO;
using Xunit;

namespace Tests
{
    public abstract class TestBase
    {
        protected Stream CreateStream(string data)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(data));
        }
    }
}