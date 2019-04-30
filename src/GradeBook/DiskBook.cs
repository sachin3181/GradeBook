using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book, IBook
    {
        private string name;
        private List<double> grades;
        public DiskBook(string name) : base(name)
        {
            this.name = name;
            grades = new List<double>();
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {

            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }

            //File.WriteAllText($"{Name}.txt", string.Empty);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            File.Delete($"{Name}.txt");
            return result;
        }
    }
}