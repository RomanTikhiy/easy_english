using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEnglish.Domain
{
    public class Vocabulary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public ICollection<Word> Words { get; set; }
    }
}
