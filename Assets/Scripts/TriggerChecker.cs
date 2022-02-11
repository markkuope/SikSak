using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);           
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        
        // Varmistetaan, että Platformit putoavat alas
        GetComponentInParent<Rigidbody>().isKinematic = false;

        // tuhotaan putoava Platform 2 sekunnin kuluttua
        Destroy(transform.parent.gameObject, 2f);
    }


}
