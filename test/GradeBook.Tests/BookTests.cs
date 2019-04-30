using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
    
        [Fact]
        public void BookCalculatesStats()
        {
            //arrange
            var book = new InMemoryBook("Sachin");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            Statistics result = book.GetStatistics();
            var actual = result.Average;

            //assert
            var expected = 85.6;
            Assert.Equal(expected, actual, 1);
            Assert.Equal(90.5, result.HighestGrade, 1);
            Assert.Equal(77.3, result.LowestGrade, 1);
            Assert.Equal('B', result.LetterGrade);
        }
    }
}
