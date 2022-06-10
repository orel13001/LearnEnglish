using System;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using LearnEnglish.WPF.Infrastructure.Command.Base;
using LearnEnglish.WPF.Services;
using LearnEnglish.WPF.Models;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace LearnEnglish.WPF.ViewModels
{
    public class RepetitionViewModel : ViewModels.Base.ViewModel
    {

        private static Random random = new Random();
        private int Select
        {
            get => Les.Words.IndexOf(Word) >=0 ? Les.Words.IndexOf(Word) : 0;
        }

        private bool _rnd;
        private DictionaryWord _word;
        private Lesson _les;
        private ObservableCollection<Lesson> _lessonWord;
        private ImageSource _pic;

        public Visibility _visibilityTranslate = Visibility.Hidden;

        public DictionaryWord Word
        {
            get => _word;
            set
            {
                Set(ref _word, value);
                Pic = GetPicture();
            }
        }

        

        public Lesson Les
        {
            get => _les;
            set
            {
                Set(ref _les, value);
                Word = Les.Words[0];
            }
        }
        public bool Rnd
        {
            get => _rnd;
            set => Set(ref _rnd, value);
        }
        public ObservableCollection<Lesson> LessonWord
        {
            get => _lessonWord;
            set => Set(ref _lessonWord, value);
        }
        public Visibility VisibilityTranslate
        {
            get => _visibilityTranslate;
            set => Set(ref _visibilityTranslate, value);
        }

        public ImageSource Pic
        {
            get => _pic;
            set => Set(ref _pic, value);
        }

        #region Commands

        #region Следующее слово
        public ICommand Next { get; }
        private void OnNextExecut(object p)
        {
            if (Word != null)
            {
                if(Rnd)
                    Word = Les.Words[random.Next(Les.Words.Count)];
                else
                {
                    
                    Word = Les.Words[Select + 1];
                }
            }
            HiddenTranslate();
        }
        private bool CanNextExecuted(object p)
        {
            if (Rnd) return true;

            if(!Rnd)
            {
                if (Select == Les.Words.Count - 1)
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
                    Word = Les.Words[random.Next(Les.Words.Count)];
                else
                {

                    Word = Les.Words[Select - 1];
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

        private ImageSource GetPicture()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Word.Pictures, UriKind.Relative);
            bitmap.EndInit();
            return bitmap;

        }
        #endregion

        #region Конструктор
        public RepetitionViewModel()
        {
            Translate = new LambdaCommand(OnTranslateExecut, CanTranslateExecuted);
            Previous = new LambdaCommand(OnPreviousExecut, CanPreviousExecuted);
            Next = new LambdaCommand(OnNextExecut, CanNextExecuted);


            //LessonWord = GetDataFromDB.GetLessonWord();
            LessonWord = GetDataFromDB.GetLessonWord();
            Les = LessonWord[0];
            Word = Les.Words[0];

        }
        #endregion
    }
}
