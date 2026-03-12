public class DeadBody : UnityEngine.MonoBehaviour
{
	public bool Reported;

	public byte ParentId;

	public global::UnityEngine.Collider2D myCollider;

	public global::UnityEngine.SpriteRenderer bloodSplatter;

	public global::UnityEngine.SpriteRenderer[] bodyRenderers;

	public global::UnityEngine.Vector2 TruePosition => default(global::UnityEngine.Vector2);

	public void OnClick()
	{
	}
}
