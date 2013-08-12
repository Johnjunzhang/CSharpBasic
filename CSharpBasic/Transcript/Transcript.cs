using NUnit.Framework;

namespace CSharpBasic.Transcript
{
    public class Transcript
    {
        public string Name { get; set; }
        public int? Chinese { get; set; }
        public int? English { get; set; }
        public int? Math { get; set; }

        public int TotalScore
        {
            get { return Chinese.GetValueOrDefault(0) + English.GetValueOrDefault(0) + Math.GetValueOrDefault(0); }
        }
    }

    public static class TranscriptExtension
    {
        public static string Print(this Transcript transcript)
        {
            return string.Format("Name: {0}, Chinese: {1}, English: {2}", transcript.Name, transcript.Chinese, transcript.English);
        }
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
                English = 80,
                Math = 80
            };
            Assert.AreEqual(240, transcript.TotalScore);
        }

        [Test]
        public void should_get_total_score_except_unregisted_score()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 80
            };
            Assert.AreEqual(160, transcript.TotalScore);
        }

        [Test]
        public void should_print_all_the_score_of_courses()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 81
            };
            Assert.AreEqual("Name: Li Lei, Chinese: 80, English: 81", transcript.Print());
        }
    }
}