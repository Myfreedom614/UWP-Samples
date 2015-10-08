using GridViewMVVMApp1.Controls;
using GridViewMVVMApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewMVVMApp1.ViewModel
{
    public class MainViewModel
    {
        private List<ItemsModel> allitems;
        public List<ItemsModel> AllItems
        {
            get { return allitems; }
            set { allitems = value; }
        }
        public MainViewModel()
        {
            allitems = new List<ItemsModel>();
            for (int i = 1; i < 11; i++)
                allitems.Add(new ItemsModel() { Title = "Item" + i.ToString() });
        }

        public async void ItemSelected(object sender, object parameter)
        {
            var arg = parameter as Windows.UI.Xaml.Controls.ItemClickEventArgs;
            var clickedItem = arg.ClickedItem;
            var item = clickedItem as ItemsModel;

            var dialog = new ItemsDialog();
            dialog.DataContext = item;
            await dialog.ShowAsync();
        }
    }
}
