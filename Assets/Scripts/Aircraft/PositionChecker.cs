using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{
	[SerializeField] private float maxLimitAxisX = 750f;
	[SerializeField] private float minLimitAxisX = -250f;

	[SerializeField] private float maxlimitAxisZ = 1000f;
	[SerializeField] private float minlimitAxisZ = 0f;

	private void Update()
	{
		LimitCheck();
	}

	private void LimitCheck()
	{
		if (transform.position.x > maxLimitAxisX || transform.position.x < minLimitAxisX|| transform.position.z > maxlimitAxisZ || transform.position.z < minlimitAxisZ)
		{
			Debug.Log("WRONG WAY");
			Actions.OnOutMap?.Invoke();

			if (transform.position.y < 0f)
			{
				Actions.OnGameOver?.Invoke();
				Actions.OnInMap?.Invoke();
			}
		}
		else
			Actions.OnInMap?.Invoke();
	}
}
