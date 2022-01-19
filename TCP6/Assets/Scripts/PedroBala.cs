using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedroBala : MonoBehaviour
{
    public GameObject interacao;
    public GameObject Dialogo;
    public int contagem;
    public bool conversando;
    public string[] textos;
    public Text texto;
    public Image imagem;
    public Sprite npc;
    public Sprite personagem;

    // Start is called before the first frame update
    void Start()
    {

        interacao.SetActive(false);
        Dialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (conversando)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(contagem+1 <= textos.Length)
                {
                    Dialogo.SetActive(true);
                    interacao.SetActive(false);
                    texto.text = textos[contagem];
                    contagem++;
                }
                else
                {
                    Dialogo.SetActive(false);
                }
              

             
            }


            if(contagem %2 == 0)
            {
                imagem.sprite = personagem;
            }
            else
            {
                imagem.sprite = npc;
            }

        }



    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        
            interacao.SetActive(true);
        conversando = true;
           
    }
    void OnTriggerExit2D(Collider2D col)
    {

        interacao.SetActive(false);
        Dialogo.SetActive(false);
        conversando = false;

    }
}
