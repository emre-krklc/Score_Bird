using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesisatci1 : MonoBehaviour {
	private GameObject[] Holder;
	public float Min,Max;
	private float distance=2.5f;                //Borular arası uzaklık değerimiz
	private float lastPipeX;

	// Use this for initialization
		void Start () {
		
	}
	
	void Awake(){
		Holder=GameObject.FindGameObjectsWithTag("PipeHolder");    //sahnemizdeki borulara ulaşma kod
		for (int i=0;i<Holder.Length;i++){                                                                                                    //for döngüsü
			Vector3 temp=Holder[i].transform.position;
			temp.y=Random.Range(Min,Max);                         //boruların karışık bir şekilde ayarlanmasının kodu
			Holder[i].transform.position=temp;

		}

		lastPipeX=Holder[0].transform.position.x;

		for(int i=1;i<Holder.Length;i++){
			if(lastPipeX<Holder[i].transform.position.x){
				                                                          //boruların pozizyounlarını eşitledik.
				lastPipeX=Holder[i].transform.position.x;
			}

		}
}



			void OnTriggerEnter2D(Collider2D hedef){

			if(hedef.tag=="PipeHolder"){                                 //tag le kullanmamızın sebebi farklı objelerde aynı işlemi yapmaması için.
				Vector3 temp=hedef.transform.position;
				temp.x=lastPipeX+distance;                             //şimdi yeni eklenen borular aynı şekil karışık bir şekilde konumlanmıs olacak.
			  temp.y=Random.Range(Min,Max);

				hedef.transform.position=temp;                
				lastPipeX=temp.x;






			}




			}









	




	







	


	// Update is called once per frame
	void Update () {
		
	}








	
}
