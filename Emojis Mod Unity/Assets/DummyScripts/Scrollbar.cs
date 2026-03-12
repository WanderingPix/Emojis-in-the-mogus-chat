public class Scrollbar : PassiveUiElement
{
	[global::UnityEngine.SerializeField]
	private Scroller parent;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.SpriteRenderer graphic;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.SpriteRenderer trackGraphic;

	[global::UnityEngine.SerializeField]
	private bool horizontal;

	[global::UnityEngine.SerializeField]
	private float dragSpeed;

	private bool dragable;

	public override bool HandleDrag => false;

	public void Toggle(bool on)
	{
	}

	public void UpdatePosition(global::UnityEngine.Vector3 position)
	{
	}

	public override void ReceiveClickDrag(global::UnityEngine.Vector2 dragDelta)
	{
	}
}
