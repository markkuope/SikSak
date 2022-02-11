using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;

    [SerializeField] 
    private float speed;
    bool started;
    bool gameOver;

    Rigidbody rb;

     void Awake()
    {
        rb = GetComponent <Rigidbody> ();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();

            }
        }

         //Raycast -s�de muodostuu pallosta alasp�in , s�teen pituus on 1
        // kun Raycast -s�de ei osu toiseen peliobjektiin, niin peli loppuu
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            //pelin loppuessa pallo putoaa alasp�in nopeudella 25
            rb.velocity = new Vector3(0, -25f, 0);
            

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();

        }

       


        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            VaihdaSuuntaa();
        }
    }

    void VaihdaSuuntaa()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    // kun pallo t�rm�� timanttiin, tuhotaan timantti
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Timantti")
        {
            // tehd��n particle - efekti kun pallo t�rm�� timanttiin
           GameObject part =  Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(part, 1f);
            
        }
    }




}
