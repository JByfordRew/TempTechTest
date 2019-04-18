using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using WordCounter;
using WordCounter.IO;
using Xunit;

namespace XUnitTestOTRWordCount.Unit
{
    public class FileWordCounterClassTest
    {       
        public class GivenFilepathAndTopCount
        {
            private readonly Mock<ITextReader> mockFileTextReader;
            private readonly Mock<IWordCounter> mockTextWordCounter;
            private readonly FileTopWordCounter sut;
            private readonly string filepath;
            private readonly int topCount;
            private readonly string content;

            public GivenFilepathAndTopCount()
            {
                mockFileTextReader = new Mock<ITextReader>();
                mockTextWordCounter = new Mock<IWordCounter>();
                sut = new FileTopWordCounter(mockFileTextReader.Object, mockTextWordCounter.Object);

                filepath = "fake filepath";
                topCount = 10;
                content = "fake content";
                FileTextReaderReturnsContent(filepath, content);
                TextWordCounterReturnsWordCount(content, topCount);
            }

            [Fact]
            public void ShouldGetTextFromSourceFilepath()
            {
                //when
                sut.CountTopWords(filepath, topCount);

                //then
                mockFileTextReader.Verify(x => x.SourceText(filepath));
            }

            [Fact]
            public void ShouldCountWordsOfContent()
            {
                //when
                var actual = sut.CountTopWords(filepath, topCount);

                //then
                mockTextWordCounter.Verify(x => x.CountWords(content));
                actual.Count.Should().Be(topCount);
            }

            [Fact]
            public void ShouldReturnResultsInDescendingOrder()
            {
                //when
                var actual = sut.CountTopWords(filepath, topCount);

                //then            
                actual.Should().BeEquivalentTo(actual.OrderByDescending(x => x.Value));
            }

            private void TextWordCounterReturnsWordCount(string content, int topCount)
            {
                var wordCounts = new List<KeyValuePair<string, int>>();
                for (int i = 0; i < topCount; i++)
                {
                    wordCounts.Add(new KeyValuePair<string, int>($"word{i}", i));
                }
                mockTextWordCounter.Setup(x => x.CountWords(content)).Returns(wordCounts);
            }

            private void FileTextReaderReturnsContent(string filepath, string content)
            {
                mockFileTextReader.Setup(x => x.SourceText(filepath)).Returns(content);
            }
        }
    }
}
