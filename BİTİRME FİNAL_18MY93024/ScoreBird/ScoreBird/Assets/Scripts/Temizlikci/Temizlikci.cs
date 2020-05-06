using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temizlikci : MonoBehaviour {
	private GameObject[] Background;
	private GameObject[] Ground;

	private float lastBGX;
	private float lastGroundX;
	void Awake(){
		Background= GameObject.FindGameObjectsWithTag("Background");     //arkplanımızı tanımlayalım.
		Ground=GameObject.FindGameObjectsWithTag("Ground");             //zeminimizi tanımlayalım.

		lastBGX=Background[0].transform.position.x;     //
		lastGroundX=Ground[0].transform.position.x;

		for(int i =1;i<Background.Length;i++){         //int 1 den başlayarak artacak ta ki arkaplan sayısına kadar
			if(lastBGX<Background[i].transform.position.x){
				lastBGX=Background[i].transform.position.x;

			}
		}

		for(int i =1;i<Ground.Length;i++){                  //int 1 den başlayarak artacak ta ki zemin sayısına kadar
			if(lastGroundX<Ground[i].transform.position.x){
				lastGroundX=Ground[i].transform.position.x;
				
			}
		}

	}



	void OnTriggerEnter2D(Collider2D hedef){               // (hedefi belirledik)
		if (hedef.tag=="Background"){              //eğer collider hedefle iç içe geçerse... 
			Vector3 temp = hedef.transform.position;            //arkaplanın pozisyonunu alma
			float genislik= ((BoxCollider2D)hedef).size.x;   //arkaplanın(hedefin) genişliğini aldık
			temp.x=genislik+lastBGX;
			hedef.transform.position=temp;
			lastBGX=temp.x;                             //sonuç olarak ekran hareket ettikçe sol taraftan alınan arkaplan sağ tarafa eklenecek
			
			
			}
			
			
		else if (hedef.tag=="Ground")
			
		      {
			Vector3 temp = hedef.transform.position;
			float genislik= ((BoxCollider2D)hedef).size.x;
			temp.x=genislik+lastGroundX;
			hedef.transform.position=temp;
			lastGroundX=temp.x;
			                                                        //sonuç olarak ekran hareket ettikçe sol taraftan alınan zemin sağ tarafa eklenecek



		}




	}
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
}
