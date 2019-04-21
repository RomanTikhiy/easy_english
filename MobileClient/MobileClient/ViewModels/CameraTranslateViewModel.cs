﻿using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Tesseract;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace MobileClient.ViewModels
{
    public class CameraTranslateViewModel : ViewModelBase
    {
        private readonly ITesseractApi _tesseractApi;
        private readonly IDevice _device;

        public ICommand TakePhotoCommand { get; set; }

        private ImageSource _imageSource;
        public ImageSource CapturedImage
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        private string _textResult;
        public string TextResult
        {
            get { return _textResult; }
            set { SetProperty(ref _textResult, value); }
        }

        public CameraTranslateViewModel(INavigationService navigationService) : base(navigationService)
        {
            _device = Resolver.Resolve<IDevice>();
            _tesseractApi = Resolver.Resolve<ITesseractApi>();

            TakePhotoCommand = new DelegateCommand(async () => await TakePhotoAsync());
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            CapturedImage = ImageSource.FromFile("photo_template.png");
        }

        async Task TakePhotoAsync()
        {
            if (!_tesseractApi.Initialized)
                await _tesseractApi.Init("eng");

            var photo = await TakePicture();
            if (photo != null)
            {
                // When setting an ImageSource using a stream, 
                // the stream gets closed, so to avoid that I backed up
                // the image into a byte array with the following code:
                //var imageBytes = new byte[photo.Length];
                //photo.Position = 0;
                //await photo.ReadAsync(imageBytes, 0, (int)photo.Length);
                //photo.Position = 0;

                CapturedImage = ImageSource.FromStream(() => photo.GetStream());

                var tessResult = await _tesseractApi.SetImage(photo.Path);
                if (tessResult)
                {
                    TextResult = _tesseractApi.Text;
                    var r = _tesseractApi.Results(PageIteratorLevel.Word);
                }
            }            
        }

        private async Task<MediaFile> TakePicture()
        {            
            try
            {
                if (await Plugin.Permissions.CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Camera) != Plugin.Permissions.Abstractions.PermissionStatus.Granted)                
                    await Plugin.Permissions.CrossPermissions.Current.RequestPermissionsAsync(permissions: Plugin.Permissions.Abstractions.Permission.Camera);                
                
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsPickPhotoSupported)                
                    return null;                

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {                    
                    DefaultCamera = CameraDevice.Rear
                });

                return photo;
            }
            catch (Exception)
            {
                return null;
            }
        }        
    }
}