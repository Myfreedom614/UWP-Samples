using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StackPanelUWPApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            for (var i = 0; i < 5; i++) // The 5 here could be any number
            {
                StackPanel sp = new StackPanel
                {
                    Name = "myPanel" + i,
                    Orientation = Orientation.Horizontal
                };
                myStackPanel.Children.Add(sp);

                for (var j = 0; j < 10; j++) // The 10 here could be any number
                {
                    sp.Children.Add(new Rectangle
                    {
                        Name = "myRectangle" + i + "-" + j,
                        Fill = new SolidColorBrush(Colors.Black),
                        Width = 20,
                        Height = 20,
                        Margin = new Thickness(1)
                    });
                }
            }

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // E.G. To change the Fill color of Rectangle4 in StackPanel2
            var rec = FrameworkElementExtensions.TraverseCTFindShape<Shape>(myStackPanel, "myRectangle" + 2 + "-" + 4);
            rec.Fill = new SolidColorBrush(Colors.Red);
        }

    }
}
