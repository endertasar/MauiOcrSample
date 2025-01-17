﻿using Microsoft.Extensions.Logging;
using Plugin.Maui.OCR;

namespace MauiOcrSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseOcr()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Use with depencecy injection
            builder.Services.AddSingleton<IOcrService>(Plugin.Maui.OCR.OcrPlugin.Default);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
