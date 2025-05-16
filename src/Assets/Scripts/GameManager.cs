using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int qualPlayer = 1;
    public int energia = 500;
    public int estrelas = 5;

    public int energia2 = 500;
    public int estrelas2 = 5;

    public int diaAtual = 1;
    public int maxDias = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ModificarEnergia(int novaEnergia)
    {
        if (qualPlayer == 1)
        {
            energia = Mathf.Clamp(novaEnergia, 0, 500);
            Debug.Log("Energia Player 1 atualizada para: " + energia);
        }
        else
        {
            energia2 = Mathf.Clamp(novaEnergia, 0, 500);
            Debug.Log("Energia Player 2 atualizada para: " + energia2);
        }
    }

    public void ModificarEstrelas(int novaEstrela)
    {
        if (qualPlayer == 1)
        {
            estrelas = Mathf.Clamp(novaEstrela, 0, 5);
            Debug.Log("Estrelas Player 1 atualizadas para: " + estrelas);
        }
        else
        {
            estrelas2 = Mathf.Clamp(novaEstrela, 0, 5);
            Debug.Log("Estrelas Player 2 atualizadas para: " + estrelas2);
        }
    }

    public void TrocaPlayer()
    {
        if (qualPlayer == 1)
        {
            qualPlayer = 2;
        }
        else
        {
            qualPlayer = 1;
            diaAtual++;
        }

        Debug.Log("Trocando para jogador: " + qualPlayer);
    }

    public bool JogoAcabou()
    {
        return diaAtual > maxDias || estrelas < 3 || estrelas2 < 3;
    }
}