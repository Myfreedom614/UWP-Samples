using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MvvmVisualStatesBehaviorUWPApp1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public enum ViewModelState
        {
            Default,
            Details
        }

        private ViewModelState currentState;
        public ViewModelState CurrentState
        {
            get { return currentState; }
            set
            {
                this.Set(ref currentState, value);
            }
        }

        public RelayCommand GotoDetailsStateCommand { get; set; }
        public RelayCommand GotoDefaultStateCommand { get; set; }

        public MainViewModel()
        {
            GotoDetailsStateCommand = new RelayCommand(() =>
            {
                CurrentState = ViewModelState.Details;
            });

            GotoDefaultStateCommand = new RelayCommand(() =>
            {
                CurrentState = ViewModelState.Default;
            });
        }

        public void OnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            Debug.WriteLine("CurrentStateChanged!");
        }
    }
}
