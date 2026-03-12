public class ProgressBar : global::UnityEngine.MonoBehaviour
{
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class _003CScaleDownY_003Ed__15 : global::System.Collections.Generic.IEnumerator<object>, global::System.Collections.IEnumerator, global::System.IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public ProgressBar _003C_003E4__this;

		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return null;
			}
		}

		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return null;
			}
		}

		[global::System.Diagnostics.DebuggerHidden]
		public _003CScaleDownY_003Ed__15(int _003C_003E1__state)
		{
		}

		[global::System.Diagnostics.DebuggerHidden]
		void global::System.IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool global::System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[global::System.Diagnostics.DebuggerHidden]
		void global::System.Collections.IEnumerator.Reset()
		{
		}
	}

	private const float CurrentCapScale = 1f;

	public float Value;

	public float CapValue;

	public float MaxValue;

	public float maskScale;

	public global::UnityEngine.SpriteRenderer Mask;

	[global::UnityEngine.Header("Cap")]
	public global::UnityEngine.SpriteRenderer cap;

	public global::UnityEngine.SpriteRenderer capGlow;

	public float capScale;

	public float capGlowSizePadding;

	private float lastValue;

	private float lastCapDiff;

	public float GlowAlpha
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	[global::System.Runtime.CompilerServices.IteratorStateMachine(typeof(ProgressBar._003CScaleDownY_003Ed__15))]
	public global::System.Collections.IEnumerator ScaleDownY(float duration)
	{
		return null;
	}

	public void ResetScale()
	{
	}

	private void Update()
	{
	}

	private void SetFillWidth(float xScale)
	{
	}

	private void SetCapWidth(float xScale)
	{
	}
}
