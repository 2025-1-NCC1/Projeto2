using UnityEngine;
using TMPro;

public class InstrucaoUI : MonoBehaviour
{
    public TextMeshProUGUI textoInstrucao;

    void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GM")?.GetComponent<GameManager>();

        if (gm != null && textoInstrucao != null)
        {
            textoInstrucao.text = $"Player {gm.qualPlayer} selecione uma casa e se mantenha acima de 3 estrelas!";
        }
    }
}
