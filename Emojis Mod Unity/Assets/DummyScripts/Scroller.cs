public class Scroller : PassiveUiElement
{
	public delegate void ScrollHandler(float value);

	public global::UnityEngine.Transform Inner;

	public bool allowY;

	public bool showY;

	[global::UnityEngine.Serialization.FormerlySerializedAs("YBounds")]
	[global::UnityEngine.SerializeField]
	public FloatRange ContentYBounds;

	[global::UnityEngine.Serialization.FormerlySerializedAs("ScrollerYRange")]
	public FloatRange ScrollbarYBounds;

	[global::UnityEngine.Serialization.FormerlySerializedAs("ScrollerY")]
	public Scrollbar ScrollbarY;

	public bool allowX;

	public bool showX;

	[global::UnityEngine.Serialization.FormerlySerializedAs("XBounds")]
	[global::UnityEngine.SerializeField]
	private FloatRange ContentXBounds;

	[global::UnityEngine.Serialization.FormerlySerializedAs("ScrollerXRange")]
	public FloatRange ScrollbarXBounds;

	[global::UnityEngine.Serialization.FormerlySerializedAs("ScrollerX")]
	public Scrollbar ScrollbarX;

	public float DragScrollSpeed;

	public float ScrollWheelSpeed;

	public bool MouseMustBeOverToScroll;

	private global::UnityEngine.Vector2 velocity;

	private bool active;

	private bool mouseOver;

	public Scroller.ScrollHandler OnScrollXEvent;

	public Scroller.ScrollHandler OnScrollYEvent;

	public override bool HandleUp => false;

	public override bool HandleDown => false;

	public override bool HandleDrag => false;

	public override bool HandleOverOut => false;

	public bool AtTop => false;

	public bool AtBottom => false;

	public bool AtLeft => false;

	public bool AtRight => false;

	public global::UnityEngine.Collider2D Hitbox => null;

	public void SetBounds(FloatRange yBounds, FloatRange xBounds)
	{
	}

	public void CalculateAndSetYBounds(float amount, float numPerRow, float numRowsVisible, float spacing)
	{
	}

	public void SetBoundsMax(float yMax, float xMax)
	{
	}

	public void SetYBoundsMax(float yMax)
	{
	}

	public void SetBoundsMin(float yMin, float xMin)
	{
	}

	public void SetYBoundsMin(float yMin)
	{
	}

	public FloatRange GetYBounds()
	{
		return null;
	}

	public FloatRange GetXBounds()
	{
		return null;
	}

	protected override void Update()
	{
	}

	public void ScrollDown()
	{
	}

	public void ScrollUp()
	{
	}

	public float GetScrollPercY()
	{
		return 0f;
	}

	public float GetScrollPercX()
	{
		return 0f;
	}

	public void ScrollPercentY(float p)
	{
	}

	public void ScrollPercentX(float p)
	{
	}

	public override void ReceiveClickDown()
	{
	}

	public override void ReceiveClickUp()
	{
	}

	public override void ReceiveClickDrag(global::UnityEngine.Vector2 dragDelta)
	{
	}

	public void ScrollToScrollbarPositionY(global::UnityEngine.Vector3 newScrollbarPosition)
	{
	}

	public void ScrollToScrollbarPositionX(global::UnityEngine.Vector3 newScrollbarPosition)
	{
	}

	public void ScrollRelative(global::UnityEngine.Vector2 dragDelta)
	{
	}

	public void UpdateScrollBars()
	{
	}

	public void ScrollToTop()
	{
	}
}
