
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name { get; set; }

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
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


            return result;
        }
    }
}