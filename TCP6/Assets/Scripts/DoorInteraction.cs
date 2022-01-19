using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject interacao;
    
   
    // Start is called before the first frame update
    void Start()
    {
       interacao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            interacao.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
       
            interacao.SetActive(false);
        
    }

}
