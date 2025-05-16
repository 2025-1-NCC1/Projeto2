using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EscolhasUI_Teclado : MonoBehaviour
{
    [System.Serializable]
    public class Acao
    {
        public string descricao;
        public int custoEnergia;
        public int custoEstrelas;
    }

    [System.Serializable]
    public class Periodo
    {
        public string nomePeriodo;
        public Acao acao1;
        public Acao acao2;
    }

    public List<Periodo> todosOsPeriodos; // Todos os períodos cadastrados
    private List<Periodo> periodosDoDia;  // Os 5 sorteados para o dia

    public TextMeshProUGUI textoUI;

    private GameManager GM;
    private int energiaTotal;
    private int estrelas;

    private int periodoAtual = 0;
    private bool esperandoEscolha = true;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM")?.GetComponent<GameManager>();

        if (GM == null)
        {
            Debug.LogError("GameManager não encontrado!");
            return;
        }

        // Carrega dados do jogador atual
        if (GM.qualPlayer == 1)
        {
            energiaTotal = GM.energia;
            estrelas = GM.estrelas;
        }
        else
        {
            energiaTotal = GM.energia2;
            estrelas = GM.estrelas2;
        }

        // Sorteia 5 períodos únicos para o dia
        periodosDoDia = SortearPeriodos(todosOsPeriodos, 5);

        MostrarPeriodoAtual();
    }

    void Update()
    {
        if (!esperandoEscolha || periodoAtual >= periodosDoDia.Count)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AplicarAcao(periodosDoDia[periodoAtual].acao1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AplicarAcao(periodosDoDia[periodoAtual].acao2);
        }
    }

    void AplicarAcao(Acao acao)
    {
        energiaTotal -= acao.custoEnergia;
        estrelas += acao.custoEstrelas;
        estrelas = Mathf.Clamp(estrelas, 0, 5);

        Debug.Log($"Escolheu: {acao.descricao}");
        Debug.Log($"Energia: {energiaTotal}, Estrelas: {estrelas}");

        esperandoEscolha = false;

        if (estrelas < 3)
        {
            textoUI.text = "Você perdeu! Estrelas abaixo de 3.";
            Invoke(nameof(FinalizarDia), 2f);
            return;
        }

        Invoke(nameof(ProximoPeriodo), 0.5f);
    }

    void MostrarPeriodoAtual()
    {
        if (periodoAtual >= periodosDoDia.Count)
        {
            textoUI.text = "Dia finalizado! Voltando...";
            Invoke(nameof(FinalizarDia), 2f);
            return;
        }

        esperandoEscolha = true;

        var p = periodosDoDia[periodoAtual];

        string texto = $"--- {p.nomePeriodo.ToUpper()} ---\n";
        texto += $"1 - {p.acao1.descricao} (Energia: -{p.acao1.custoEnergia}, Estrelas: {p.acao1.custoEstrelas:+#;-#;0})\n";
        texto += $"2 - {p.acao2.descricao} (Energia: -{p.acao2.custoEnergia}, Estrelas: {p.acao2.custoEstrelas:+#;-#;0})\n";
        texto += $"\nEnergia: {energiaTotal} | Estrelas: {estrelas}/5";
        texto += "\n\nPressione 1 ou 2 para escolher.";
        textoUI.text = texto;
    }

    void ProximoPeriodo()
    {
        periodoAtual++;
        MostrarPeriodoAtual();
    }

    void FinalizarDia()
    {
        if (GM == null) return;

        // Atualiza os dados do jogador atual no GameManager
        GM.ModificarEnergia(energiaTotal);
        GM.ModificarEstrelas(estrelas);

        // Troca de jogador (e avança o dia se necessário)
        GM.TrocaPlayer();

        // Verifica se o jogo terminou
        if (GM.JogoAcabou())
        {
            SceneManager.LoadScene("TelaResultado"); // Ir para a tela de resultados
        }
        else
        {
            SceneManager.LoadScene("Jogo"); // Continua o ciclo normalmente
        }
    }

    List<Periodo> SortearPeriodos(List<Periodo> listaOriginal, int quantidade)
    {
        List<Periodo> copia = new List<Periodo>(listaOriginal);
        List<Periodo> sorteados = new List<Periodo>();

        for (int i = 0; i < quantidade && copia.Count > 0; i++)
        {
            int index = Random.Range(0, copia.Count);
            sorteados.Add(copia[index]);
            copia.RemoveAt(index);
        }

        return sorteados;
    }
}
