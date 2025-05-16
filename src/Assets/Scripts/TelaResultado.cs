using UnityEngine;
using TMPro;

public class TelaResultado : MonoBehaviour
{
    public TextMeshProUGUI textoResultado;

    void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GM")?.GetComponent<GameManager>();
        if (gm == null)
        {
            textoResultado.text = "Erro: GameManager não encontrado.";
            return;
        }

        string resultado = $"🏁 RESULTADO FINAL 🏁\n\n" +
                           $"🧑 Player 1:\nEnergia: {gm.energia}\nEstrelas: {gm.estrelas}/5\n\n" +
                           $"🧑 Player 2:\nEnergia: {gm.energia2}\nEstrelas: {gm.estrelas2}/5";

        textoResultado.text = resultado;
    }
}