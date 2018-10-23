using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brighten : MonoBehaviour {

    public float duration;              //how long is each pulse
    private Light lt;                   //get and set Light Component

	void Start () {
        lt = GetComponent<Light>();
	}
	
	void Update () {
            //set the how fast each pulse is
            float phi = Time.time / duration * 2 * Mathf.PI;

        //set intensity of each pulse
            float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
            lt.intensity = amplitude;
    }
}
