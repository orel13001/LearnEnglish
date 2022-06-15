using LearnEnglish.WPF.Models.AddToDictionary;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.WPF.ViewModels
{
    public class AddToDictionaryViewModel : Base.ViewModel
    {

        private ObservableCollection<AddWord> _addWords;



        public ObservableCollection<AddWord> AddWords 
        {
            get => _addWords;
            //set => Set(ref _addWords, value);
            set
            {
                _addWords = new ObservableCollection<AddWord>{ 
                    new AddWord(){Lesson = 1},
                    new AddWord(){Lesson = 1},
                    new AddWord(){Lesson = 1},
                    new AddWord(){Lesson = 1},
                    new AddWord(){Lesson = 1},
                    new AddWord(){Lesson = 1},
                    new AddWord(){Lesson = 1}
                };
                
            }
        }

    }
}
