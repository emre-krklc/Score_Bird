using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temizlikci : MonoBehaviour {
	private GameObject[] Background;
	private GameObject[] Ground;

	private float lastBGX;
	private float lastGroundX;
	void Awake(){
		Background= GameObject.FindGameObjectsWithTag("Background");
		Ground=GameObject.FindGameObjectsWithTag("Ground");

		lastBGX=Background[0].transform.position.x;
		lastGroundX=Ground[0].transform.position.x;

		for(int i =1;i<Background.Length;i++){
			if(lastBGX<Background[i].transform.position.x){
				lastBGX=Background[i].transform.position.x;

			}
		}

		for(int i =1;i<Ground.Length;i++){
			if(lastGroundX<Ground[i].transform.position.x){
				lastGroundX=Ground[i].transform.position.x;
				
			}
		}

	}



	void OnTriggerEnter2D(Collider2D hedef){
		if (hedef.tag=="Background"){
			Vector3 temp = hedef.transform.position;
			float genislik= ((BoxCollider2D)hedef).size.x;
			temp.x=genislik+lastBGX;
			hedef.transform.position=temp;
			lastBGX=temp.x;
			
			
			}
			
			
		else if (hedef.tag=="Ground")
			
		      {
			Vector3 temp = hedef.transform.position;
			float genislik= ((BoxCollider2D)hedef).size.x;
			temp.x=genislik+lastGroundX;
			hedef.transform.position=temp;
			lastGroundX=temp.x;
			



			}



		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
