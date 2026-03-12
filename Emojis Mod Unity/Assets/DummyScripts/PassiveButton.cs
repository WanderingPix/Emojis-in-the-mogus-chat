public class PassiveButton : PassiveUiElement
{
	public global::UnityEngine.UI.Button.ButtonClickedEvent OnClick;

	public global::UnityEngine.AudioClip ClickSound;

	public global::UnityEngine.AudioClip HoverSound;

	public bool OnUp;

	public bool OnDown;

	public bool OnRepeat;

	public bool OnUpGraphic;

	public bool OnDownGraphic;

	public float RepeatDuration;

	[global::UnityEngine.Header("Hold to Use")]
	public global::UnityEngine.SpriteRenderer HeldButtonSprite;

	public bool HoldToUse;

	private bool beingHeldDown;

	private float repeatTimer;

	private float totalHeldTime;

	private bool checkedClickEvent;

	private bool selected;

	[global::UnityEngine.Header("States")]
	[global::UnityEngine.SerializeField]
	public global::UnityEngine.GameObject selectedSprites;

	[global::UnityEngine.SerializeField]
	public global::UnityEngine.GameObject activeSprites;

	[global::UnityEngine.SerializeField]
	public global::UnityEngine.GameObject inactiveSprites;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject disabledSprites;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject selectedInactiveSprites;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject onClickSprites;

	[global::UnityEngine.SerializeField]
	private bool forceInactiveSpritesMobile;

	[global::UnityEngine.Space(10f)]
	[global::UnityEngine.SerializeField]
	private global::TMPro.TextMeshPro buttonText;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color selectedTextColor;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color activeTextColor;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color inactiveTextColor;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color disabledTextColor;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color selectedInactiveTextColor;

	private static readonly int STENCIL_COMP;

	private static readonly int STENCIL;

	public override bool HandleUp => false;

	public override bool HandleDown => false;

	public override bool HandleRepeat => false;

	public override bool HandleUpClickGraphic => false;

	public override bool HandleDownClickGraphic => false;

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected override void Update()
	{
	}

	private new void OnDisable()
	{
	}

	protected override void OnEnable()
	{
	}

	public override void ReceiveClickDown()
	{
	}

	public override void ReceiveRepeatDown()
	{
	}

	public override void ReceiveClickUp()
	{
	}

	public void SetButtonEnableState(bool enabled)
	{
	}

	public void AddOnClickListeners(params global::System.Action[] callbacks)
	{
	}

	public override void ReleaseButton()
	{
	}

	public override void ReceiveMouseOut()
	{
	}

	public override void ReceiveMouseOver()
	{
	}

	public override void ReceiveClickUpGraphic()
	{
	}

	public override void ReceiveClickDownGraphic()
	{
	}

	private void SetPassiveButtonClickState(bool clicked)
	{
	}

	public void SetPassiveButtonHoverStateActive()
	{
	}

	public void SetPassiveButtonHoverStateInactive()
	{
	}

	private void SetPassiveButtonDisabledState()
	{
	}

	public void SelectButton(bool isSelected)
	{
	}

	public void ChangeButtonText(string s)
	{
	}

	public bool IsSelected()
	{
		return false;
	}

	public void SetMaskLayer(int maskID)
	{
	}
}
