using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityMgt.ViewModels
{
   public class QuestionPageViewModel:BaseViewModel
    {
        bool _isSelected;
        public bool IsSelected {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
