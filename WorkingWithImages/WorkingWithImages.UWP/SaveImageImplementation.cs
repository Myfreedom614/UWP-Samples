using Xamarin.Forms;
using WorkingWithImages.WinUniversal;
using System.IO;
using System;
using Windows.Storage.Streams;

[assembly: Xamarin.Forms.Dependency(typeof(SaveImageImplementation))]
namespace WorkingWithImages.WinUniversal
{
    public class SaveImageImplementation : ISaveImage
    {
        public SaveImageImplementation() { }

        public void SavePictureToDisk(ImageSource imgSrc, string Id, bool OverwriteIfExist = false)
        {
            throw new NotImplementedException();
        }

        public async void SavePictureToDiskWINRT(Stream imgStream, string Id, bool OverwriteIfExist = false)
        {
            var inStream = imgStream.AsRandomAccessStream();
            var fileBytes = new byte[inStream.Size];
            using (DataReader reader = new DataReader(inStream))
            {
                await reader.LoadAsync((uint)inStream.Size);
                reader.ReadBytes(fileBytes);
            }

            var file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(Id+".jpg", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            using (var fs = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
            {
                var outStream = fs.GetOutputStreamAt(0);
                var dataWriter = new DataWriter(outStream);
                dataWriter.WriteBytes(fileBytes);
                await dataWriter.StoreAsync();
                dataWriter.DetachStream();
                await outStream.FlushAsync();
                outStream.Dispose();
                fs.Dispose();
            }
        }
    }
}
