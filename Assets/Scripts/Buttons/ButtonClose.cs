/// <summary>
/// Кнопка которая назначается автоматически и закрывает текущее окно.
/// </summary>
/// 
public class ButtonClose : ButtonSetter
{
    /// <summary>
    /// Действие которое автоматически подписывается на клик кнопки родительским классом.
    /// </summary>
    public override void Action()
    {
        if (window.Focus)
        {
            window.OnClose();
        }
    }
}
