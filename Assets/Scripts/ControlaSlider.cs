using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaSlider : MonoBehaviour
{
    private ControlaJogador scriptControlaJogador;
    public Slider SliderVidaJogador;
    public GameObject PainelGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scriptControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.StatusJogador.Vida;
        AtualizarSliderVidaJogador();
    }

    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptControlaJogador.StatusJogador.Vida;
    }

    public void GameOver()
    {
        PainelGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("game");
        PainelGameOver.SetActive(false);
    }
}
