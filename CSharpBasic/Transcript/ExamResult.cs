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

        public override bool Equals(object obj)
        {
            if(obj is Grade)
            {
                return Name.Equals((obj as Grade).Name);
            }
            return base.Equals(obj);
        }
    }

    public class ExamResult
    {
        public string Course { get; private set; }
        public List<Grade> Results { get; private set; } 

        public ExamResult(string course)
        {
            Course = course;
            Results = new List<Grade>();
        }

        public void Add(Grade grade)
        {
            if(Results.Contains(grade)) return;
            Results.Add(grade);
        }
    }

    public static class ExamResultExtension
    {
        public static List<Transcript> ToTranscripts(this ExamResult result, Func<Grade, Transcript> convert)
        {
            return result.Results.Select(convert).ToList();
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

        [Test]
        public void should_get_grade_after_added()
        {
            var kiteGrade = new Grade("Kite", 80);
            var results = new ExamResult("Math");
            results.Add(kiteGrade);
            Assert.AreEqual(1, results.Results.Count);
            Assert.AreEqual("Kite", results.Results[0].Name);
            Assert.AreEqual(80, results.Results[0].Score);
        }

        [Test]
        public void should_not_add_duplicate_grade_which_has_same_name_with_another()
        {
            var kiteGrade = new Grade("Kite", 80);
            var dupKiteGrade = new Grade("Kite", 90);
            var results = new ExamResult("Math");
            results.Add(kiteGrade);
            results.Add(dupKiteGrade);
            Assert.AreEqual(1, results.Results.Count);
            Assert.AreEqual("Kite", results.Results[0].Name);
            Assert.AreEqual(80, results.Results[0].Score);
        }

        [Test]
        public void should_convert_math_exam_result_to_a_list_of_transcripts()
        {
            var result = new ExamResult("Math");
            result.Add(new Grade("Li Lei", 80));
            result.Add(new Grade("Han Meimei", 90));

            var transcripts = result.ToTranscripts(grade => new Transcript{Name = grade.Name, Math = grade.Score});
            Assert.AreEqual(80, transcripts[0].Math);
            Assert.AreEqual("Li Lei", transcripts[0].Name);
            Assert.AreEqual(90, transcripts[1].Math);
            Assert.AreEqual("Han Meimei", transcripts[1].Name);
        }

        [Test]
        public void should_convert_english_exam_result_to_a_list_of_transcripts()
        {
            var result = new ExamResult("English");
            result.Add(new Grade("Li Lei", 80));
            result.Add(new Grade("Han Meimei", 90));

            var transcripts = result.ToTranscripts(grade => new Transcript { Name = grade.Name, English = grade.Score });
            Assert.AreEqual(80, transcripts[0].English);
            Assert.AreEqual("Li Lei", transcripts[0].Name);
            Assert.AreEqual(90, transcripts[1].English);
            Assert.AreEqual("Han Meimei", transcripts[1].Name);
        }
    }
}
