using Xamarin.Forms;

namespace WorkingWithListview
{
    public class NativeCell : ViewCell
    {
        public static readonly BindableProperty NameProperty =
          BindableProperty.Create("Name", typeof(string), typeof(NativeCell), "");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty CategoryProperty =
          BindableProperty.Create("Category", typeof(string), typeof(NativeCell), "");

        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }
    }
}
