using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour
{
    private int quantidadeDeVida = 15;
    private int tempoDeDestruicao = 5;

    private void Start() {
        Destroy(gameObject, tempoDeDestruicao);
    }
    private void OnTriggerEnter(Collider objetoDeColisao) {
        if(objetoDeColisao.tag == "Jogador") {
            Destroy(gameObject);
            objetoDeColisao.GetComponent<ControlaJogador>().CurarVida(quantidadeDeVida);
        }
    }
}
