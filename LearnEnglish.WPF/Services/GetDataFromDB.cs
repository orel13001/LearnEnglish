using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnEnglish.WPF.Models;

namespace LearnEnglish.WPF.Services
{
    public class GetDataFromDB
    {
      
        public static ObservableCollection<List<DictionaryWord>> GetLessonWord()
        {
            ObservableCollection<List<DictionaryWord>> lessonWord = new ObservableCollection<List<DictionaryWord>>();
            using (LearnEnglishContext db = new LearnEnglishContext())
            {
                List<int> numberLessons = db.DictionaryWords.Select(o => o.Lesson).Distinct().ToList();
                foreach(int numberLesson in numberLessons)
                {
                    lessonWord.Add(db.DictionaryWords.Select(o => db.DictionaryWords.Where(n => n.Lesson == numberLesson).ToList()).FirstOrDefault()!);
                }
            }
            return lessonWord;
        }
    }
}
