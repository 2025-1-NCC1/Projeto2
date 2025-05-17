using UnityEngine;
using UnityEngine.SceneManagement;  //  biblioteca UnityEngine.SceneManagement acessivel


public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo; // cria uma variavel e faz com que apareça no inspector
   public void Jogar()
   {
        SceneManager.LoadScene(nomeDoLevelDeJogo); // Carrega para a cena descrita no inspector

    }
}
