using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    float ContadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZumbi;
    private float raioCirculo = 3;
    private GameObject jogador;
    private float distanciaDoJogador = 20;



    private void Start()
    {
        jogador = GameObject.FindWithTag("Jogador");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) > distanciaDoJogador)
        {
            ContadorTempo += Time.deltaTime;
            if (ContadorTempo >= TempoGerarZumbi)
            {
                StartCoroutine(GerarZumbi());
                ContadorTempo = 0;
            }
        }
    }

    IEnumerator GerarZumbi()
    {
        Vector3 posicaoCriarZumbi = PosicaoAleatoria();
        Collider[] colisores = Physics.OverlapSphere(posicaoCriarZumbi, 1, LayerZumbi);
        while (colisores.Length > 0)
        {
            posicaoCriarZumbi = PosicaoAleatoria();
            colisores = Physics.OverlapSphere(posicaoCriarZumbi, 1, LayerZumbi);
            yield return null;
        }
        Instantiate(Zumbi, posicaoCriarZumbi, transform.rotation);
    }

    Vector3 PosicaoAleatoria()
    {
        Vector3 posicao = Random.insideUnitSphere * raioCirculo;
        posicao += transform.position;
        posicao.y = transform.position.y;
        return posicao;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, raioCirculo);
    }
}
