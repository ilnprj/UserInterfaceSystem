namespace UIS
{
    /// <summary>
    /// Interface, that decides how windows will be loaded in memory
    /// </summary>
    public interface ILoadableWindow
    {
        WindowAsset GetWindowAsset(string idWindow);
    }
}
