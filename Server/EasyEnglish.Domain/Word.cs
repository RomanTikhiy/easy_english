using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEnglish.Domain
{
    public class Word
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string Text { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public Vocabulary Vocabulary { get; set; }

        public string VocabularyId { get; set; }
    }
}
