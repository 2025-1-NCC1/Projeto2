using UnityEngine;
using TMPro;

public class TelaResultado : MonoBehaviour
{
    public TextMeshProUGUI textoResultado; // Referência ao componente de texto que mostrará o resultado final


    void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GM")?.GetComponent<GameManager>();
        if (gm == null) // verifica se encontrou corretamente o gamanager
        {
            textoResultado.text = "Erro: GameManager não encontrado."; //texto mostrado no console se não encontra o GM
            return;
        }

        string resultado = $"  RESULTADO FINAL\n" +  // Sem \n\n aqui
                   $"- Player 1:\nEnergia: {gm.energia}\nEstrelas: {gm.estrelas}/5\n" + // Apenas \n
                   $"- Player 2:\nEnergia: {gm.energia2}\nEstrelas: {gm.estrelas2}/5";  // Apenas \n

        textoResultado.text = resultado; //atribui o texto ao UI do unity
    }
}