public class GridArrange : global::UnityEngine.MonoBehaviour
{
	public enum StartAlign
	{
		Left = 0,
		Right = 1
	}

	public global::UnityEngine.Vector2 CellSize;

	public GridArrange.StartAlign Alignment;

	public int MaxColumns;

	private global::System.Collections.Generic.List<global::UnityEngine.Transform> cells;

	private static global::System.Collections.Generic.List<global::UnityEngine.Transform> currentChildren;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void CheckCurrentChildren()
	{
	}

	private void GetChildsActive()
	{
	}

	private void ArrangeChilds()
	{
	}
}
