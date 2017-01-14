using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToGamePlay()
    {
        SceneManager.LoadScene(1);
    }
}
