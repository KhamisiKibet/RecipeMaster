﻿namespace RecipeMaster.Helpers;

public class Theme
{
    IEnvironment environment;

    public Theme(IEnvironment environment)
    {
        this.environment = environment;
    }

    public void SetTheme()
    {
        switch(Settings.Theme)
        {
            //default
            case 0:
                App.Current.UserAppTheme = AppTheme.Unspecified;
                break;
            //light
            case 1:
                App.Current.UserAppTheme = AppTheme.Light;
                break;
            //dark
            case 2:
                App.Current.UserAppTheme = AppTheme.Dark;
                break;
        }

        var nav = App.Current.MainPage as NavigationPage;

        if (environment is null)
            return;

        if(App.Current.RequestedTheme == AppTheme.Dark)
        {
            environment?.SetStatusBarColor(Colors.Black, false);
            if(nav != null)
            {
                nav.BarBackgroundColor = Colors.Black;
                nav.BarTextColor = Colors.White;
            }
        }
        else
        {
            environment?.SetStatusBarColor(Colors.White, true);
            if (nav != null)
            {
                nav.BarBackgroundColor = Colors.White;
                nav.BarTextColor = Colors.Black;
            }
        }


    }
}
