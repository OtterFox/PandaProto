using UnityEngine;
using System.Collections;

public class CameraTransforms : MonoBehaviour {

    public enum CameraDirection {
    Up =0,
    Down = 1,
    Left = 2,
    Right = 3,
    Away = 4,
    UpAway = 5}
    public CameraDirection direction = CameraDirection.Up;

    float _speed = .001f;
    
        
	void Start ()
    {
        
    }
	
	void Update () {
        CameraUp();
        CameraAway();
        CameraUpAway();
    }

    void CameraUp()
    {
        if (direction == CameraDirection.Up)
        {
            transform.position += transform.up * _speed;
        }
    }

    void CameraAway()
    {
        if(direction == CameraDirection.Away)
        {
            transform.position -= transform.forward * _speed;
        }
    }

    void CameraUpAway()
    {
        if(direction == CameraDirection.UpAway)
        {
            transform.position += transform.up * .0001f;
            transform.position -= transform.forward * .0002f;
        }
    }

    
}
