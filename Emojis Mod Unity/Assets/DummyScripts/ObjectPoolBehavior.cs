public class ObjectPoolBehavior : IObjectPool
{
	public int poolSize;

	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<PoolableBehavior> inactiveChildren;

	[global::UnityEngine.SerializeField]
	public global::System.Collections.Generic.List<PoolableBehavior> activeChildren;

	public PoolableBehavior Prefab;

	public bool AutoInit;

	public bool DetachOnGet;

	private int childIndex;

	public override int InUse => 0;

	public override int NotInUse => 0;

	public virtual void Awake()
	{
	}

	public void InitPool(PoolableBehavior prefab)
	{
	}

	private void CreateOneInactive(PoolableBehavior prefab)
	{
	}

	public void ReclaimOldest()
	{
	}

	public void ReclaimAll()
	{
	}

	public override T Get<T>()
	{
		return null;
	}

	public override void Reclaim(PoolableBehavior obj)
	{
	}
}
