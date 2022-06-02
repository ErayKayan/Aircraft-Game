using UnityEngine;
using UnityEngine.UI;

public class LosePanel : Panel
{
	[SerializeField] private Button restartButton;
	
	private void OnEnable()
	{
		Actions.OnGameOver += Show;
	}

	private void OnDisable()
	{
		Actions.OnGameOver -= Show;
	}
}
