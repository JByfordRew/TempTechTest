using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using WordCounter;
using Xunit;

namespace XUnitTestOTRWordCount.Unit
{
    public class TextWordCounterClassTest
    {
        private readonly TextWordCounter sut;

        public TextWordCounterClassTest()
        {
            sut = new TextWordCounter();
        }

        [Fact]
        public void ShouldHandleWhitespace()
        {
            //given
            var content = "abc abc abc def  def   ghi\r\njkl mno";

            //when
            var actual = sut.CountWords(content);

            //then
            actual.Count.Should().Be(5);
            actual.First().Should().BeEquivalentTo(new KeyValuePair<string, int>("abc", 3));
            actual.Last().Should().BeEquivalentTo(new KeyValuePair<string, int>("mno", 1));
        }

        [Fact]
        public void ShouldBeCaseInsensitive()
        {
            //given
            var content = "abc ABC abc def def";

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.First().Should().BeEquivalentTo(new KeyValuePair<string, int>("abc", 3));            
        }

        [Fact]
        public void ShouldIgnoreNumbersInWords()
        {
            //given
            var content = "abc abc2 abc3 def";

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.Count.Should().Be(2);
            actual.First().Should().BeEquivalentTo(new KeyValuePair<string, int>("abc", 1));
        }

        [Fact]
        public void ShouldIgnoreHypensWords()
        {
            //TODO this can be an improvement later on but for the known use case this is acceptable.

            //given
            var content = "abc ab-c abc def";

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.Count.Should().Be(2);
            actual.First().Should().BeEquivalentTo(new KeyValuePair<string, int>("abc", 2));
        }

        [Fact]
        public void ShouldIgnorePunctuation()
        {
            //TODO this can be an improvement later on but for the known use case this is acceptable.

            //given
            var content = "abc abc, abc def";

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.Count.Should().Be(2);
            actual.First().Should().BeEquivalentTo(new KeyValuePair<string, int>("abc", 2));
        }

        [Fact]
        public void ShouldAcceptAccents()
        {
            //given
            var content = "déf def def déf déf";

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.Count.Should().Be(2);
            actual.First().Should().BeEquivalentTo(new KeyValuePair<string, int>("déf", 3));
        }

        [Fact]
        public void ShouldHandleMissingText()
        {             
            //given
            var content = "";

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.Count.Should().Be(0);            
        }

        [Fact]
        public void ShouldHandleNullValue()
        {
            //given
            string content = null;

            //when
            var actual = sut.CountWords(content);

            //then            
            actual.Count.Should().Be(0);
        }


    }
}
