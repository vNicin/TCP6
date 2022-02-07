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
    public bool conversandoo;
    public string[] textos;
    public Text texto;
    public Image imagem;
    public Sprite npc;
    public Sprite personagem;
    public int id;
    public Button botao;
    public int numero;
    public bool contou;
    // Start is called before the first frame update
    void Start()
    {
        
        interacao.SetActive(false);
        Dialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {if(id!= 8)
        {
            if (conversando)
            {

                botao.onClick.AddListener(delegate () { InteragiuMami(); });


                if (contou)
                {
                    contagem++;
                    contou = false;
                }
                if (contagem + 1 <= textos.Length)
                {
                    Dialogo.SetActive(true);
                    interacao.SetActive(false);
                    texto.text = textos[contagem];

                }
                else
                {
                    Dialogo.SetActive(false);
                }






                if (contagem % 2 == 0)
                {
                    botao.image.sprite = personagem;
                    // imagem.sprite = personagem;
                }
                else
                {
                    botao.image.sprite = npc;
                    // imagem.sprite = npc;
                }

            }
        }
        else
        {
            botao.onClick.AddListener(delegate () { SumiuMami(); });
        }
     
        



    }

    public void InteragiuMami()
    {
        contou=true;
    }
    public void SumiuMami()
    {
        interacao.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      
            if (col.gameObject.CompareTag("Player"))

                interacao.SetActive(true);
            conversando = true;
            conversandoo = true;
            if (conversandoo == true)
            {
                numero += 1;
                conversandoo = false;
            }

        
        



    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (id != 8)
        {
            contagem = 0;
            interacao.SetActive(false);
            Dialogo.SetActive(false);
            conversando = false;
        }

        else
        {
            Dialogo.SetActive(false);

            interacao.SetActive(false);

        }
    }
}
