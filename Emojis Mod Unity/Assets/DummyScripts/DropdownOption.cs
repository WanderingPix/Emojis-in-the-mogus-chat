public class DropdownOption : PoolableBehavior
{
	[global::UnityEngine.SerializeField]
	private global::TMPro.TextMeshPro optionText;

	[global::UnityEngine.SerializeField]
	private PassiveButton button;

	public UiElement ButtonUiElement => null;

	public void Initialize(string text, global::System.Action onClick, global::UnityEngine.Collider2D clickMask, global::UnityEngine.Vector3 position)
	{
	}

	public override void Reset()
	{
	}
}
