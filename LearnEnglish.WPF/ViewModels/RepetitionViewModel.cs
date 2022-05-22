using System;
using LearnEnglish.WPF.Models.EntityFramework;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LearnEnglish.WPF.ViewModels
{
    public class RepetitionViewModel : ViewModels.Base.ViewModel
    {

        private static Random random = new Random();
        private int Select
        {
            get => Words.IndexOf(Word);
        }

        private bool _rnd;
        private DictionaryWord _word;
        private ObservableCollection<DictionaryWord> _words;
        public DictionaryWord Word
        {
            get => _word;
            set => Set(ref _word, value);
        }
        public ObservableCollection<DictionaryWord> Words
        {
            get => _words;
            set => Set(ref _words, value);
        }
        public bool Rnd
        {
            get => _rnd;
            set => Set(ref _rnd, value);
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
        #endregion
    }
}
