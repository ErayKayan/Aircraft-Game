using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject aircraft;
	[SerializeField] private GameObject particleExplosion;
	[SerializeField] private ParticleSystem particleConfetti;

	[SerializeField] private LevelSystem levelSystem;

	private void OnEnable()
	{
		Actions.OnGameFinished += Win;
		Actions.OnGameOver += Lose;
		Actions.OnHittedBox += PlayParticle;
	}

	private void OnDisable()
	{
		Actions.OnGameFinished -= Win;
		Actions.OnGameOver -= Lose;
		Actions.OnHittedBox -= PlayParticle;
	}

	public void PlayParticle()
	{
		particleConfetti.Play();
	}

	public void InstantiateParticle()
	{
		Instantiate(particleExplosion, aircraft.transform.position, Quaternion.identity);
		particleExplosion.SetActive(true);
	}
	
	private void Win()
	{
		Debug.Log("GAME WON");
		aircraft.GetComponent<AircraftController>().enabled = false;
		aircraft.GetComponent<Rigidbody>().isKinematic = true;
	}

	private void Lose()
	{
		Debug.Log("GAME LOST");
		InstantiateParticle();
		Destroy(aircraft);
	}
}
