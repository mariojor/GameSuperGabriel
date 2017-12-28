using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    Animator anim;

    public float intervaloDeAtque;
    private float proximoAtaque;


	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque)// Pega o tempo do incio do game e verifica se o tempo de inicio é maior que proximo ataque que no inicio é zero.
        {
            Atacando();
        }
	}

    void Atacando()
    {
        anim.SetTrigger("Ataque"); // Mudar animação para ataque
        proximoAtaque = Time.time + intervaloDeAtque; // proximo ataque vai receber o tempo atual de game + o tempo que foi ativado o ataque
    }

}
