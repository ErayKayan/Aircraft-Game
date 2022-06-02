using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
	private static List<GameObject> Checkpoints = new List<GameObject>();

	private void Start()
	{
		UpdateList();
	}

	private void Update()
	{
		UpdateFirstCheckpoint();
		CheckLastCheckpoint();
	}

	private void UpdateList()
	{
		foreach (Transform child in gameObject.transform) if (child.CompareTag("Checkpoint"))
			{
				Checkpoints.Add(child.gameObject);
			}
	}

	private void UpdateFirstCheckpoint()
	{
		if (Checkpoints[0] != null)
		{
			if (Checkpoints[0].transform.GetChild(0).GetComponentInChildren<BoxCollider>().enabled == false
				&& Checkpoints[0].transform.GetChild(1).GetComponentInChildren<BoxCollider>().enabled == false 
				&& Checkpoints[0].GetComponentInChildren<Image>().color != Color.green)
			{
				Checkpoints[0].transform.GetChild(0).GetComponentInChildren<BoxCollider>().enabled = true; // Enable HitArea's Collider
				Checkpoints[0].transform.GetChild(1).GetComponentInChildren<BoxCollider>().enabled = true; // Enable MissArea's Collider
				Checkpoints[0].GetComponentInChildren<Image>().color = Color.green; // It sets the color green of first element in Checkpoint list which shows the next Checkpoint in game
			}

		}
	}

	private void CheckLastCheckpoint()
	{
		if (Checkpoints[0].activeSelf)
			return;
		else
			Actions.OnGameFinished?.Invoke();
	}

	protected virtual void Reached()
	{
		if (Checkpoints.Count > 1)
			Checkpoints.Remove(transform.parent.gameObject);

		transform.parent.gameObject.SetActive(false);
	}
}
