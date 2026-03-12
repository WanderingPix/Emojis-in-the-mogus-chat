public class TextBoxTMP : global::UnityEngine.MonoBehaviour, IFocusHolder
{
	public static readonly global::System.Collections.Generic.HashSet<char> SymbolChars;

	public static readonly global::System.Collections.Generic.HashSet<char> EmailChars;

	public const char HiddenChar = '*';

	public bool allowAllCharacters;

	public string text;

	private string compoText;

	public int characterLimit;

	[global::UnityEngine.SerializeField]
	public global::TMPro.TextMeshPro outputText;

	public global::UnityEngine.SpriteRenderer Background;

	public global::UnityEngine.MeshRenderer Pipe;

	[global::UnityEngine.SerializeField]
	private global::TMPro.TextMeshPro placeholderText;

	private float pipeBlinkTimer;

	public bool ClearOnFocus;

	public bool ForceUppercase;

	public global::UnityEngine.UI.Button.ButtonClickedEvent OnEnter;

	public global::UnityEngine.UI.Button.ButtonClickedEvent OnChange;

	public global::UnityEngine.UI.Button.ButtonClickedEvent OnFocusLost;

	private global::UnityEngine.TouchScreenKeyboard keyboard;

	public bool AllowSymbols;

	public bool AllowEmail;

	public bool IpMode;

	public bool AllowPaste;

	public bool Hidden;

	private global::UnityEngine.Collider2D[] colliders;

	private bool hasFocus;

	private int caretPos;

	private float caretRepeatTimer;

	public float caretYOffset;

	public global::UnityEngine.Color colorBackground;

	private global::System.Text.StringBuilder tempTxt;

	public global::UnityEngine.SpriteRenderer sendButtonGlyph;

	public bool SendOnFullChars;

	public float TextHeight => 0f;

	public void Start()
	{
	}

	public void OnDestroy()
	{
	}

	public void ResetField()
	{
	}

	public void Clear()
	{
	}

	public void Update()
	{
	}

	public void GiveFocus()
	{
	}

	public void ForceKeyboardClose()
	{
	}

	public void LoseFocus()
	{
	}

	public bool CheckCollision(global::UnityEngine.Vector2 pt)
	{
		return false;
	}

	public void SetText(string input, string inputCompo = "")
	{
	}

	public bool IsCharAllowed(char i)
	{
		return false;
	}

	private void MoveCaret()
	{
	}

	private void AdjustCaretPosition(int adjustment)
	{
	}

	private void SetCaretPosition(int index)
	{
	}

	private void SetPipePosition()
	{
	}
}
