using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaPersonagem : MonoBehaviour
{
    private Rigidbody myRigibody;

    private void Awake() {
        myRigibody = GetComponent<Rigidbody>();
    }
    public void Movimenta(Vector3 direcao, float velocidade){
        myRigibody.MovePosition(
                myRigibody.position +
                    (direcao.normalized * velocidade * Time.deltaTime)
                );
    }

    public void Rotacionar(Vector3 direcao){
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        myRigibody.MoveRotation(novaRotacao);
    }
}
