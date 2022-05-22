﻿using System;
using System.Windows.Input;
using LearnEnglish.WPF.Views.Windows;

namespace LearnEnglish.WPF.ViewModels
{
    public class MainViewModels
    {
        #region Commands

        #region Добавление в словарь
        public ICommand AddToDictionary { get; }
        private void OnAddToDictionaryExecut(object p)
        {
            var win = new AddToDictionaryWindow();
            win.Show();
        }
        private bool CanAddToDictionaryExecuted(object p) => true;
        #endregion

        #region Повторение
        public ICommand Repetition { get; }
        private void OnRepetitionExecut(object p)
        {
            var win = new RepetitionWindow();
            win.Show();
        }
        private bool CanRepetitionExecuted(object p) => true;
        #endregion

        #endregion
    }
}
