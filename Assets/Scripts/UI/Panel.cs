using UnityEngine;

public abstract class Panel : MonoBehaviour
{
	protected virtual void Show()
	{
		transform.GetChild(0).gameObject.SetActive(true);
	}

	protected virtual void Hide()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}
}

