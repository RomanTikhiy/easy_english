﻿using MobileClient.Views;
using Plugin.Media;
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
        readonly ITesseractApi _tesseractApi;
        readonly IDevice _device;

        public ICommand TakePhotoCommand { get; set; }
        public ICommand TranslateCommand { get; set; }

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

        private float _progress;
        public float Progress
        {
            get { return _progress; }
            set { SetProperty(ref _progress, value); }
        }

        private bool _isProcessing;
        public bool IsProcessing
        {
            get { return _isProcessing; }
            set { SetProperty(ref _isProcessing, value); }
        }

        private bool _isControlEnabled;
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set { SetProperty(ref _isControlEnabled, value); }
        }

        public CameraTranslateViewModel(INavigationService navigationService) : base(navigationService)
        {
            _device = Resolver.Resolve<IDevice>();
            _tesseractApi = Resolver.Resolve<ITesseractApi>();

            CapturedImage = ImageSource.FromFile("camera.gif");

            IsControlEnabled = true;
            TakePhotoCommand = new DelegateCommand(async () => await TakePhotoAsync());
            TranslateCommand = new DelegateCommand(async () => 
            {
                var parameters = new NavigationParameters();
                parameters.Add("text", TextResult);
                
                await NavigationService.NavigateAsync($"{nameof(TranslatePage)}", parameters);
            });
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        async Task TakePhotoAsync()
        {
            Progress = 0;

            if (!_tesseractApi.Initialized)
                await _tesseractApi.Init("eng");

            var photo = await TakePicture();
            if (photo != null)
            {
                IsProcessing = true;
                IsControlEnabled = false;

                CapturedImage = ImageSource.FromStream(() => photo.GetStream());
                _tesseractApi.Progress += OnProgressChanged;

                var tessResult = await _tesseractApi.SetImage(photo.Path);
                if (tessResult)
                {
                    IsProcessing = false;

                    TextResult = _tesseractApi.Text;
                }

                IsControlEnabled = true;
            }            
        }

        private void OnProgressChanged(object sender, ProgressEventArgs e)
        {
            Progress += 0.1f;
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
