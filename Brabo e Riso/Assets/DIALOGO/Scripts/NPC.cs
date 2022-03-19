using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject telaJogador, telaNPC;
    public TextMeshProUGUI textoJogador, textoNPC;
    public Transform localRespostas;

    public List<BtnOpcaoDialogo> respostas = new List<BtnOpcaoDialogo> ();

    public GameObject respostaPrefab;

    FalaNPC falaNPC;

    public FalaNPC falaInicial;
    public FalaNPC falaFinal;

    private bool dialogoConcluido = false;

    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            InicializaDialogo ();
    }

    void InicializaDialogo()
    {
        if (!dialogoConcluido)
        {
            ExibeFalaNPC (falaInicial);
        }
        else
        {
            ExibeFalaNPC (falaFinal);
        }
    }


    public void ExibeFalaNPC(FalaNPC _fala)
    {
        LimparRespostas ();

        falaNPC = _fala;
        textoNPC.text = falaNPC.fala;
        telaNPC.SetActive (true);


        if (falaNPC.respostas.Length > 0)
        {
            ExibeRespostas ();
        }
        else
        {
            //Finaliza dialogo
        }

    }

    void ExibeRespostas()
    {
        //Cria todas as respostas
        foreach (var _resposta in falaNPC.respostas)
        {
            BtnOpcaoDialogo _botao = Instantiate (respostaPrefab, localRespostas).GetComponent<BtnOpcaoDialogo> ();
            _botao.CriaBotao (this, _resposta); 
            respostas.Add (_botao);
        }
    }

    void LimparRespostas()
    {
        if (respostas.Count == 0) return;

        for (int i = 0; i < respostas.Count; i++)
        {
            Destroy (respostas[i].gameObject);
        }

        respostas.Clear ();
    }

    public void FinalizaDialogo(bool _concluiDialogo)
    {
        LimparRespostas ();
        telaJogador.SetActive (false);
        telaNPC.SetActive (false);

        if(_concluiDialogo) dialogoConcluido = true;
        

    }
}
