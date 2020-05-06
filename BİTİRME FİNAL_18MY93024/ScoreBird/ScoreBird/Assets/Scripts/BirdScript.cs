using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
	public static BirdScript instance;          //bu scripte kullanıdığımız fonksiyonları diğer scriptlerle kullanabilmek için bu kodu kullandık.

	[SerializeField]
	private Rigidbody2D MyRigidBody;
	
	[SerializeField]
	private Animator Anim;                     //animasyon
	private float Speed= 3f;            //kuşumuzun zıplama hızı değeri
	private float BounceSpeed= 4f;    //kuşumuzun zıplama kuvveti değeri
	private bool didFlap;   //ölme
	public bool isAlive;     //hayatta iken
    public int score;           //skor 
   
    


	[SerializeField]
	private AudioSource audioSource;
	
	[SerializeField]
	private AudioClip flapclip,dieclip,pointclip;

	void Awake(){
		if(instance==null){
			instance=this;
		}
	isAlive=true;
	setCameraX();
	}
	
	
	void Start () {
		
	}
	
	
	void FixedUpdate () {
		if(isAlive){                                                //Burada koşul kullandım hayattaysa vs.
			Vector3 temp =transform.position;
			temp.x+=Speed*Time.deltaTime;          //her frame'e göre tekrardan hızını güncelleyecek yani hız almış olacağız
			transform.position=temp;
			if(didFlap){                    //kuş düşüyorsa..
				didFlap=false;
				MyRigidBody.velocity=new Vector2(0,BounceSpeed);
				audioSource.PlayOneShot(flapclip);  //zıplama sesi eklediğimiz kod
				Anim.SetTrigger("flap");                               //kuşumuzu belirlediğimiz kuvvete göre zıplattgımız kodumuz
				
				

			}if(MyRigidBody.velocity.y>=0){                       //kuş düşmüyorsa...
				transform.rotation=Quaternion.Euler(0,0,0);

			}else {
				                                                                      
			
			float angle=0;
			angle=Mathf.Lerp(0,-90,-MyRigidBody.velocity.y/7);                          //kuşumuzun kanat çırpmadığı zaman aşağı doğru eğim almamız yani açı vermiş olduk...
				transform.rotation=Quaternion.Euler(0,0,angle);
			

			}



		}
		
	}
	public float GetPositionX(){
		return transform.position.x;
	}
	void setCameraX(){     //kameranın x deki pozisyonunu al demek.
		CameraScript.setX=(Camera.main.transform.position.x-transform.position.x)-1f;

	}





	public void Uc(){
		didFlap=true;

	}

	void OnCollisionEnter2D(Collision2D hedef){
	if (hedef.gameObject.tag=="Ground"|| hedef.gameObject.tag=="Pipe"){                     //eğer boruya  veya   zeminde carparsak.... 
		if (isAlive){
			isAlive=false;                                               
			Anim.SetTrigger("bluedied");     //ve ölme animasyonumuzu girdik.



                GamePlayController.ornek.SkoruGoster(score);  //karakterimiz oldugunde skoru göster
				
			audioSource.PlayOneShot(dieclip);         //ses kodumuz

		}



	}
	
	}



	void OnTriggerEnter2D(Collider2D hedef){
		if (hedef.gameObject.tag=="PipeHolder"){


            score++;
            GamePlayController.ornek.SetScore(score);        //skorumuz engellerden geçtiğinde score artsın.
			                                                      
            audioSource.PlayOneShot(pointclip);
		}

		//Engele çarptıgımızda cıkacak olan ses kodumuz.




	}



}
