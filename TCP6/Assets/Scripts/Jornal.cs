using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jornal : MonoBehaviour
{
    public GameObject jornal;
    public Button botao;
    // Start is called before the first frame update
    void Start()
    {
        jornal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        botao.onClick.AddListener(delegate () { SomeMami(); });

    }
    void SomeMami()
    {
        jornal.SetActive(false);

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            jornal.SetActive(true);
        }

          


    }
    void OnTriggerExit2D(Collider2D col)
    {
        jornal.SetActive(false);
    }
}
