using ListViewMVVMUWPApp1.Common;
using ListViewMVVMUWPApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListViewMVVMUWPApp1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private int selectedTaskListIndex;
        private TaskList selectedTaskList;
        private ObservableCollection<TaskList> taskLists;
        private BasicTask selectedTask;

        public ObservableCollection<TaskList> TaskLists
        {
            get
            {
                return taskLists;
            }
            set
            {
                taskLists = value;
                RaisePropertyChanged(nameof(TaskLists));
            }
        }
        public int SelectedTaskListIndex
        {
            get { return selectedTaskListIndex; }
            set
            {
                selectedTaskListIndex = value;
                SelectedTaskList = (value != -1) ? TaskLists[value] : TaskList.Default;
                RaisePropertyChanged(nameof(SelectedTaskListIndex));
            }
        }

        public TaskList SelectedTaskList
        {
            get { return selectedTaskList; }
            set
            {
                selectedTaskList = value;
                RaisePropertyChanged(nameof(SelectedTaskList));
                DeleteTaskCommand.RaiseCanExecuteChanged();
            }
        }
        
        public BasicTask SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                RaisePropertyChanged(nameof(SelectedTask));
                DeleteTaskCommand.RaiseCanExecuteChanged();
            }
        }
        
        public DelegateCommand<object> DeleteTaskCommand { get; private set; }

        void DeleteTaskCommand_Execute(object arg)
        {
            DeleteTask();
        }
        bool DeleteTaskCommand_CanExecute(object arg)
        {
            Debug.WriteLine((SelectedTask != null && SelectedTask != BasicTask.Default) ? true : false);
            return (SelectedTask!=null && SelectedTask != BasicTask.Default) ? true : false;
        }

        private void DeleteTask()
        {
            SelectedTaskList.Items.Remove(SelectedTask);
        }

        public MainViewModel()
        {
            TaskLists = new ObservableCollection<TaskList>();
            for (int i = 1; i < 4; i++)
                TaskLists.Add(
                    TaskList.Generate("TaskList" + i.ToString(), "Description" + i.ToString(), new ObservableCollection<BasicTask>() {
                        new BasicTask() { Title="Task"+i.ToString()+"-1" },
                        new BasicTask() { Title="Task"+i.ToString()+"-2" }
                    })
            );

            DeleteTaskCommand = new DelegateCommand<object>(DeleteTaskCommand_Execute, DeleteTaskCommand_CanExecute);
        }
    }
}
