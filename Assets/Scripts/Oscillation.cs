using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour {

	public int factor;
	public bool inverseDir;
	private int _direction = 1;

	private void Start()
	{
		if (inverseDir)
			_direction = -1;
	}

	private void Update ()
	{
		if (isWithin(transform.localEulerAngles.z, factor, 180))
			_direction = -1;

		if (isWithin(transform.localEulerAngles.z, 180, 360 - factor))
			_direction = 1;
		
		transform.Rotate((Vector3.forward * _direction) * factor * Time.deltaTime);
	}

	private bool isWithin(float value, float min, float max)
	{
		if (value >= min && value <= max)
			return true;
		return false;
	}
}
