using LearnEnglish.WPF.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.WPF.Models
{
    public class Lesson
    {
        public int LessonNumber { get; set; }
        public List<DictionaryWord> Words { get; set;}
    }
}
