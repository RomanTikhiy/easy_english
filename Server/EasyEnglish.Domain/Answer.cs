namespace EasyEnglish.Domain
{
    public class Answer
    {
        public int Id { get; set; }

        public TestResult TestResult { get; set; }

        public int TestResultId { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

        public bool IsRight { get; set; }
    }
}
