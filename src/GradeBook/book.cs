
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
      public string Name { get; private set; }

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"The {nameof(grade)} is invalid");
            }

        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.HighestGrade = double.MinValue;
            result.LowestGrade = double.MaxValue;

            foreach (var grade in grades)
            {
                result.HighestGrade = Math.Max(grade, result.HighestGrade);
                result.LowestGrade = Math.Min(grade, result.LowestGrade);
                result.Average += grade;

            }
            result.Average = result.Average / grades.Count;
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.LetterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    result.LetterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    result.LetterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    result.LetterGrade = 'D';
                    break;
                default:
                    result.LetterGrade = 'F';
                    break;
            }

            return result;
        }
    }
}