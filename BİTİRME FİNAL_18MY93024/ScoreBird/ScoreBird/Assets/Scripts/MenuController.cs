using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	
	void Start () {
		
	}
    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScreen");     //menumuzu oyun ekranında gösterme kodumuz.
    }
	
	
	void Update () {
		
	}
}
