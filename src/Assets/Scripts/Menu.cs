using UnityEngine;
using UnityEngine.SceneManagement;  //  biblioteca UnityEngine.SceneManagement acess�vel


public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo; // cria uma vari�vel e faz com que apare�a no inspector
   public void Jogar()
   {
        SceneManager.LoadScene(nomeDoLevelDeJogo); // Carrega para a cena descrita no inspector

    }
}
