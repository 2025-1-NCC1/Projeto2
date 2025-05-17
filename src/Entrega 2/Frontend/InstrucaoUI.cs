using UnityEngine;
using TMPro;

public class InstrucaoUI : MonoBehaviour
{
    public TextMeshProUGUI textoInstrucao;

    void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GM")?.GetComponent<GameManager>(); //  Usa o operador de coalescência nula (?) para evitar erro se não encontrar o objeto com a tag "GM"


        if (gm != null && textoInstrucao != null)  // Se o GameManager foi encontrado e o campo de texto também foi atribuído corretamente
                                                    // define o texto da instrução com base no jogador atual
        {
            textoInstrucao.text = $"Player {gm.qualPlayer}, selecione uma casa e se mantenha acima de 3 estrelas."; // texto aparece variando de player pra player 
        }
    }
}
