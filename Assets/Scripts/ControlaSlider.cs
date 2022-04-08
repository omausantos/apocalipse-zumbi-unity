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
    public Text TextoTempoDeSobrevivencia;
    public Text TextoSeuMelhorTempo;
    private float melhorTempo;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scriptControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.StatusJogador.Vida;
        AtualizarSliderVidaJogador();
        melhorTempo = PlayerPrefs.GetFloat("MelhorTempo");
    }

    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptControlaJogador.StatusJogador.Vida;
    }

    public void GameOver()
    {
        PainelGameOver.SetActive(true);
        Time.timeScale = 0;
        float tempoAtual = Time.timeSinceLevelLoad;
        int minutos = (int)(tempoAtual / 60);
        int segundos = (int)(tempoAtual % 60);
        TextoTempoDeSobrevivencia.text = "Voce sobreviveu por " + minutos + "min e " + segundos + "s";
        ModalTextoMelhorTexto(tempoAtual);
    }

    private void ModalTextoMelhorTexto(float tempoAtual)
    {
        melhorTempo = tempoAtual > melhorTempo ? tempoAtual : melhorTempo;
        PlayerPrefs.SetFloat("MelhorTempo", melhorTempo);
        int minutos = (int)(melhorTempo / 60);
        int segundos = (int)(melhorTempo % 60);
        TextoSeuMelhorTempo.text = "Voce sobreviveu por " + minutos + "min e " + segundos + "s";
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("game");
        PainelGameOver.SetActive(false);
    }
}
