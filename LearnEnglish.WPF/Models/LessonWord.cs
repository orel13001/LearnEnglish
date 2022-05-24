using LearnEnglish.WPF.Models.EntityFramework;
using LearnEnglish.WPF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.WPF.Models
{
    public class LessonWord : ILesson
    {
        public List<DictionaryWord> LessonItems { get; set; }
    }
}
