using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    float _speed = .001f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CameraUp();

    }

    void CameraUp()
    {
        transform.position += transform.up * _speed;
    }

    
}
