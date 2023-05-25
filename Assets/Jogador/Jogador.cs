using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // Variáveis de movimento
    public float moveSpeed = 5f;
    private bool isFacingLeft = false; // Flag para verificar se o jogador está virado para a esquerda

    // Referência para o sprite do jogador
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Obtenha a referência para o SpriteRenderer do jogador
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Obter entrada horizontal (esquerda: -1, direita: 1)
        float moveDirection = Input.GetAxisRaw("Horizontal");

        // Obter entrada vertical (cima: -1, baixo: 1)
        float moveDirectionV = Input.GetAxisRaw("Vertical");

        // Mover o jogador na horizonatal
        transform.Translate(new Vector2(moveDirection * moveSpeed * Time.deltaTime, moveDirectionV * moveSpeed * Time.deltaTime));

        // Verificar a direção do movimento
        if (moveDirection < 0 && !isFacingLeft)
        {
            // Inverter o sprite quando o jogador está virado para a esquerda
            spriteRenderer.flipX = true;
            isFacingLeft = true;
        }
        else if (moveDirection > 0 && isFacingLeft)
        {
            // Inverter o sprite quando o jogador está virado para a direita
            spriteRenderer.flipX = false;
            isFacingLeft = false;
        }
    }
}
