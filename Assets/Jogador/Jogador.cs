using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // Variaveis
    public float moveSpeed = 5f;
    private bool isFacingLeft = false; //verificar se o jogador esta virado para a esquerda

    // Instanciando referencia do sprite do jogador
    private SpriteRenderer spriteRenderer;
    // Instanciando referencia do animator do jogador
    private Animator animator;
    public Transform spritePlayer;

    void Start()
    {
        // Pegando de fato o sprite do jogador
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Pegando de fato o animator do jogador
        animator = spritePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        // input horizontal (esquerda: -1, direita: 1)
        float moveDirection = Input.GetAxisRaw("Horizontal");

        // input vertical (cima: -1, baixo: 1)
        float moveDirectionV = Input.GetAxisRaw("Vertical");

        //Se esta se movendo
        if(moveDirection != 0 || moveDirectionV != 0)
        {
            //Rodar animacao walking
            animator.SetBool("movendo", true);
        }
        else
        {
            //Voltar pro idle
            animator.SetBool("movendo", false);
        }

        // Mover o jogador 
        transform.Translate(new Vector2(moveDirection * moveSpeed * Time.deltaTime, moveDirectionV * moveSpeed * Time.deltaTime));

        // Verificar a direcao do movimento
        if (moveDirection < 0 && !isFacingLeft)
        {
            // Inverter o sprite quando o jogador ta virado para a esquerda
            spriteRenderer.flipX = true;
            isFacingLeft = true;
        }
        else if (moveDirection > 0 && isFacingLeft)
        {
            // Inverter o sprite quando o jogador ta virado para a direita
            spriteRenderer.flipX = false;
            isFacingLeft = false;
        }
    }
}
