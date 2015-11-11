using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCrossUWPApp1.ViewModel
{
    public class SecondViewModel : MvxViewModel
    {
        private string _hello2 = "Hello2 MvvmCross";

        public string Hello2
        {
            get { return _hello2; }
            set
            {
                _hello2 = value;
                RaisePropertyChanged(() => Hello2);
            }
        }
    }

}
