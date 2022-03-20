using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IMatavel
{

    public GameObject Jogador;
    private MovimentaPersonagem movimenta;
    private AnimacaoPersonagem animacao;
    private Status statusInimigo;
    public AudioClip SomDeMorte;
    private float contadorVagar;
    public float tempoEntrePosicoesAleatorias;
    private Vector3 direcaoAleatoria;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        RandomZumbi();
        movimenta = GetComponent<MovimentaPersonagem>();
        animacao = GetComponent<AnimacaoPersonagem>();
        statusInimigo = GetComponent<Status>();
    }

    void FixedUpdate()
    {

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        if (distancia > 15)
        {
            Vagar();
        }
        else if (distancia > 2.5)
        {
            DirecaoInimigo(Jogador.transform.position);
        }
        else
        {
            animacao.Atacar(true);
        }

    }

    void DirecaoInimigo(Vector3 destino)
    {
        Vector3 direcao = destino - transform.position;
        animacao.AnimarMovimento(direcao);
        movimenta.Rotacionar(direcao);
        movimenta.Movimenta(direcao, statusInimigo.velocidade);
        animacao.Atacar(false);
    }

    Vector3 DirecaoAleatoria()
    {
        Vector3 posicao = Random.insideUnitSphere * 10;
        posicao += transform.position;
        posicao.y = transform.position.y;
        return posicao;
    }

    void Vagar()
    {
        contadorVagar -= Time.deltaTime;
        if (contadorVagar <= 0)
        {
            direcaoAleatoria = DirecaoAleatoria();
            contadorVagar += tempoEntrePosicoesAleatorias;
        }

        if (Vector3.Distance(transform.position, direcaoAleatoria) > 0.05)
        {
            DirecaoInimigo(direcaoAleatoria);
        }
    }


    void AtacaJogador()
    {
        int dano = Random.Range(20, 31);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }

    private void RandomZumbi()
    {
        int selecionaTipoZumbi = Random.Range(1, 28);
        transform.GetChild(selecionaTipoZumbi).gameObject.SetActive(true);
    }

    public void TomarDano(int dano)
    {
        statusInimigo.Vida -= dano;
        if (statusInimigo.Vida <= 0)
        {
            Morte();
        }
    }

    public void Morte()
    {
        Destroy(gameObject);
        ControlaAudio.instancia.PlayOneShot(SomDeMorte);
    }
}
