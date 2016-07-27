using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Certificates;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http.Filters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ODataUWPApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        static void DisplayProduct(ClassLibrary2.ServiceReference1.Product product)
        {
            Debug.WriteLine("{0} {1} {2}", product.Name, product.Price, product.Category);
        }

        // Get an entire entity set.
        static async void ListAllProducts(ClassLibrary2.ServiceReference1.Container container)
        {
            var dsQuery = container.Products;

            var tf = new TaskFactory<IEnumerable<ClassLibrary2.ServiceReference1.Product>>();
            var list = (await tf.FromAsync(dsQuery.BeginExecute(null, null),
                                        iar => dsQuery.EndExecute(iar))).ToList();
            foreach (var p in list)
            {
                DisplayProduct(p);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("http://localhost:18441/odata");
            var container = new ClassLibrary2.ServiceReference1.Container(uri);

            ListAllProducts(container);
        }
    }
}
