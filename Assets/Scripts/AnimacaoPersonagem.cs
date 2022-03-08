using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Atacar(bool estado)
    {
        myAnimator.SetBool("Atacando", estado);
    }

    public void AnimarMovimento(Vector3 direcao)
    {
        myAnimator.SetFloat("Movendo", direcao.magnitude);
    }

}
