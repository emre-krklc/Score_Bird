using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public static float setX;

	
	void Start () {
		
	}
	
	
	void Update () {
		if(BirdScript.instance!=null){
			if(BirdScript.instance.isAlive==true){      //kuş hayattaysa ,oyun devam ediyorsa kamerayı oynat dedik.
				MoveTheCamera();
			}
		}
		
	}
	void MoveTheCamera(){
		Vector3 temp = transform.position;
		temp.x=BirdScript.instance.GetPositionX();            //kameranın kuşu kuşu takip etmesi
		transform.position=temp;
	}
}
