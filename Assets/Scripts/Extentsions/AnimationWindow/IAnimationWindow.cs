using System;

public interface IAnimationWindow
{
    void OnOpenWindowAnim();
    void OnCloseWinodwAnim(Action closeHandler);
}
