using UnityEngine;
using System.Collections;

public class SpawnerTransform : MonoBehaviour {

    private float _speed = .002f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * _speed;
    }
}
