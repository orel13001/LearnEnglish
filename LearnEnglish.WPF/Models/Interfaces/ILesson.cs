using LearnEnglish.WPF.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.WPF.Models.Interfaces
{
    public interface ILesson
    {
        public List<DictionaryWord> LessonItems { get; set; }
    }
}
