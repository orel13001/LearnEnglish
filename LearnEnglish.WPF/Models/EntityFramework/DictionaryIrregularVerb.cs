using System;
using System.Collections.Generic;

namespace LearnEnglish.WPF.Models.EntityFramework
{
    public partial class DictionaryIrregularVerb
    {
        public int Id { get; set; }
        public int Lesson { get; set; }
        public string Present { get; set; } = null!;
        public string PresentTranscription { get; set; } = null!;
        public string? PresentVois { get; set; }
        public string Past { get; set; } = null!;
        public string PastTranscription { get; set; } = null!;
        public string? PastVois { get; set; }
        public string Future { get; set; } = null!;
        public string FutureTranscription { get; set; } = null!;
        public string? FutureVois { get; set; }
        public string Rassian1 { get; set; } = null!;
        public string? Rassian2 { get; set; }
        public string? Pictures { get; set; }
    }
}
