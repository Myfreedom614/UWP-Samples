using SemanticZoomUWPApp1.Helper;
using SemanticZoomUWPApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SemanticZoomUWPApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void GetLiveZoom_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (GridViewHeaderItem gvhi in VTHelper.FindVisualChildren<GridViewHeaderItem>((SemanticZoom)sender))
            {
                //Do something with GridViewHeaderItem here
                foreach (Rectangle rec in VTHelper.FindVisualChildren<Rectangle>(gvhi))
                {
                    //Do something with Rectangle here
                    rec.Height = 0;
                }
            }
        }
    }
}
