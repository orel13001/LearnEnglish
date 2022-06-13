using System;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using LearnEnglish.WPF.Infrastructure.Command.Base;
using LearnEnglish.WPF.Services;
using LearnEnglish.WPF.Models;
using System.Windows.Media;

namespace LearnEnglish.WPF.ViewModels
{
    public class RepetitionViewModel : ViewModels.Base.ViewModel
    {
        private static MediaPlayer _mediaPlayer = new MediaPlayer();
        private static Random _random = new Random();
        private int Select
        {
            get => Les.Words.IndexOf(Word) >=0 ? Les.Words.IndexOf(Word) : 0;
        }

        private bool _mix;
        private bool _rusEng;
        private DictionaryWord _word;
        private Lesson _les;
        private ObservableCollection<Lesson> _lessonWord;

        //private bool _visibilityTranslate = false;
        private Visibility _visibleEng = Visibility.Visible;
        private Visibility _visibleRu = Visibility.Hidden;

        public DictionaryWord Word
        {
            get => _word;
            set
            {
                Set(ref _word, value);
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
        public bool Mix
        {
            get => _mix;
            set => Set(ref _mix, value);
        }
        public bool RusEng
        {
            get => _rusEng;
            set
            {
                Set(ref _rusEng, value);
                if (RusEng)
                {
                    VisibleEng = Visibility.Hidden;
                    VisibleRu = Visibility.Visible;
                }
                else
                {
                    VisibleRu = Visibility.Hidden;
                    VisibleEng = Visibility.Visible;
                }
            }
        }
        public ObservableCollection<Lesson> LessonWord
        {
            get => _lessonWord;
            set => Set(ref _lessonWord, value);
        }
        //public bool VisibilityTranslate
        //{
        //    get => _visibilityTranslate;
        //    set => Set(ref _visibilityTranslate, value);
        //}
        public Visibility VisibleEng
        {
            get => _visibleEng;
            set => Set(ref _visibleEng, value);
        }
        public Visibility VisibleRu
        {
            get => _visibleRu;
            set => Set(ref _visibleRu, value);
        }

        #region Commands

        #region Следующее слово
        public ICommand Next { get; }
        private void OnNextExecut(object p)
        {
            if (Word != null)
            {
                if(Mix)
                    Word = Les.Words[_random.Next(Les.Words.Count)];
                else
                {
                    
                    Word = Les.Words[Select + 1];
                }
            }
            HiddenTranslate();
        }
        private bool CanNextExecuted(object p)
        {
            if (Mix) return true;

            if(!Mix)
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
                if (Mix)
                    Word = Les.Words[_random.Next(Les.Words.Count)];
                else
                {

                    Word = Les.Words[Select - 1];
                }
            }
            HiddenTranslate();
        }
        private bool CanPreviousExecuted(object p)
        {
            if (Mix) return true;

            if (!Mix)
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

        #region Проиизношение
        public ICommand Say { get; }
        private void OnSayExecut(object p) => SayTranscription();
        private bool CanSayExecuted(object p) => true;
        #endregion
        #endregion

        #region Методы
        private void HiddenTranslate()
        {
            if(RusEng)
                VisibleEng = Visibility.Hidden;
            else
                VisibleRu = Visibility.Hidden;
        }
        private void ShowTranslate()
        {
            if (RusEng)               
                VisibleEng = Visibility.Visible;
            else
                VisibleRu = Visibility.Visible;
        }


        private void SayTranscription()
        {
            _mediaPlayer.Open(new Uri(Word.Vois!, UriKind.Absolute));
            _mediaPlayer.Play();
        }
        #endregion

        #region Конструктор
        public RepetitionViewModel()
        {
            Translate = new LambdaCommand(OnTranslateExecut, CanTranslateExecuted);
            Previous = new LambdaCommand(OnPreviousExecut, CanPreviousExecuted);
            Next = new LambdaCommand(OnNextExecut, CanNextExecuted);
            Say = new LambdaCommand(OnSayExecut, CanSayExecuted);

            LessonWord = GetDataFromDB.GetLessonWord();
            Les = LessonWord[0];
            Word = Les.Words[0];

        }
        #endregion
    }
}
