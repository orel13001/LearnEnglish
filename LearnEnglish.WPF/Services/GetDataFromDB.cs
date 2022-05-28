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
      
        public static ObservableCollection<Lesson> GetLessonWord()
        {
            ObservableCollection<Lesson> lessonWord = new ObservableCollection<Lesson>();
            using (LearnEnglishContext db = new LearnEnglishContext())
            {
                List<int> numberLessons = db.DictionaryWords.Select(o => o.Lesson).Distinct().ToList();
                foreach(int numberLesson in numberLessons)
                {
                    lessonWord.Add(new Lesson
                    {
                        Words = db.DictionaryWords.Select(o => db.DictionaryWords.Where(n => n.Lesson == numberLesson).ToList()).FirstOrDefault()!,
                        LessonNumber = numberLesson
                    });

                }
            }
            return lessonWord;
        }
    }
}
