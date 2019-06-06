using System;
using System.Collections.Generic;

namespace EasyEnglish.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserInfo UserInfo { get; set; }

        public ICollection<Vocabulary> Vocabularies { get; set; }

        public ICollection<TestResult> TestResults { get; set; }
    }
}
