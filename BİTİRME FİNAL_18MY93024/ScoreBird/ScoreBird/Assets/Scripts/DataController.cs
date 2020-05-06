using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
    public static DataController ornek;


    private const string High_Score = "High Score";
    

    void Awake () {


        TekilNesne();
        Oyunilkdefabasladı();


    }
    void TekilNesne()
    {
        if (ornek != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Oyunilkdefabasladı()
    {
        if (PlayerPrefs.HasKey("Oyunilkdefabasladı"))                //oyun ilk defa başladıysa....
        {
            PlayerPrefs.SetInt(High_Score, 0);                      //en yuksek skorumuz 0 olarak belirlensin
            PlayerPrefs.SetInt("Oyunilkdefabasladı", 0);
        }
    }


    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(High_Score, score);             // hıgh score kayıt etme kodumuz
    }
    public int getHighScore()
    {
      return PlayerPrefs.GetInt(High_Score);                //verimizi gösterecek kodumuz
    }




	
	
	void Update () {
		
	}
}
