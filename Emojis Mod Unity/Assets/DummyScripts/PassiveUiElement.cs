public abstract class PassiveUiElement : UiElement
{
	public global::UnityEngine.Collider2D ClickMask;

	public global::UnityEngine.Collider2D[] Colliders;

	public virtual bool HandleUp => false;

	public virtual bool HandleDown => false;

	public virtual bool HandleRepeat => false;

	public virtual bool HandleUpClickGraphic => false;

	public virtual bool HandleDownClickGraphic => false;

	public virtual bool HandleDrag => false;

	public virtual bool HandleOverOut => false;

	public float CachedZ { get; set; }

	protected virtual void OnEnable()
	{
	}

	protected virtual void Start()
	{
	}

	protected virtual void Update()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	public virtual void ReceiveClickDown()
	{
	}

	public virtual void ReceiveRepeatDown()
	{
	}

	public virtual void ReceiveClickUp()
	{
	}

	public virtual void ReleaseButton()
	{
	}

	public virtual void ReceiveClickDrag(global::UnityEngine.Vector2 dragDelta)
	{
	}

	public virtual void ReceiveClickUpGraphic()
	{
	}

	public virtual void ReceiveClickDownGraphic()
	{
	}
}
