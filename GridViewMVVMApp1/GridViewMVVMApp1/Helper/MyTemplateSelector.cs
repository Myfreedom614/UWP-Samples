using GridViewMVVMApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GridViewMVVMApp1.Helper
{
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }

        protected override DataTemplate SelectTemplateCore(object item,
                                                           DependencyObject container)
        {
            if (item is MainModel)
                return Template1;
            if (item is ItemsModel)
                return Template2;

            return base.SelectTemplateCore(item, container);
        }
    }
}
