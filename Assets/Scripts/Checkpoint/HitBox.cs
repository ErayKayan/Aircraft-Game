using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : Checkpoint
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Aircraft"))
		{
			Debug.Log("HIT CHECKPOINT");
			Reached();
		}
	}
	
	protected override void Reached()
	{
		Actions.OnHittedBox?.Invoke();
		base.Reached();
	}
}
