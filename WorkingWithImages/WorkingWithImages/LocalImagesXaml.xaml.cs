using System;
using System.IO;
using Xamarin.Forms;

namespace WorkingWithImages
{
    public partial class LocalImagesXaml : ContentPage
    {
        public LocalImagesXaml()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            //ImageSource imgsource = ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/b/b4/JPEG_example_JPG_RIP_100.jpg"));
            var memoryStream = new MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAANgAAAAuCAMAAAB9NSfbAAAAKlBMVEX/uQOAuwPzUCJ0dHR2dnZ0dHR0dHR0dHR0dHQDpfBnZ110dHRzc3O5uQReCoL9AAAADnRSTlP6/Pvf/cmvjWX9ADcWOkAIBzkAAANISURBVHja7ZjbdtwwCEXbIi415P9/t7EwRmbsPiRW1krr8zSGiWALjDT58etUy/LzVG/Ld9ED9oA9YA/YA/YPgikTAsoXgimLzefi1oU3gRl2UcncyM0REaeTUXPRTWDaXHIMI26FlbF/4slc0jbhzWB4jIMJprGRs5QBUVRkDSkod4E1LdasGHhFp0qHHGSFvA+MRysPYIsigHNNBqMIfisYWBoNwrg92/JNwUqzSUuw1HQwvh2MyvjA1QYBZqvSqcLMoja6VETda90dT4NNRpvJ+C0z30ru6wWYmX0aTDqZHm07GDXIc0wwiinbDsBiGPuiDOFm2+sP5TVW2me7eIku9Hkw2ePmidx2sHwDLbA2kg6vEI+S3jzTnaK8Q2mzqWCeocXo6KYK5p4URcUwOEuCYAWDE3TknwrmfZ2jA6xWLOsFxEwQYG6ChlEvZGbYa6qOpCrUaABd1whcAYS+Cnbl5xvAxnGLPVoF23NiLx4nGIiZinlC6t4YtJI7prKDkg2NrddT8bNzVrYUdbfoCZjB4U20HUz3QucEomjPNGbWeDgveSpYjg/yyK9gEjmlcMiHjtgd0xYuF83xfhZLXoP9PtW741RvZ2AGUZcwFLAMWMF0SFmPLtnqiDKGAzvgg00Ey+U4AQsYReYpdFe2lX/O9PZBCtJdkgXMt0xngsX4MPAIr2DmFFdg6iUvYONlVBJsF80Gixjmo+MUDD4EtigGmryCza9YjI9tdJy1In6kFVcJNZfVAeSbNREsg8Tj1TsmfwfTUovj7VC+fnjEghHociriBVgd905Qzi8uP8ejMyeDaV7pTsDCn6kn2MsBnZjavZk5DyULzLlgeT3Vc7Dws3lzUYBlltnHFPkziGXFYnewx1D0HihgsvfnXWDSPNAVWJxJxIStJVj5lx0xtZ2Ru2GzaDY8EmNzYwXTbRlst4BlZ5yDZUhXBYucUzzYrn+2yNipLgjfHWCZmY1g9bDCI1g5u+SQcYWlE37Q5RVM7wAzfFeAKSJyOOBd2BMBRApcwWi4NSVCd4WMwd3IkTGFxYMUmw2RQZb9yd2fAbuWrTqxq4qI2tVfrW4d3ZbfLza9Dq6rPjAVv4cesAfsAXvAHrD/A+wPe9UlrcdA7u4AAAAASUVORK5CYII="));
            ImageSource imgsource = ImageSource.FromStream(() => memoryStream);
            //img1.Source = imgsource;

            if (Device.OS == TargetPlatform.Windows|| Device.OS == TargetPlatform.WinPhone)
                DependencyService.Get<ISaveImage>().SavePictureToDiskWINRT(memoryStream, "1");
            else
                DependencyService.Get<ISaveImage>().SavePictureToDisk(imgsource, "1");



        }
    }
}
