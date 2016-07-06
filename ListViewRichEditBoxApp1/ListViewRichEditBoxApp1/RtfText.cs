using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ListViewRichEditBoxApp1
{
    public class RtfText
    {
        public static string GetRichText(DependencyObject obj)
        {
            return (string)obj.GetValue(RichTextProperty);
        }

        public static void SetRichText(DependencyObject obj, string value)
        {
            obj.SetValue(RichTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for RichText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RichTextProperty =
            DependencyProperty.RegisterAttached("RichText", typeof(string), typeof(RtfText), new PropertyMetadata(string.Empty, callback));

        private static async void callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var reb = (RichEditBox)d;
            Uri bloburi = new Uri((string)e.NewValue);
            CloudBlockBlob cBlob = new CloudBlockBlob(bloburi);
            var blobstr = await cBlob.DownloadTextAsync();
            reb.Document.SetText(TextSetOptions.FormatRtf, blobstr);
        }
    }
}
