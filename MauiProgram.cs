using Microsoft.Extensions.Logging;
using odiazTS5A.Clases;
using odiazTS5A.Repository;

namespace odiazTS5A
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //CONFIGURACIÓN DE LA BAE DE DATOS
            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
            builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

//#if DEBUG
//    		builder.Logging.AddDebug();
//#endif

            return builder.Build();
        }
    }
}
