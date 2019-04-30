using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Sachin's grade book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            Statistics results = book.GetStatistics();
            Console.WriteLine($"{book.Name}'s Grades:The average grade is {results.Average:N1}, highest: {results.HighestGrade}, lowest: {results.LowestGrade}");
            Console.WriteLine($"The letter grade is {results.LetterGrade}");
        }

        private static void EnterGrades(IBook book)
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter a grade");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("a grade was added");
        }
    }
}
