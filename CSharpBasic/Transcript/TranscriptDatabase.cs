using System.Collections.Generic;
using NUnit.Framework;

namespace CSharpBasic.Transcript
{
    public class TranscriptDatabase
    {
        public List<Transcript> Transcripts { get; private set; }

        public TranscriptDatabase()
        {
            Transcripts = new List<Transcript>();
        }

        public void Register(ExamResult result)
        {
            result.ToTranscripts().
                ForEach(newTranscript =>
                            {
                                var found = Transcripts.Find(transcript => transcript.Name == newTranscript.Name);
                                if(found != null)
                                {
                                    found.Merge(newTranscript);    
                                }
                                else
                                {
                                    Transcripts.Add(newTranscript.Clone());
                                }
                            });
        }

        public Transcript GetByName(string name)
        {
            return Transcripts.Find(t => t.Name == name);
        }
    }

    public class TranscriptDatabaseTest
    {
        [Test]
        public void shoule_register_exam_result()
        {
            var database = new TranscriptDatabase();
            database.Register(GivenChineseExamResult());
            database.Register(GivenMathExamResult());

            Assert.AreEqual(80, database.GetByName("Li Lei").Math);
            Assert.AreEqual(90, database.GetByName("Han Meimei").Math);
        }

        private ExamResult GivenMathExamResult()
        {
            var result = new ExamResult("Math");
            result.Add(new Grade("Li Lei", 80));
            result.Add(new Grade("Han Meimei", 90));
            return result;
        }

        private ExamResult GivenChineseExamResult()
        {
            var result = new ExamResult("Chinese");
            result.Add(new Grade("Li Lei", 80));
            result.Add(new Grade("Han Meimei", 90));
            return result;
        }
    }
}
