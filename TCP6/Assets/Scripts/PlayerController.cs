using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public float speed;
    public float horizontal;
    public float vertical;
    public int jogador;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0;
        vertical = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador == 2)
        {
            float moverX = Input.GetAxis("Horizontal");
            float moverY = Input.GetAxis("Vertical");

            Vector3 direcaoMovimento = new Vector3(moverX, moverY,0);
            transform.Translate(direcaoMovimento * speed * Time.deltaTime);
        }
        if (jogador == 1)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            Vector3 movimentar = new Vector3(horizontal, vertical, 0f);

            animator.SetFloat("Horizontal", movimentar.x);
            animator.SetFloat("Vertical", movimentar.y);
            animator.SetFloat("Speed", 5);

            transform.position = transform.position + movimentar * speed * Time.deltaTime;
        }
        

    }

    public void andandoDireita()
    {
        horizontal = 1;
    }

    public void andandoEsquerda()
    {
        horizontal = -1;
    }

    public void andarCima()
    {
        vertical = 1;

    }

    public void andarBaixo()
    {
        vertical = -1;
    }
    public void pararAndar()
    {
        horizontal = 0;

    }
    public void pararAndarV()
    {
        vertical = 0;
    }
}
