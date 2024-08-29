

using Plugin.Maui.OCR;

namespace MauiOcrSample
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await OcrPlugin.Default.InitAsync();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try { 
            var pickResult= await MediaPicker.Default.PickPhotoAsync();
                if (pickResult!=null)
                {
                    var imageAsStream = await pickResult.OpenReadAsync();

                    var imageAsBytes = new byte[imageAsStream.Length];
                    await imageAsStream.ReadAsync(imageAsBytes);



                    var ocrResult=await OcrPlugin.Default.RecognizeTextAsync(imageAsBytes);

                    if(!ocrResult.Success)
                    {
                        await DisplayAlert("Error", "ocrResult.ErrorMessage", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Text", ocrResult.AllText, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
               await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void PictureBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pickResult = await MediaPicker.Default.CapturePhotoAsync();
                if (pickResult != null)
                {
                    var imageAsStream = await pickResult.OpenReadAsync();

                    var imageAsBytes = new byte[imageAsStream.Length];
                    await imageAsStream.ReadAsync(imageAsBytes);



                    var ocrResult = await OcrPlugin.Default.RecognizeTextAsync(imageAsBytes);

                    if (!ocrResult.Success)
                    {
                        await DisplayAlert("Error", "ocrResult.ErrorMessage", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Text", ocrResult.AllText, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

}
