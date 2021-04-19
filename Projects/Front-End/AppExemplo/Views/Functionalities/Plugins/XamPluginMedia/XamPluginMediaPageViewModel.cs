using AppExemplo.Views.Base;
using ExtensionCore;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppExemplo.Views.Functionalities.Plugins.XamPluginMedia
{
    public class XamPluginMediaPageViewModel : BaseViewModel
    {
        //Documentação: https://github.com/jamesmontemagno/MediaPlugin

        public XamPluginMediaPageViewModel(Page currentPage) : base(currentPage)
        {
            GetFileCommand = new Command(async () => { await GetFileAsync(); });
            GetGalleryFileCommand = new Command(async () => { await GetGalleryFileAsync(); });
            TakePictureCommand = new Command<string>(async (parametro) => { await TakePictureAsync((CameraDevice)parametro.ToInt()); });
        }

        #region Properties

        public ICommand GetFileCommand { get; private set; }

        public ICommand GetGalleryFileCommand { get; private set; }

        public ICommand TakePictureCommand { get; private set; }

        private ImageSource imageUploaded;
        public ImageSource ImageUploaded { get { return imageUploaded; } set { imageUploaded = value; OnPropertyChanged(); } }

        private string fileName;
        public string FileName { get { return fileName; } set { fileName = value; OnPropertyChanged(); } }

        #endregion Properties

        #region Methods

        public async Task<bool> InitializeCrossMedia()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _currentPage.DisplayAlert("Alerta!", "Seu dispositivo não possui câmera.", "OK");
                return false;
            }

            return true;
        }

        public async Task GetFileAsync()
        {
            if (await InitializeCrossMedia())
            {
                FileResult fileResult = await FilePicker.PickAsync(new PickOptions() { PickerTitle = "Selecione um arquivo..." });

                if (fileResult != null)
                {
                    FileName = fileResult.FileName;

                    //1º forma de exibir a imagem, utilizando o Stream
                    Stream stream = await fileResult.OpenReadAsync();
                    ImageUploaded = ImageSource.FromStream(() => { return stream; });

                    //2º forma de exibir a imagem, utilizando os bytes
                    //byte[] file = await File.ReadAllBytesAsync(fileResult.FullPath);
                    //ImageUploaded = ImageSource.FromStream(() => { return new MemoryStream(file); });
                }
            }
        }

        public async Task GetGalleryFileAsync()
        {
            if (await InitializeCrossMedia())
            {
                MediaFile mediaFile = await CrossMedia.Current.PickPhotoAsync();

                if (mediaFile != null)
                {
                    FileName = mediaFile.Path.Split('/').ToList().Last();

                    //1º forma de exibir a imagem, utilizando o Stream
                    ImageUploaded = ImageSource.FromStream(() => { return mediaFile.GetStream(); });

                    //2º forma de exibir a imagem, utilizando os bytes
                    //byte[] file = await File.ReadAllBytesAsync(mediaFile.Path);
                    //ImageUploaded = ImageSource.FromStream(() => { return new MemoryStream(file); });
                }
            }
        }

        public async Task TakePictureAsync(CameraDevice cameraDevice)
        {
            if (await InitializeCrossMedia())
            {
                string data = DateTime.Now.ToString("yyyy:MM:dd").Replace(":", "");
                string hora = DateTime.Now.ToString("HH:mm:ss").Replace(":", "");

                StoreCameraMediaOptions storeCameraMediaOptions = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = true,
                    Directory = "Exemplo Xamarin",
                    Name = $"{data}_{hora}.jpg",
                    AllowCropping = true,
                    DefaultCamera = cameraDevice,
                    CompressionQuality = 92
                };

                MediaFile mediaFile = await CrossMedia.Current.TakePhotoAsync(options: storeCameraMediaOptions);

                if (mediaFile != null)
                {
                    FileName = mediaFile.Path.Split('/').ToList().Last();

                    //1º forma de exibir a imagem, utilizando o Stream
                    ImageUploaded = ImageSource.FromStream(() => { return mediaFile.GetStream(); });

                    //2º forma de exibir a imagem, utilizando os bytes
                    //byte[] file = await File.ReadAllBytesAsync(mediaFile.Path);
                    //ImageUploaded = ImageSource.FromStream(() => { return new MemoryStream(file); });
                }
            }
        }

        #endregion Methods

    }
}
