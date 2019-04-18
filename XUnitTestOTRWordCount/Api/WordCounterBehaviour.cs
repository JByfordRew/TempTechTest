using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using WordCounter;
using WordCounter.IO;
using Xunit;

namespace XUnitTestOTRWordCount
{
    public class WordCounterBehaviour
    {
        private readonly ITopWordCounter sut;

        public WordCounterBehaviour()
        {
            sut = new ParallelFileLineTopWordCounter();
            //sut = new FileTopWordCounter(new FileTextReader(), new TextWordCounter());
        }

        [Theory]
        [InlineData("example-lotr-fotr.txt", "the:11676,and:7353,of:5069,to:3899,a:3689,he:2894,in:2882,was:2431,that:2339,i:2194")]
        public void ShouldOutput(string filename, string expectedTop10)
        {
            //given
            var expect = ListFrom(expectedTop10);

            //when
            var actual = sut.CountTopWords(filename, 10);

            //thennote
            actual.Count.Should().Be(10);
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
