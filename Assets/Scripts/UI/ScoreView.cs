using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
	[SerializeField] private ScoreSystem scoreSystem;
	[SerializeField] private TMP_Text scoreText;

	private void Awake()
	{
		scoreSystem = FindObjectOfType<ScoreSystem>();
	}

	private void Update()
	{
		UpdateScore();
	}

	private void UpdateScore()
    {
        scoreText.text = scoreSystem.score.ToString();
    }
}
