using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    private float velocidade = 5;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int selecionaTipoZumbi = Random.Range(1, 28);
        transform.GetChild(selecionaTipoZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Rigidbody rigidbodi = GetComponent<Rigidbody>();
        Animator animacao = GetComponent<Animator>();
        Vector3 direcao = Jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbodi.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            rigidbodi.MovePosition(
                rigidbodi.position +
                    (direcao.normalized * velocidade * Time.deltaTime)
                );
            animacao.SetBool("Atacando", false);
        }
        else
        {
            animacao.SetBool("Atacando", true);
        }

    }

    void AtacaJogador()
    {
        ControlaJogador controlador = Jogador.GetComponent<ControlaJogador>();
        Time.timeScale = 0;
        controlador.TextoGameOver.SetActive(true);
        controlador.Vivo = false;
    }
}
