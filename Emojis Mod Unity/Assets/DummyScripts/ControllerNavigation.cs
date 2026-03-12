using System;

[Serializable]
public struct ControllerNavigation
{
	public enum Mode
	{
		Automatic = 0,
		Explicit = 1
	}

	public Mode mode;

	public UiElement selectOnUp;

	public UiElement selectOnDown;

	public UiElement selectOnLeft;

	public UiElement selectOnRight;

	public static ControllerNavigation defaultNavigation { get; }
}
