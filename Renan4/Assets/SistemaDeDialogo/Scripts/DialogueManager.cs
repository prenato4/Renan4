using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public EfeitoDigitador caixaDeDialogo;
    public GameObject botaoContinuar;
    public bool rodando, proximo;

    public Dialogo1 diaalogo;

    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(ExibirSequencia(lista1));
    }

    public void Playdialogo(Dialogo1 dialogo)
    {
        StartCoroutine(ExibirSequencia(dialogo.Lista));
    }

    IEnumerator ExibirSequencia(List<string> lista)
    {
        if (rodando) yield break;
        rodando = true;
        proximo = false;
        botaoContinuar.SetActive(false);

        foreach (var mensagem in lista)
        {
            caixaDeDialogo.ImprimirMensagem(mensagem);
            while (caixaDeDialogo.imprimindo)
            {
                yield return new WaitForEndOfFrame();
            }
            botaoContinuar.SetActive(true);
            while (!proximo)
            {
                yield return new WaitForEndOfFrame();
            }
            botaoContinuar.SetActive(false);
            proximo = false;
        }
        caixaDeDialogo.Limpar();
        rodando = false;
        StopCoroutine(ExibirSequencia(lista));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ExibirSequencia(diaalogo.Lista));
        }
        
        
        if (!caixaDeDialogo.imprimindo)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                proximo = true;
            }
        }
    }
}
