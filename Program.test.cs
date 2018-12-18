using System;
using Xunit;

namespace cstest
{
    public class ProgramTest
    {
        [Fact]
        public void SayHi_Writes_HelloMessage()
        {
            string actual = null;
            Program.SayHi(str => actual = str);

            Assert.Equal("Hello World!", actual);
        }
    }
}
