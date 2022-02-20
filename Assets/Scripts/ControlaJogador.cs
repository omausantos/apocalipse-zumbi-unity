using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float velocidade = 10;
    private Vector3 direcao;
    public LayerMask mascaraChao;
    public GameObject TextoGameOver;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;
    public int Vida = 100;
    public ControlaSlider ScriptControlaJogador;


    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        animatorJogador.SetBool("Movendo", (direcao != Vector3.zero));

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
        rigidbodyJogador.MovePosition(
            rigidbodyJogador.position +
            (direcao * velocidade * Time.deltaTime)
            );

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if(Physics.Raycast(raio, out impacto, 100, mascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbodyJogador.MoveRotation(novaRotacao);
        }
        
    }

    public void TomarDano(int dano)
    {
        Vida -= dano;
        ScriptControlaJogador.AtualizarSliderVidaJogador();
        if(estaMorto())
        {
            Time.timeScale = 0;
            TextoGameOver.SetActive(true);            
        }
    }

    bool estaMorto()
    {
        return Vida <= 0 ? true : false;
    }
}
