using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyToolkitDataGridUWPApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Person> Peoples { get; set; } = new ObservableCollection<Person>();
        public MainPage()
        {
            this.InitializeComponent();
            Peoples.Add(new Person { Firstname = "111", Lastname = "222", Category = "333", Age = 19, ImageUri = "Assets/default-avatar.png" });
            Peoples.Add(new Person { Firstname = "111", Lastname = "222", Category = "333", Age = 19, ImageUri = "Assets/default-avatar.png" });
            Peoples.Add(new Person { Firstname = "111", Lastname = "222", Category = "333", Age = 19, ImageUri = "Assets/default-avatar.png" });
            Peoples.Add(new Person { Firstname = "111", Lastname = "222", Category = "333", Age = 19, ImageUri = "Assets/default-avatar.png" });
            Peoples.Add(new Person { Firstname = "111", Lastname = "222", Category = "333", Age = 19, ImageUri = "Assets/default-avatar.png" });
            this.DataContext = this;
        }
    }
}
