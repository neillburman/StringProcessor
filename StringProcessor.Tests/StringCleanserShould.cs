using System;
using Xunit;
using Xunit.Abstractions;

namespace StringProcessor.Tests
{
    public class StringCleanserShould : IDisposable
    {
        private readonly IStringCleanser _mockobject;

        private readonly StringProcessorAnalyzer _analyser;
        private readonly ITestOutputHelper _output;


        public StringCleanserShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating new StringCleanser");

            _mockobject = new StringCleanser();
            _analyser = new StringProcessorAnalyzer(_mockobject);
        }

        public void Dispose()
        {
          //  _output.WriteLine($"Disposing of Cleanse {_analyser.}");
        }

        [Fact]
        public void ReadCleanData()
        {
            string TestData = "ABCDEF";
            string ExpectedOutput = "ABCDEF";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);
        }

        [Fact]
        public void RemoveDuplicateData()
        {

            string TestData = "AABCDEF";
            string ExpectedOutput = "ABCDEF";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);
        }

        [Fact]
        public void ChangeDollarSymbolToPoundSymbol()
        {

            string TestData = "$A$CDEF";
            string ExpectedOutput = "£A£CDEF";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);

        }

        [Fact]
        public void NotChangePoundSymbolDollarSymbolToPoundSymbol()
        {

            string TestData = "£A£CDEF";
            string ExpectedOutput = "$A$CDEF";

            StringCleanser sut = new StringCleanser();

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.NotEqual(ExpectedOutput, CleansedString);
        }

        [Fact]
        public void RemoveContiguousData()
        {

            string TestData = "AAAAAA";
            string ExpectedOutput = "A";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);
        }

        [Fact]
        public void RemoveContiguousDataFromContiguousAndNotContiguous()
        {

            string TestData = "AAABCCFGG";
            string ExpectedOutput = "ABCFG";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);

        }

        [Fact]
        public void RemoveAnyFourCharacter()
        {
            string TestData = "ABCD4F";
            string ExpectedOutput = "ABCDF";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);

        }

        [Fact]
        public void RemoveAnyUnderscoreCharacter()
        {
            string TestData = "ABCD_F";
            string ExpectedOutput = "ABCDF";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutput, CleansedString);

        }

        [Fact]
        public void MaximumLengthFifteen()
        {
 
            string TestData = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int ExpectedOutputLength = 15;

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.Equal(ExpectedOutputLength, CleansedString.Length);

        }

        [Fact]
        public void ReturnValueIsNotNull()
        {
              
            string TestData = "ABCDEFG";

            string CleansedString = _analyser.CleanInputString(TestData);

            Assert.NotNull(CleansedString);

        }

    }
}
