using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCrossUWPApp1.ViewModel
{
    public class FirstViewModel
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _goSecondViewCommand;

        public System.Windows.Input.ICommand GoSecondViewCommand
        {
            get
            {
                _goSecondViewCommand = _goSecondViewCommand ??
                                       new Cirrious.MvvmCross.ViewModels.MvxCommand(DoGoSecondView);
                return _goSecondViewCommand;
            }
        }

        private void DoGoSecondView()
        {
            base.ShowViewModel<SecondViewModel>();
        }

    }
}
