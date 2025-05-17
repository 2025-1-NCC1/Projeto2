using UnityEngine;
using UnityEngine.SceneManagement;

public class Casa : MonoBehaviour
{
    private GameManager gm; //referencencia ao gm q controla o jogo

    void Start()
    {
        GameObject gmObj = GameObject.FindGameObjectWithTag("GM"); //encontra o objeto com a tag GM 
        if (gmObj != null) 
        {
            gm = gmObj.GetComponent<GameManager>(); // ao econtrar obtém o componente GameManager
        }
        else
        {
            Debug.LogError("GameManager com tag 'GM' não encontrado na cena!"); // se nao encontrar mostra no console que não encontrou
        }
    }

    private void OnMouseDown() // método chamado ao clicar com o mouse
    {
        if (gm == null) //verificação extra no mommento do clique para vereficar o GM
        {
            Debug.LogError("GameManager não está atribuído.");
            return;
        }

        if (gm.JogoAcabou()) // verifica se o jogo acabou
        {
            Debug.Log("O jogo acabou!");
            return;
        }

        // caso nao tenha acabado, vai para a tela escolhas
        SceneManager.LoadScene("TelaEscolhas");
    }
}