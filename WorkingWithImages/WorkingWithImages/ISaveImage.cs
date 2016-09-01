using Xamarin.Forms;

namespace WorkingWithImages
{
    public interface ISaveImage
    {
        void SavePictureToDisk(ImageSource imgSrc, string Id, bool OverwriteIfExist = false);
        void SavePictureToDiskWINRT(System.IO.Stream imgStream, string Id, bool OverwriteIfExist = false);
    }
}
