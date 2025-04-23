using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
   public void Jogar()
   {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
   }
}
