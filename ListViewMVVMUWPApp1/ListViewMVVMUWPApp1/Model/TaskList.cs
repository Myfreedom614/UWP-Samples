using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMVVMUWPApp1.Model
{
    public class TaskList
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ObservableCollection<BasicTask> Items { get; set; }

        public static TaskList Generate(string title, string description, ObservableCollection<BasicTask> items)
            => new TaskList() { Title = title, Description = description, Items = items };

        public static TaskList Default = new TaskList() {
            Title = "Default TaskList",
            Description = "Default Description",
            Items =new ObservableCollection<BasicTask>() {
                new BasicTask() { Title="Default Task1" },
                new BasicTask() { Title="Default Task2" }
            }
        };
    }
}
