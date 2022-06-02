using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	public int score = 0;

	private void OnEnable()
	{
		Actions.OnHittedBox += PlusScore;
		Actions.OnMissedBox += MinusScore;
	}

	private void OnDisable()
	{
		Actions.OnHittedBox -= PlusScore;
		Actions.OnMissedBox -= MinusScore;
	}

	public void PlusScore()
	{
		score += 100;
	}

	public void MinusScore()
	{
		score -= 100;
	}
}
