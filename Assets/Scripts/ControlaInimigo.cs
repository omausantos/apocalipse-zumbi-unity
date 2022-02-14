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
        
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        if (distancia < 2.5) return;
        Vector3 direcao = Jogador.transform.position - transform.position;
        Rigidbody rigidbodi = GetComponent<Rigidbody>();
        rigidbodi.MovePosition(
            rigidbodi.position +
            (direcao.normalized * velocidade * Time.deltaTime)
            );

    }
}
