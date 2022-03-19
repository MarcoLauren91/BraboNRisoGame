using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BtnOpcaoDialogo : MonoBehaviour
{
    Resposta respostaJogador;
    NPC npc;
    public TextMeshProUGUI texto;

    public void CriaBotao(NPC _npc, Resposta _resposta)
    {
        npc = _npc;
        respostaJogador = _resposta;
        texto.text = respostaJogador.resposta;
    }

    public void Responder()
    {
        if (respostaJogador.respostaFinal)
        {
            npc.FinalizaDialogo (respostaJogador.concluiPuzzle);
        }
        else
        {
            npc.ExibeFalaNPC (respostaJogador.proximaFala);
        }
    }

}
