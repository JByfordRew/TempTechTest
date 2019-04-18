using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using WordCounter;
using Xunit;

namespace XUnitTestOTRWordCount
{
    public class WordCounterBehaviour
    {
        private readonly ICountWords sut;

        public WordCounterBehaviour()
        {
            sut = new FileWordCounter();
        }

        [Theory]
        [InlineData("example-lotr-fotr.txt", "a:1,b:2,c:3,d:4,e:5,f:6,g:7,h:8,i:9,j:10")]
        public void ShouldOutput(string filename, string expectedTop10)
        {
            //given
            var expect = ListFrom(expectedTop10);

            //when
            var actual = sut.CountWords(filename);

            //then
            actual.Should().BeEquivalentTo(expect);
        }

        private List<KeyValuePair<string,int>> ListFrom(string expectedTop10)
        {
            return expectedTop10
               .Split(',')
               .Select(x => x.Split(':'))
               .Select(x=> new KeyValuePair<string, int>(x[0], int.Parse(x[1])))
               .ToList();
        }
    }
}
