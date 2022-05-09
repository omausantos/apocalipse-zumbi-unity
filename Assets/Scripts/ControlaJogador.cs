using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel, ICuravel
{
    private Vector3 direcao;
    public LayerMask mascaraChao;
    public GameObject TextoGameOver;
    private AnimacaoPersonagem animatorJogador;
    public ControlaSlider ScriptControlaJogador;
    public AudioClip SomDeDano;
    private MovimentaJogador movimentaJogador;
    public Status StatusJogador;


    private void Start()
    {        
        animatorJogador = GetComponent<AnimacaoPersonagem>();
        movimentaJogador = GetComponent<MovimentaJogador>();
        StatusJogador = GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);
        animatorJogador.AnimarMovimento(direcao);
    }

    void FixedUpdate()
    {
        movimentaJogador.Movimenta(direcao, StatusJogador.velocidade);
        movimentaJogador.RotacionarJogador(mascaraChao);
    }

    public void TomarDano(int dano)
    {
        StatusJogador.Vida -= dano;
        ScriptControlaJogador.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDeDano);
        if (estaMorto())
        {
            Morte();
        }
    }

    bool estaMorto()
    {
        return StatusJogador.Vida <= 0 ? true : false;
    }

    public void Morte()
    {        
        ScriptControlaJogador.GameOver();
    }

    public void CurarVida(int quantidadeDeVida)
    {
        if(StatusJogador.Vida < StatusJogador.VidaInicial)
            StatusJogador.Vida += quantidadeDeVida;
            ScriptControlaJogador.AtualizarSliderVidaJogador();
    }
}
