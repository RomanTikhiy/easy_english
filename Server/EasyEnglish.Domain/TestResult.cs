using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEnglish.Domain
{
    public class TestResult
    {
        public int Id { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime PassingDate { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
