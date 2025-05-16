using UnityEngine;
using UnityEngine.SceneManagement;

public class Casa : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        GameObject gmObj = GameObject.FindGameObjectWithTag("GM");
        if (gmObj != null)
        {
            gm = gmObj.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager com tag 'GM' não encontrado na cena!");
        }
    }

    private void OnMouseDown()
    {
        if (gm == null)
        {
            Debug.LogError("GameManager não está atribuído.");
            return;
        }

        if (gm.JogoAcabou())
        {
            Debug.Log("O jogo acabou!");
            return;
        }

        // Vai para a tela de escolhas
        SceneManager.LoadScene("TelaEscolhas");
    }
}