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
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebViewCustomHeaderUWPApp1
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
        private void NavigateWithHeader(Uri uri)
        {
            var requestMsg = new Windows.Web.Http.HttpRequestMessage(HttpMethod.Get, uri);
            requestMsg.Headers.Add("User-Name", "Franklin Chen");
            wb.NavigateWithHttpRequestMessage(requestMsg);

            wb.NavigationStarting += Wb_NavigationStarting;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateWithHeader(new Uri("http://openszone.com/RedirectPage.html"));
        }

        private void Wb_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            wb.NavigationStarting -= Wb_NavigationStarting;
            args.Cancel = true;//cancel navigation in a handler for this event by setting the WebViewNavigationStartingEventArgs.Cancel property to true
            NavigateWithHeader(args.Uri);
        }
    }
}
