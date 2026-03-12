public class DropdownButton : global::UnityEngine.MonoBehaviour
{
	[global::UnityEngine.SerializeField]
	private float buttonStartY;

	[global::UnityEngine.SerializeField]
	private float buttonHeight;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject optionsScreen;

	[global::UnityEngine.SerializeField]
	private PassiveButton openOptionsButton;

	[global::UnityEngine.SerializeField]
	private PassiveButton closeButton;

	[global::UnityEngine.SerializeField]
	private global::TMPro.TextMeshPro buttonText;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Collider2D clickMask;

	[global::UnityEngine.SerializeField]
	private ObjectPoolBehavior optionPool;

	private global::System.Collections.Generic.List<string> options;

	private global::System.Action<int> onOptionSelect;

	public int SelectedIndex { get; private set; }

	private string DropdownName => null;

	public void AddOption(string optionName)
	{
	}

	public void SetSelectedIndex(int i)
	{
	}

	public void SetOnOptionSelect(global::System.Action<int> onOptionSelect)
	{
	}

	private void Start()
	{
	}

	private void OpenDropdownOptions()
	{
	}

	private void SelectOption(int buttonIndex)
	{
	}

	private void Close()
	{
	}
}
