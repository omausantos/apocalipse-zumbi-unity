using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    private float velocidade = 5;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int selecionaTipoZumbi = Random.Range(1, 28);
        transform.GetChild(selecionaTipoZumbi).gameObject.SetActive(true);
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbodyJogador.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            rigidbodyJogador.MovePosition(
                rigidbodyJogador.position +
                    (direcao.normalized * velocidade * Time.deltaTime)
                );
            animatorJogador.SetBool("Atacando", false);
        }
        else
        {
            animatorJogador.SetBool("Atacando", true);
        }

    }

    void AtacaJogador()
    {
        int dano = Random.Range(20, 31);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }
}
