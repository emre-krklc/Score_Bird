using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesisatci1 : MonoBehaviour {
	private GameObject[] Holder;
	public float Min,Max;
	private float distance=2.5f;
	private float lastPipeX;

	// Use this for initialization
		void Start () {
		
	}
	
	void Awake(){
		Holder=GameObject.FindGameObjectsWithTag("PipeHolder");
		for (int i=0;i<Holder.Length;i++){
			Vector3 temp=Holder[i].transform.position;
			temp.y=Random.Range(Min,Max);
			Holder[i].transform.position=temp;

		}

		lastPipeX=Holder[0].transform.position.x;

		for(int i=1;i<Holder.Length;i++){
			if(lastPipeX<Holder[i].transform.position.x){

				lastPipeX=Holder[i].transform.position.x;
			}

		}
}



			void OnTriggerEnter2D(Collider2D hedef){

			if(hedef.tag=="PipeHolder"){
				Vector3 temp=hedef.transform.position;
				temp.x=lastPipeX+distance;
				temp.y=Random.Range(Min,Max);

				hedef.transform.position=temp;
				lastPipeX=temp.x;






			}




			}









	




	







	


	// Update is called once per frame
	void Update () {
		
	}








	
}
