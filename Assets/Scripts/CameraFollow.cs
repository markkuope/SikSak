using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;    
    Vector3 offset;
    // lerpRate -nopeus jolla kamera seuraa palloa
    public float lerpRate;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // offset on et�isyys kameran ja pallon v�lill�
        offset = ball.transform.position - transform.position;

        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        // talletetaan kameran sijainti pos muuttujaan
        Vector3 pos = transform.position;
        // talletetaan kameran haluttu sijainti targetPos -muuttujaan
        Vector3 targetPos = ball.transform.position - offset;
        //liikutetaan kameraa sijainnista toiseen "pehme�sti" nopeudella lerpRate
        // ja talletetaan uusi arvo sijaintiin pos
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        // lopuksi talletetaan t�m� pos arvo alkuper�iseen sijaintiin
        transform.position = pos;
    }

}
