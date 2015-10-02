using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TitleBarApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Scenario2_Extend : Page
    {
        private MainPage rootPage = MainPage.Current;

        public Scenario2_Extend()
        {
            this.InitializeComponent();
            ExtendView.IsChecked = CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar;
            EnableControls.Visibility = ExtendView.IsChecked.Value ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
            EnableControls.IsChecked = rootPage.AreControlsInTitleBar;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rootPage = MainPage.Current;

            // The SizeChanged event is raised when full screen mode changes.
            Window.Current.SizeChanged += OnWindowSizeChanged;
            UpdateFullScreenModeStatus();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Window.Current.SizeChanged -= OnWindowSizeChanged;
        }

        private void ExtendView_Click(object sender, RoutedEventArgs e)
        {
            bool extend = ExtendView.IsChecked.Value;
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = extend;
            EnableControls.Visibility = extend ? Visibility.Visible : Visibility.Collapsed;
            if (extend)
            {
                rootPage.AddCustomTitleBar();
            }
            else
            {
                rootPage.RemoveCustomTitleBar();
            }
        }

        private void EnableControls_Click(object sender, RoutedEventArgs e)
        {
            rootPage.AreControlsInTitleBar = EnableControls.IsChecked.Value;
        }

        private void ToggleFullScreenModeButton_Click(object sender, RoutedEventArgs e)
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                rootPage.NotifyUser("Exited full screen mode", NotifyType.StatusMessage);
            }
            else
            {
                if (view.TryEnterFullScreenMode())
                {
                    rootPage.NotifyUser("Entered full screen mode", NotifyType.StatusMessage);
                }
                else
                {
                    rootPage.NotifyUser("Failed to enter full screen mode", NotifyType.ErrorMessage);
                }
            }
        }

        void OnWindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            UpdateFullScreenModeStatus();
        }

        void UpdateFullScreenModeStatus()
        {
            bool isFullScreenMode = ApplicationView.GetForCurrentView().IsFullScreenMode;
            ToggleFullScreenModeSymbol.Symbol = isFullScreenMode ? Symbol.BackToWindow : Symbol.FullScreen;
            ReportFullScreenMode.Text = isFullScreenMode ? "is in" : "is not in";
        }
    }
}
