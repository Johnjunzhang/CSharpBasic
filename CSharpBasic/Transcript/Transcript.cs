using NUnit.Framework;

namespace CSharpBasic.Transcript
{
    public class Transcript
    {
        public string Name { get; set; }
        public int Chinese { get; set; }
        public int English { get; set; }
    }

    public class TranscriptTest
    {
        [Test]
        public void should_get_total_score()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 80
            };
//            Assert.AreEqual(160, transcript.TotalScore);
        }
    }
}