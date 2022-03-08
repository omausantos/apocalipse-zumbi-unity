using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour, IMatavel
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
        Time.timeScale = 1;
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

        if (estaMorto())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
                TextoGameOver.SetActive(false);
            }
        }
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
        Time.timeScale = 0;
        TextoGameOver.SetActive(true);
    }
}
