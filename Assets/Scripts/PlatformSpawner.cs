using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamonds;

    // Platformin viimeisin paikka
    Vector3 lastPos;
    // Platformin koko
    float size;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // alussa annetaan platformille paikka
        lastPos = platform.transform.position;
        // alussa annetaan kooksi size platformin x-arvo (se riittää, koska platform on neliön muotoinen)
        size = platform.transform.localScale.x;

        // tehdään aluksi 20 uutta platformia
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

    }


    public void StartSpawningPlatforms()
    {
        // tehdään uusi Platform 2s odotuksen jälkeen, 0.2 sekunnin välein
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }



    // Update is called once per frame
    void Update()
    {
        // peruutetaan Invoke
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        // muodostetaan satunnaisluku 0:n ja 5:n väliltä ja talletetaan se muuttujaan rand
        int rand = Random.Range(0, 6);
        // spawnataan joko X tai Z -suuntaan , satunnaisesti
        if (rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }

    }



    //Spawnaus X-suuntaan etäisyydelle 2 (=Platformin "pituus")
    void SpawnX()
    {
        // talletetaan muuttujaan position platformin viimeisin sijainti
        Vector3 position = lastPos;

        // muutetaan x -parametria arvon size verran
        position.x += size;

        // lastPos siirretään uuteen paikkaan
        lastPos = position;

        // spawnataan platform paikkaan position ilman rotaatiota (=Quaternio.identity)
        Instantiate(platform, position, Quaternion.identity);

        // spawnataan timantteja satunnaisesti 25%:n todennäköisyydellä. Mieti mistä tämä luku tulee.
        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamonds, new Vector3(position.x, position.y + 1, position.z), diamonds.transform.rotation);
        }
        

    }

    //Spawnaus Z-suuntaan etäisyydelle 2 (=Platformin "leveys")
    void SpawnZ()
    {
        // talletetaan muuttujaan position platformin viimeisin sijainti
        Vector3 position = lastPos;

        // muutetaan z -parametria arvon size verran
        position.z += size;

        // lastPos siirretään uuteen paikkaan
        lastPos = position;

        // spawnataan platform paikkaan position ilman rotaatiota (=Quaternio.identity)
        Instantiate(platform, position, Quaternion.identity);


        // spawnataan timantteja satunnaisesti 25%:n todennäköisyydellä. Mieti mistä tämä luku tulee.
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(position.x, position.y + 1, position.z), diamonds.transform.rotation);
        }

    }

}
