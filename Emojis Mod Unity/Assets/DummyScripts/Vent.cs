using UnityEngine;

public class Vent : global::UnityEngine.MonoBehaviour
{
	public static Vent currentVent;

	public int Id;

	public Vent Left;

	public Vent Right;

	public Vent Center;
	
	public ButtonBehavior[] Buttons;

	public global::UnityEngine.GameObject[] CleaningIndicators;

	public global::UnityEngine.AnimationClip EnterVentAnim;

	public global::UnityEngine.AnimationClip ExitVentAnim;

	public global::UnityEngine.Vector3 Offset;

	public float spreadAmount;

	public float spreadShift;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.SpriteRenderer myRend;

	[global::UnityEngine.SerializeField]
	private int numFramesUntilPlayerDisappearsOnEnter;

	[global::UnityEngine.SerializeField]
	private int numFramesUntilPlayerReappearsOnExit;

	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject additionalExitAnimation;

	public ImageNames UseIcon => default(ImageNames);

	public float UsableDistance => 0f;

	public float PercentCool => 0f;

	public int NumFramesUntilPlayerDisappears => 0;

	private Vent[] NearbyVents => null;
	
}
