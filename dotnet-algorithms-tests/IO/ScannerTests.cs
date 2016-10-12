using System;
using Xunit;

using Algorithms.IO;

namespace Tests.IO
{
    public class ScannerTests : TestBase
    {
        [Fact]
        public void CanReadMultipleTokens()
        {
            var tokens = new string[] { "token_1", "token_2", "token_3" };

            var scanner = new Scanner(CreateStream(
                string.Join(" ", tokens)
            ));

            foreach (var token in tokens)
            {
                var t = scanner.Next();
                Assert.True(t == token);
            }

            Assert.True(!scanner.HasNext());

            try
            {
                scanner.Next();
            }
            catch (Exception ex)
            {
                Assert.True(ex is NoMoreTokensException);
            }
        }

        [Fact]
        public void CanReadNewLineSeparatedTokens()
        {
            var tokens = new string[] { "token_1", "token_2", "token_3" };

            var scanner = new Scanner(CreateStream(
                string.Join("\n", tokens)
            ));

            foreach (var token in tokens)
            {
                var t = scanner.Next();
                Assert.True(t == token);
            }

            Assert.True(!scanner.HasNext());
        }

        [Fact]
        public void CanConvertToNumbers()
        {
            var tokens = new string[] { "123", "9223372036854775806", "5.6", "1797693134862316800886484.4324238943284923" };

            var scanner = new Scanner(CreateStream(
                string.Join("\n", tokens)
            ));

            var t1 = scanner.NextInt();
            Assert.True(t1 == int.Parse(tokens[0]));

            var t2 = scanner.NextLong();
            Assert.True(t2 == long.Parse(tokens[1]));

            var t3 = scanner.NextFloat();
            Assert.True(t3 == float.Parse(tokens[2]));

            var t4 = scanner.NextDouble();
            Assert.True(t4 == double.Parse(tokens[3]));

            Assert.True(!scanner.HasNext());
        }
    }
}
