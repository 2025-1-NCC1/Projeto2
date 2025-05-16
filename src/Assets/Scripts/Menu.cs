using UnityEngine;
using UnityEngine.SceneManagement;  //  biblioteca UnityEngine.SceneManagement acessível


public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo; // cria uma variável e faz com que apareça no inspector
   public void Jogar()
   {
        SceneManager.LoadScene(nomeDoLevelDeJogo); // Carrega para a cena descrita no inspector

    }
}
