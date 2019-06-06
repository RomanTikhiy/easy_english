using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEnglish.Domain
{
    public class Test
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public TestType Type { get; set; }


    }

    public enum TestType
    {
        Grammar,
        Vocabulary
    }
}
