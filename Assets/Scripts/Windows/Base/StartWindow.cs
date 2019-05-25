using UnityEngine;

/// <summary>
/// Стартовый экран для сцены
/// </summary>\
[CreateAssetMenu(fileName = "StartWindow",menuName = "Create Start Window",order = 0)]
public class StartWindow : ScriptableObject
{
    [SerializeField]
    private Window window;

    public Window GetWindow
    {
        get
        {
            return window;
        }
    }
}
