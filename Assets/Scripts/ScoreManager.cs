using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // instance saa sis�ll�kseen t�m�n scriptin
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // score 0 tallennetaan tietokoneelle, hakuavaimena score
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore()
    {
        score += 1;       
    }

    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f); // scorea kertyy kun aikaa kuluu, t�ss� 2 pistett� sekunnissa
    }

    public void stopScore()
    {
        CancelInvoke("incrementScore");
        // score tallennetaan tietokoneelle, hakuavaimena score
        PlayerPrefs.SetInt("score", score);

        //  tarkistetaan, onko highScore jo tallennettu ja verrataan sitten scoreen
        if (PlayerPrefs.HasKey("highScore"))
        {

            // verrataan scoreen ja tallennetaan score uudeksi highScore - arvoksi
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
            
        }
        // jos highScore ei ole viel� tallennettu, annetaan sille arvo score (ensimm�inen pelikerta)
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

    }


}
