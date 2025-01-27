using decaf.Blazor.Models;

namespace decaf.Blazor.Services;

public class NavItemService
{
    public List<NavItem> NavItems { get; private set; } = new List<NavItem>();
    public event Action OnChange;

    public void AddLink(NavItem link)
    {
        NavItems.Add(link);
        OnChange?.Invoke();
    }

    /// <summary>
    /// Will replace the current list of NavItems with the provided list
    /// </summary>
    public void AddLinks(List<NavItem> items)
    {
        NavItems = items;
        OnChange?.Invoke();
    }

    public void ClearLinks()
    {
        NavItems.Clear();
        OnChange?.Invoke();
    }

    // Use this method to safely invoke events in Blazor components using InvokeAsync
    public void NotifyMenuItemsChanged() => OnChange?.Invoke();
}
