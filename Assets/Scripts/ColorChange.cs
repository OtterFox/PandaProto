using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        gameObject.GetComponent<Renderer>().material.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
