using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SurveyApp.Data;
using SurveyApp.Services;


namespace SurveyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddSingleton<QuestionService>();
            builder.Services.AddSingleton<AnswerService>();
            builder.Services.AddSingleton<SurveyService>();
            builder.Services.AddSingleton<PreferencesService>();



            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
