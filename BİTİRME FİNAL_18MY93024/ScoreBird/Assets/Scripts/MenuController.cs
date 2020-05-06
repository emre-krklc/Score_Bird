using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScreen");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
