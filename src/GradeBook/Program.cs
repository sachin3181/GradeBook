using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Sachin's grade book");

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
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(12.7);
            // book.AddGrade(10.3);
            // book.AddGrade(4.1);

            Statistics results = book.GetStatistics();
            Console.WriteLine($"{book.Name}'s Grades:The average grade is {results.Average:N1}, highest: {results.HighestGrade}, lowest: {results.LowestGrade}");
            Console.WriteLine($"The letter grade is {results.LetterGrade}");
        }
    }
}
