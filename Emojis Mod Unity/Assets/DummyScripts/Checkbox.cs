public class Checkbox : global::UnityEngine.MonoBehaviour
{
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.SpriteRenderer checkmark;

	[global::UnityEngine.SerializeField]
	private PassiveButton button;

	private bool oldValue;

	public bool IsChecked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void Toggle()
	{
	}

	private void Awake()
	{
	}
}
