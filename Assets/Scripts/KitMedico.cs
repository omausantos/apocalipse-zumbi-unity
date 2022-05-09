using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour
{
    private int quantidadeDeVida = 15;
    private void OnTriggerEnter(Collider objetoDeColisao) {
        if(objetoDeColisao.tag == "Jogador") {
            Destroy(gameObject);
            objetoDeColisao.GetComponent<ControlaJogador>().CurarVida(quantidadeDeVida);
        }
    }
}
