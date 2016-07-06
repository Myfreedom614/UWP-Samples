using ListViewRichEditBoxApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewRichEditBoxApp1.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<TopNews> Data { get; set; }
        public MainViewModel()
        {
            Data = new ObservableCollection<TopNews>();

            Data.Add(new TopNews() { Id="1", Title="News1", BodyUri= "https://franklinstorageaccount.blob.core.windows.net/blobs/testformat.rtf" });
            Data.Add(new TopNews() { Id = "2", Title = "News2", BodyUri = "https://franklinstorageaccount.blob.core.windows.net/blobs/testformat.rtf" });
            Data.Add(new TopNews() { Id = "3", Title = "News3", BodyUri = "https://franklinstorageaccount.blob.core.windows.net/blobs/testformat.rtf" });
        }
    }
}
