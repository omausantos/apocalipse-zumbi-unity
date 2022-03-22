using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    float ContadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZumbi;

    // Update is called once per frame
    void Update()
    {
        ContadorTempo += Time.deltaTime;
        if (ContadorTempo >= TempoGerarZumbi)
        {
            GerarZumbi();
            ContadorTempo = 0;
        }
    }

    void GerarZumbi()
    {
        Vector3 posicaoCriarZumbi = PosicaoAleatoria();
        Collider[] colisores = Physics.OverlapSphere(posicaoCriarZumbi, 1, LayerZumbi);
        if(colisores.Length > 0)
        {
            posicaoCriarZumbi = PosicaoAleatoria();
            colisores = Physics.OverlapSphere(posicaoCriarZumbi, 1, LayerZumbi);
        }
        Instantiate(Zumbi, posicaoCriarZumbi, transform.rotation);
    }

    Vector3 PosicaoAleatoria()
    {
        Vector3 posicao = Random.insideUnitSphere * 3;
        posicao += transform.position;
        posicao.y = transform.position.y;
        return posicao;
    }
}
