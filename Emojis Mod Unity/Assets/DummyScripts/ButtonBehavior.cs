public class ButtonBehavior : UiElement
{
	public bool OnUp;

	public bool OnDown;

	public bool Repeat;

	public global::UnityEngine.UI.Button.ButtonClickedEvent OnClick;

	private global::UnityEngine.Collider2D[] colliders;

	private float downTime;

	public global::UnityEngine.SpriteRenderer spriteRenderer;

	private bool checkedClickEvent;

	public void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void ReceiveClick()
	{
	}
}
