using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    // luodaan julkinen UiManager instance, jolloin muista scripteist� 
    //p��st��n kurkottamaan t�h�n scriptiin
    public static UiManager instance;

    public GameObject siksakPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;

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
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void GameStart()
    {       

        tapText.SetActive (false);
        siksakPanel.GetComponent<Animator>().Play ("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt ("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        // ladataan scene uudestaan
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
