using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using MonkeyCache.FileStore;
using RecipeMaster.Helpers;

namespace RecipeMaster
{
    public partial class App : Application
    {
        static DatabaseHelper _database;

        public static DatabaseHelper Database
        {
            get
            {
                if (_database == null)
                {
                    var dbPath = Path.Combine(FileSystem.AppDataDirectory, "RecipeMaster.db3");
                    _database = new DatabaseHelper(dbPath);
                }
                return _database;
            }
        }

        private readonly Theme _theme;

        public App(Theme theme)
        {
            InitializeComponent();
            Barrel.ApplicationId = AppInfo.PackageName;
            MainPage = new AppShell();
            _theme = theme;
        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                _theme.SetTheme();
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                Console.WriteLine($"Error setting theme: {ex.Message}");
            }
        }

        protected override void OnSleep()
        {
            _theme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            _theme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _theme.SetTheme();
            });
        }
    }
}
