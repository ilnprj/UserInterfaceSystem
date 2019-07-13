using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBaseBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Button button;

    [HideInInspector]
    public Window window;

    public virtual void Awake()
    {
        button = GetComponent<Button>();
        window = GetComponentInParent<Window>();
        if (!button || !window)
        {
            Destroy(this);
        }
    }

    public virtual void Start() => button.onClick.AddListener(delegate { Action(); });

    public virtual void Action()
    {

    }
}
