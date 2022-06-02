using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftController : MonoBehaviour
{
	[SerializeField] private Joystick joystick;
	[SerializeField] private Slider acceleratorPedal;

	[SerializeField] private float minForwardSpeed = 0f;
	[SerializeField] private float forwardSpeed = 15f;
	[SerializeField] private float horizontalSpeed = 4f;
	
	[SerializeField] private float maxHorizontalRotation = 0.1f;
	[SerializeField] private float maxVerticalRotation = 0.06f;

	[SerializeField] private float rotationSmoothness = 5f;

	private float horizontalInput;
	private float verticalInput;

	private float acceleratorPedalValue;

	private Vector3 idealEuler;

	void Start()
	{
		acceleratorPedal.onValueChanged.AddListener(delegate { SetGravity(); { ValueChangeCheck(); } });
	}

	void Update()
	{
		if (Input.GetMouseButton(0) || Input.touches.Length != 0)
		{
			horizontalInput = joystick.Horizontal;
			verticalInput = joystick.Vertical;
		}
		else
		{
			horizontalInput = Input.GetAxis("Horizontal");
			verticalInput = Input.GetAxis("Vertical");
		}

		Rotate();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		transform.position += (transform.forward * Time.deltaTime * ((forwardSpeed * acceleratorPedalValue) + minForwardSpeed));
		transform.Rotate(Vector3.up, horizontalInput * horizontalSpeed * Time.fixedDeltaTime);
	}

	private void Rotate()
	{
		idealEuler.x = verticalInput * maxVerticalRotation;
		idealEuler.z = -horizontalInput * maxHorizontalRotation;
		idealEuler.y = transform.localEulerAngles.y;
		var q = Quaternion.Euler(idealEuler);
		transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * rotationSmoothness);
	}

	public void ValueChangeCheck()
	{
		acceleratorPedalValue = acceleratorPedal.value;
		if (acceleratorPedalValue >= 1)
			minForwardSpeed = 5f;
	}

	public void SetGravity()
	{
		if (acceleratorPedalValue >= 2.5f)
			Physics.gravity = new Vector3(0, 0.07f, 0);
		else if (acceleratorPedalValue < 2.5f)
			Physics.gravity = new Vector3(0, -0.20f, 0);
	}
}

