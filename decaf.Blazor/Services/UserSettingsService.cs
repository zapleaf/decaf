namespace decaf.Blazor.Services;

public class UserSettingsService
{
    private string theme = "dark";
    public string ThemeSwitch = "light";
    public string ThemeName = "Dark";
    public string Theme
    {
        get => theme;
        set
        {
            if (value.ToLower() == "light")
            {
                theme = "light";
                ThemeName = "Light";
                ThemeSwitch = "dark";
            }
            else
            {
                theme = "dark";
                ThemeName = "Dark";
                ThemeSwitch = "light";
            }
        }
    }

    private int categoryId;
    public string CategoryName { get; set; } = "";
    public int CategoryId
    {
        get => categoryId;
        set
        {
            categoryId = value;
            if (value != 0)
            {
                // Reset others to default
                SearchTermId = 0;
                SearchTerm = "";
                ChannelId = 0;
                ChannelName = "";
            }
        }
    }


    private int searchTermId;
    public string SearchTerm { get; set; } = "";
    public int SearchTermId
    {
        get => searchTermId;
        set
        {
            searchTermId = value;
            if (value != 0)
            {
                // Reset others to default
                CategoryId = 0;
                CategoryName = "";
                ChannelId = 0;
                ChannelName = "";
            }
        }
    }


    private int channelId;
    public string ChannelName { get; set; } = "";
    public int ChannelId
    {
        get => channelId;
        set
        {
            channelId = value;
            if (value != 0)
            {
                // Reset others to default
                CategoryId = 0;
                CategoryName = "";
                SearchTermId = 0;
                SearchTerm = "";
            }
        }
    }
}
