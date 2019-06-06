using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEnglish.Domain
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string RightAnswer { get; set; }

        public QuestionType Type { get; set; }

        public Test Test { get; set; }

        public int TestId { get; set; }
    }

    public enum QuestionType
    {
        Translation,
        CompleteTheSentence
    }
}
