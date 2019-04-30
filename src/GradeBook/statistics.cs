
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double HighestGrade { get; set; }
        public double LowestGrade { get; set; }

        public double Sum { get; set; }
        public int Count { get; set; }

        public char LetterGrade
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return LetterGrade = 'A';
                    case var d when d >= 80.0:
                        return LetterGrade = 'B';
                    case var d when d >= 70.0:
                        return LetterGrade = 'C';
                    case var d when d >= 60.0:
                        return LetterGrade = 'D';
                    default:
                        return LetterGrade = 'F';
                }
            }
            set { }
        }


        public Statistics()
        {
            // Average = 0.0;
            HighestGrade = double.MinValue;
            LowestGrade = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            LowestGrade = Math.Min(number, LowestGrade);
            HighestGrade = Math.Max(number, HighestGrade);
        }
        public Statistics calculateStatistics(List<double> grades)
        {
            var result = new Statistics();
            var index = 0;
            foreach (var grade in grades)
            {
                result.Add(grades[index]);
                index++;
            }
            return result;
        }
    }
}
