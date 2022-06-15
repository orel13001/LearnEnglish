using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.WPF.Models.AddToDictionary
{
    public class AddWord
    {
        public int Lesson { get; set; }
        public string English { get; set; }
        public string Transcription { get; set; }
        public string Russian { get; set; }
        public string? Comment { get; set; }
        public string Pictures { get; set; }
        public string Vois { get; set; }

    }
}
