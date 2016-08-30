using AudioGraphBackgroundPlayback.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Audio;
using Windows.Media.Playback;
using Windows.Media.Render;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AudioGraphBackgroundPlayback
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AudioGraph graph;
        private AudioFileInputNode fileInput;
        private AudioDeviceOutputNode deviceOutput;

        MediaPlayer Player => PlaybackService.Instance.Player;

        MediaPlaybackList PlaybackList
        {
            get { return Player.Source as MediaPlaybackList; }
            set { Player.Source = value; }
        }

        public MainPage()
        {
            this.InitializeComponent();

            // Handle page load events
            Loaded += Scenario1_Loaded;
        }

        private void Scenario1_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a new playback list
            if (PlaybackList == null)
                PlaybackList = new MediaPlaybackList();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await CreateAudioGraph();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Destroy the graph if the page is naviated away from
            if (graph != null)
            {
                graph.Dispose();
            }
        }

        private async Task ShowMessage(string message)
        {
            var md = new MessageDialog(message);
            await md.ShowAsync();
        }

        private async Task CreateAudioGraph()
        {
            // Create an AudioGraph with default settings
            AudioGraphSettings settings = new AudioGraphSettings(AudioRenderCategory.Media);
            CreateAudioGraphResult result = await AudioGraph.CreateAsync(settings);

            if (result.Status != AudioGraphCreationStatus.Success)
            {
                // Cannot create graph
                await ShowMessage(String.Format("AudioGraph Creation Error because {0}", result.Status.ToString()));
                return;
            }

            graph = result.Graph;

            // Create a device output node
            CreateAudioDeviceOutputNodeResult deviceOutputNodeResult = await graph.CreateDeviceOutputNodeAsync();

            if (deviceOutputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
            {
                // Cannot create device output node
                await ShowMessage(String.Format("Device Output unavailable because {0}", deviceOutputNodeResult.Status.ToString()));
                return;
            }

            deviceOutput = deviceOutputNodeResult.DeviceOutputNode;
            await ShowMessage("Device Output Node successfully created");
        }

        private void TogglePlay()
        {
            //Toggle playback
            if (graphButton.Content.Equals("Start Graph"))
            {
                graph.Start();
                graphButton.Content = "Stop Graph";
            }
            else
            {
                graph.Stop();
                graphButton.Content = "Start Graph";
            }
        }

        private async void File_Click(object sender, RoutedEventArgs e)
        {
            // If another file is already loaded into the FileInput node
            if (fileInput != null)
            {
                // Release the file and dispose the contents of the node
                fileInput.Dispose();
                // Stop playback since a new file is being loaded. Also reset the button UI
                if (graphButton.Content.Equals("Stop Graph"))
                {
                    TogglePlay();
                }
            }

            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.FileTypeFilter.Add(".mp3");
            filePicker.FileTypeFilter.Add(".wav");
            filePicker.FileTypeFilter.Add(".wma");
            filePicker.FileTypeFilter.Add(".m4a");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            StorageFile file = await filePicker.PickSingleFileAsync();

            // File can be null if cancel is hit in the file picker
            if (file == null)
            {
                return;
            }

            CreateAudioFileInputNodeResult fileInputResult = await graph.CreateFileInputNodeAsync(file);
            if (AudioFileNodeCreationStatus.Success != fileInputResult.Status)
            {
                // Cannot read input file
                await ShowMessage(String.Format("Cannot read input file because {0}", fileInputResult.Status.ToString()));
                return;
            }

            fileInput = fileInputResult.FileInputNode;
            fileInput.AddOutgoingConnection(deviceOutput);
            fileButton.Background = new SolidColorBrush(Colors.Green);

            // Trim the file: set the start time to 3 seconds from the beginning
            // fileInput.EndTime can be used to trim from the end of file
            fileInput.StartTime = TimeSpan.FromSeconds(3);

            // Enable buttons in UI to start graph, loop and change playback speed factor
            graphButton.IsEnabled = true;
        }
        private void Graph_Click(object sender, RoutedEventArgs e)
        {
            TogglePlay();
        }
    }
}
