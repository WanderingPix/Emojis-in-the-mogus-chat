public class PoolableBehavior : global::UnityEngine.MonoBehaviour
{
	[global::UnityEngine.HideInInspector]
	public IObjectPool OwnerPool;

	[global::UnityEngine.HideInInspector]
	public int PoolIndex;

	public virtual void Reset()
	{
	}

	public void Awake()
	{
	}
}
