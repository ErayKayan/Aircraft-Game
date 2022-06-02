using UnityEngine;
using UnityEngine.UI;

public class WinPanel : Panel
{
	[SerializeField] private Button restartButton;

	private void OnEnable()
	{
		Actions.OnGameFinished += Show;
	}

	private void OnDisable()
	{
		Actions.OnGameFinished -= Show;
	}
}
