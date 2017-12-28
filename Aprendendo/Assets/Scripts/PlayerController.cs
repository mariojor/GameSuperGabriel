using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed; //Velocidade
    public float jumpForce; //Força do pulo publicas para poder editar no editor

    private Rigidbody2D rb; // Serve para manipular o rigidbody do player
    private bool facingRight = true; // Indica se o personagem está para esquerda ou para direita
    private bool jump = false; 
    private Animator anim; // Manipular a animação
    private bool noChao = false; // para verificar se o persogem está parado no chao só assim pode pular
    private Transform groundCheck; // 

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
	}

	
	// É atualizado a cada frame de jogo
	void Update ()
    {
        // Verifica a posição do groundCheck se groundCheck estiver em um objeto que a layer seja chamada ground no chao será igual true
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); 

        if (Input.GetButtonDown("Jump") && noChao)
        {
            jump = true;
            anim.SetTrigger("Pulou");// Ativar a animação

        }
	}

    // É baseado na fisica do jogo , toda movimentação é criada aqui
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");// Setas do teclado da esquerda ou da direita ou o "A" e o "D" valores 1 e -1 para velocidade constate. sem o raw a velocidade não é constante
        anim.SetFloat("Velocidade", Mathf.Abs(h)); //Mathf.abs muda os valores negativos para positivo

        rb.velocity = new Vector2(h * speed, rb.velocity.y);// pode ser usado o adforce para não ficar com uma velocidade constate

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if(h< 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }

    // Fução para virar da esquerda para direita e vice versa
    /*
     Inverte o valor de faceright
     theScale pela os valores da scale

         */
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
