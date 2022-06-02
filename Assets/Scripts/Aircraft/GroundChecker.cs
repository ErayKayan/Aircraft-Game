using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	public float Height => transform.localScale.y;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Terrain"))
		{
			if (Physics.Raycast(transform.position, transform.forward, out var hitforward,  Height* 10, LayerMask.GetMask("Terrain")) ||
				Physics.Raycast(transform.position, transform.right, out var hitright, Height * 10, LayerMask.GetMask("Terrain")) ||
				Physics.Raycast(transform.position, transform.right * -1, out var hitleft, Height * 10, LayerMask.GetMask("Terrain")))
			{
				Actions.OnGameOver?.Invoke();
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward);
		Gizmos.DrawLine(transform.position, transform.position + transform.right * -1);
		Gizmos.DrawLine(transform.position, transform.position + transform.right);
	}
}
