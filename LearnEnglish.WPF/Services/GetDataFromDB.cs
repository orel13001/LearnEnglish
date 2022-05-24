using System;
using System.Collections.ObjectModel;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnEnglish.WPF.Models;

namespace LearnEnglish.WPF.Services
{
    public class GetDataFromDB
    {
        public static ObservableCollection<int> GetWordNumberLesson()
        {
            ObservableCollection<int> numberLesson = new ObservableCollection<int>();
            using (LearnEnglishContext db = new LearnEnglishContext())
            {
                numberLesson = new ObservableCollection<int>(db.DictionaryWords.Select(o => o.Lesson).Distinct().ToList());
            }
            return numberLesson;
        }

        public static ObservableCollection<DictionaryWord> GetWordForNumberLesson(int numberLesson)
        {
            ObservableCollection<DictionaryWord> words = new ObservableCollection<DictionaryWord>();
            using (LearnEnglishContext db = new LearnEnglishContext())
            {
                words = new ObservableCollection<DictionaryWord>(db.DictionaryWords.Where(o => o.Lesson == numberLesson));
            }
            return words;
        }


        public static ObservableCollection<LessonWord> GetLessonWord()
        {
            ObservableCollection<LessonWord> lessonWord = new ObservableCollection<LessonWord>();
            using (LearnEnglishContext db = new LearnEnglishContext())
            {
                lessonWord = new ObservableCollection<LessonWord>(
                    db.DictionaryWords.Select(o => new LessonWord
                    {
                        LessonItems = db.DictionaryWords.Where(n => n.Lesson == o.Lesson).ToList(),
                    })
                    );
            }
            return lessonWord;
        }
    }
}
