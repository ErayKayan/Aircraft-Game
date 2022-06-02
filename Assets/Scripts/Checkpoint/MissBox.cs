using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBox : Checkpoint
{
	[SerializeField] private GameObject imageCross;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Aircraft"))
		{
			Debug.Log("MISS CHECKPOINT");
			Reached();
		}
	}

	protected override void Reached()
	{
		imageCross.SetActive(true);
		Invoke(nameof(DisableCrossImage), 2f);
		Actions.OnMissedBox?.Invoke();
		base.Reached();
	}

	private void DisableCrossImage()
	{
		imageCross.SetActive(false);
	}
}
