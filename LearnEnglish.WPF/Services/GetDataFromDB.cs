using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnEnglish.WPF.Models;
using LearnEnglish.WPF.Models.Test;
using System.Reflection;

namespace LearnEnglish.WPF.Services
{
    public class GetDataFromDB
    {
        private static readonly string _currentDirectory;
        static GetDataFromDB()
        {
            _currentDirectory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)!;
        }
        public static ObservableCollection<Lesson> GetLessonWord()
        {
            ObservableCollection<Lesson> lessonWord = new ObservableCollection<Lesson>();
            using (LearnEnglishContext db = new LearnEnglishContext())
            {
                List<int> numberLessons = db.DictionaryWords.Select(o => o.Lesson).Distinct().ToList();
                foreach(int numberLesson in numberLessons)
                {
                    var words = db.DictionaryWords.Select(o => db.DictionaryWords.Where(n => n.Lesson == numberLesson).ToList()).FirstOrDefault()!;
                    foreach (var word in words)
                    {
                        word.Pictures = new StringBuilder(_currentDirectory).Append(word.Pictures).ToString();
                        word.Vois = new StringBuilder(_currentDirectory).Append(word.Vois).ToString();
                    }
                    lessonWord.Add(new Lesson
                    {
                        Words = words,
                        LessonNumber = numberLesson
                    });

                }
            }
            return lessonWord;
        }

    }
}
