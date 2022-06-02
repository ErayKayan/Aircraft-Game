using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour
{
	[SerializeField] private float countdownTime;
	[SerializeField] private TMP_Text countdownDisplay;
	[SerializeField] private Image warningSign;

	private void OnEnable()
	{
		Actions.OnOutMap += CountdownToGameOver;
		Actions.OnInMap += CountdownCanceled;
	}

	private void OnDisable()
	{
		Actions.OnOutMap -= CountdownToGameOver;
		Actions.OnInMap -= CountdownCanceled;
	}

	public void CountdownToGameOver()
	{
		warningSign.gameObject.SetActive(true);
		countdownDisplay.text = countdownTime.ToString("0");

		if (countdownTime > 0)
		{
			countdownTime -= Time.deltaTime;
		}
		else
		{
			warningSign.gameObject.SetActive(false);
			Actions.OnGameOver?.Invoke();
		}

	}

	public void CountdownCanceled()
	{
		countdownTime = 15f;
		warningSign.gameObject.SetActive(false);
	}
}
