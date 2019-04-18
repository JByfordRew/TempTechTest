using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WordCounter.IO;
using Xunit;

namespace XUnitTestOTRWordCount.Unit
{
    public class FileTextReaderClassTest
    {
        private readonly FileTextReader sut;

        public FileTextReaderClassTest()
        {
            sut = new FileTextReader();
        }

        [Fact]
        public void ShouldReturnContentForFile()
        {
            //given
            var filepath = "example-lotr-fotr.txt";

            //when
            var actual = sut.SourceText(filepath);

            //then
            actual.Should().NotBeNullOrWhiteSpace();
            actual.Length.Should().Be(1018644);
            actual.Should().Contain("Frodo");
            //TODO matter of opinion whether to assert multiple things in one unit test.  I allow it.
        }

        [Fact]
        public void ShouldErrorIfFileNotFound()
        {
            //given
            var filepath = "unknown";

            //when
            Func<string> func = () => sut.SourceText(filepath);

            //then
            func.Should().Throw<FileNotFoundException>();
        }
    }
}
