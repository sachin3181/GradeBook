using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessgage);


    public class TypeTests
    {
        [Fact]
        public void writeLogdelegateCanPointToMethod()
        {
            //Given
            WriteLogDelegate log;
            log = new WriteLogDelegate(ReturnMessage);
            //When
            var result = log("Hello");
            //Then
            Assert.Equal("Hello", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void StringsbehaveLikeValueTypes()
        {
            string name = "Sachin";
            MakeUpperCase(name);

            Assert.Equal("Sachin", name);
        }

        private void MakeUpperCase(string param)
        {
            param.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            //Given
            var x = GetInt();
            SetInt(ref x);
            //When

            //Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByRef()
        {
            //Given
            var book1 = GetBook("Book 1");

            //When
            GetBookSetName(ref book1, "New Name");

            //Then
            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book1, string newName)
        {
            book1 = new InMemoryBook(newName);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //Given
            var book1 = GetBook("Book 1");

            //When
            GetBookSetName(book1, "New Name");

            //Then
            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book1, string newName)
        {
            book1 = new InMemoryBook(newName);
        }


        [Fact]
        public void SetBookNameFromReference()
        {
            //Given
            var book1 = GetBook("Book 1");

            //When
            SetName(book1, "New Name");

            //Then
            Assert.NotEqual("New Name", book1.Name);

        }

        private void SetName(InMemoryBook book1, string newName)
        {
            // book1.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
