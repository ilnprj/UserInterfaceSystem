/// <summary>
/// Интерфейс, определяющий как будут загружаться окна в память
/// </summary>
public interface ILoadableWindow
{
    WindowAsset GetWindowAsset(string idWindow);
}
