using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEnglish.Domain
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string NativeLanguage { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Photo { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
