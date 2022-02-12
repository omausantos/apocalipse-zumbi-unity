using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10;
    Vector3 direcao;

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        GetComponent<Animator>().SetBool("Movendo", (direcao != Vector3.zero));
    }

    void FixedUpdate()
    {
        Rigidbody rigidbodi = GetComponent<Rigidbody>();
        rigidbodi.MovePosition(
            rigidbodi.position +
            (direcao * Velocidade * Time.deltaTime)
            );
    }
}
