using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorRandom : MonoBehaviour {
	public float colorDuration = 1;
	
	private Camera cam;
	private float timer = 0;
	private float duration = 3.0F;
	private Color newColor;
	private Color oldColor;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
		oldColor = cam.backgroundColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= colorDuration)
		{
			timer = 0;
			oldColor = cam.backgroundColor;
			newColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			
		}
		timer += Time.deltaTime;
		float t = Mathf.PingPong(Time.time, duration) / duration;
		cam.backgroundColor = Color.Lerp(oldColor, newColor, t);
	}
}
