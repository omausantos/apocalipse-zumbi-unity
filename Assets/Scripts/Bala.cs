using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade = 20;

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rigidbodi = GetComponent<Rigidbody>();
        rigidbodi.MovePosition(
            rigidbodi.position +
            transform.forward *
            velocidade *
            Time.deltaTime
            );

    }
}
