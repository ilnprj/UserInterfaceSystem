namespace UIS {
    /// <summary>
    /// Interface for base window type
    /// </summary>

    public interface IWindow
    {
        void OnOpen();

        void OnRefresh();

        void OnClose();
    }
}
