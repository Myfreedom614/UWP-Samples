using Newtonsoft.Json;
using SemanticZoomUWPApp1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Data;

namespace SemanticZoomUWPApp1.ViewModel
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
        public MainViewModel()
        {
            GetData();
        }

        private async void GetData()
        {
            // Simulate pulling data from api
            string response;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///DesignData/GetLive.json"));
            using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
                response = await sRead.ReadToEndAsync();

            // Deserialize data to class
            LiveStreamModel liveGames = JsonConvert.DeserializeObject<LiveStreamModel>(response);
            //Schedules = liveGames.schedule;

            // Group data by event
            var groupData = liveGames.schedule.GroupBy(a => a.@event);

            // Set cvs source to grouped data
            ScheduleSource = new CollectionViewSource() { IsSourceGrouped = true, Source = groupData };
        }

        private CollectionViewSource scheduleSource;
        public CollectionViewSource ScheduleSource
        {
            get
            {
                return scheduleSource;
            }
            set
            {
                scheduleSource = value;
                RaisePropertyChanged("ScheduleSource");
            }
        }
    }
}
