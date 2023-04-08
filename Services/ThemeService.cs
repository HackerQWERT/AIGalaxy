namespace AIGalaxy.Services;

public class ThemeService
{
    public bool IsDarkMode { get; set; } = true;
    public MudTheme Theme { get; set; } = new MudTheme();
}
