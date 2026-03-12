public interface IFocusHolder
{
	void GiveFocus();

	void LoseFocus();

	bool CheckCollision(global::UnityEngine.Vector2 pt);
}
