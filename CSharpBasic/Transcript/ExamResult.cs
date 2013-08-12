using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CSharpBasic.Transcript
{
    public class Grade
    {
        [Display]
        public string Name { get; private set; }
        [Display]
        public int Score { get; private set; }

        public Grade(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public class ExamResult
    {
        public string Course { get; private set; }
        public List<Grade> Results { get; set; } 

        public ExamResult(string course)
        {
            Course = course;
        }
    }

    public class ExamResultTest
    {
        [Test]
        public void should_print_grade()
        {
            var grade = new Grade("Kite", 80);
            Assert.AreEqual("Name: Kite, Score: 80", grade.Print());
        }
    }
}
