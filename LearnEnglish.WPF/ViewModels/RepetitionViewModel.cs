using System;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using LearnEnglish.WPF.Infrastructure.Command.Base;
using LearnEnglish.WPF.Services;
using LearnEnglish.WPF.Models;


namespace LearnEnglish.WPF.ViewModels
{
    public class RepetitionViewModel : ViewModels.Base.ViewModel
    {

        private static Random random = new Random();
        private int Select
        {
            get => Words.IndexOf(Word) >=0 ? Words.IndexOf(Word) : 0;
        }

        private bool _rnd;
        private DictionaryWord _word;
        private List<DictionaryWord> _words;
        private ObservableCollection<List<DictionaryWord>> _lessonWord;
        public Visibility _visibilityTranslate = Visibility.Hidden;

        public DictionaryWord Word
        {
            get => _word;
            set => Set(ref _word, value);
        }
        public List<DictionaryWord> Words
        {
            get => _words;
            set
            {
                Set(ref _words, value);
                Word = Words[0];
            }
        }
        public bool Rnd
        {
            get => _rnd;
            set => Set(ref _rnd, value);
        }
        public ObservableCollection<List<DictionaryWord>> LessonWord
        {
            get => _lessonWord;
            set => Set(ref _lessonWord, value);
        }
        public Visibility VisibilityTranslate
        {
            get => _visibilityTranslate;
            set => Set(ref _visibilityTranslate, value);
        }

        #region Commands

        #region Следующее слово
        public ICommand Next { get; }
        private void OnNextExecut(object p)
        {
            if (Word != null)
            {
                if(Rnd)
                    Word = Words[random.Next(Words.Count)];
                else
                {
                    
                    Word = Words[Select + 1];
                }
            }
            HiddenTranslate();
        }
        private bool CanNextExecuted(object p)
        {
            if (Rnd) return true;

            if(!Rnd)
            {
                if (Select == Words.Count - 1)
                    return false;
            }
            return true;
        }
        #endregion

        #region Предыдущее слово
        public ICommand Previous { get; }
        private void OnPreviousExecut(object p)
        {
            if (Word != null)
            {
                if (Rnd)
                    Word = Words[random.Next(Words.Count)];
                else
                {

                    Word = Words[Select - 1];
                }
            }
            HiddenTranslate();
        }
        private bool CanPreviousExecuted(object p)
        {
            if (Rnd) return true;

            if (!Rnd)
            {
                if (Select == 0)
                    return false;
            }
            return true;
        }
        #endregion

        #region Перевод
        public ICommand Translate { get; }
        private void OnTranslateExecut(object p) => ShowTranslate();        
        private bool CanTranslateExecuted(object p) => true;       
        #endregion
        #endregion

        #region Методы
        private void HiddenTranslate()
        {
            VisibilityTranslate = Visibility.Hidden;
        }
        private void ShowTranslate()
        {
            VisibilityTranslate = Visibility.Visible;
        }
        #endregion

        #region Конструктор
        public RepetitionViewModel()
        {
            Translate = new LambdaCommand(OnTranslateExecut, CanTranslateExecuted);
            Previous = new LambdaCommand(OnPreviousExecut, CanPreviousExecuted);
            Next = new LambdaCommand(OnNextExecut, CanNextExecuted);

            //LessonNumber = GetDataFromDB.GetWordNumberLesson();

            LessonWord = GetDataFromDB.GetLessonWord();
            Words = LessonWord[0];
            Word = Words[0];

        }
        #endregion
    }
}
