using System;
using System.Collections.Generic;

namespace LearnEnglish.WPF.Models.EntityFramework
{
    public partial class DictionaryWord
    {
        public int Id { get; set; }
        public int Lesson { get; set; }
        public string English { get; set; } = null!;
        public string Transcription { get; set; } = null!;
        public string Russian1 { get; set; } = null!;
        public string? Russian2 { get; set; }
        public string? Russian3 { get; set; }
        public string? Remark { get; set; }
        public string? Pictures { get; set; }
        public string? Vois { get; set; }
    }
}
