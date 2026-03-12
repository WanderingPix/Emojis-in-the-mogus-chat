public abstract class UiElement : global::UnityEngine.MonoBehaviour
{
	public global::UnityEngine.Events.UnityEvent OnMouseOver;

	public global::UnityEngine.Events.UnityEvent OnMouseOut;

	public ControllerNavigation ControllerNav;

	public virtual void ReceiveMouseOut()
	{
	}

	public virtual void ReceiveMouseOver()
	{
	}
}
