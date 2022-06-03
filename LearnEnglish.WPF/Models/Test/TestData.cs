using LearnEnglish.WPF.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.WPF.Models.Test
{
    public static class TestData
    {
        public static List<DictionaryWord> testData = new List<DictionaryWord>
        {
            new DictionaryWord{Id = 1, Lesson = 1, English = "and", Transcription = "ænd", Russian1 ="и" ,Pictures =""},
            new DictionaryWord{Id = 2, Lesson = 1, English = "cat", Transcription = "kæt", Russian1 ="кот" ,Pictures ="/Sources/pictures/cat.jpg"},
            new DictionaryWord{Id = 3, Lesson = 1, English = "car", Transcription = "kɑː", Russian1 ="автомобиль" ,Pictures ="/Sources/pictures/car.jpg"},
            new DictionaryWord{Id = 4, Lesson = 1, English = "cook", Transcription = "kuk", Russian1 ="готовить" ,Pictures =""},
            new DictionaryWord{Id = 5, Lesson = 1, English = "dad", Transcription = "dæd", Russian1 ="папа" ,Pictures =""},
            new DictionaryWord{Id = 6, Lesson = 1, English = "daughter", Transcription = "`dɔːtə", Russian1 ="дочь" ,Pictures =""},
            new DictionaryWord{Id = 7, Lesson = 1, English = "day", Transcription = "deɪ", Russian1 ="день" ,Pictures =""},
            new DictionaryWord{Id = 8, Lesson = 2, English = "dinner", Transcription = "`dɪnə", Russian1 ="ужин" ,Pictures =""},
            new DictionaryWord{Id = 9, Lesson = 2, English = "dog", Transcription = "dɔg", Russian1 ="собака" ,Pictures ="/Sources/pictures/dog.jpg"},
            new DictionaryWord{Id = 10, Lesson = 2, English = "drive", Transcription = "draɪv", Russian1 ="водить" ,Pictures =""},
            new DictionaryWord{Id = 11, Lesson = 2, English = "duck", Transcription = "dʌk", Russian1 ="утка" ,Pictures =""},
            new DictionaryWord{Id = 12, Lesson = 2, English = "English", Transcription = "`ɪŋglɪʃ", Russian1 ="английский" ,Pictures =""},
        };
    }
}
