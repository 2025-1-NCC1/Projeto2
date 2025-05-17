using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EscolhasUI_Teclado : MonoBehaviour
{
    [System.Serializable]
    public class Acao
    {                    // Custo de energia e estrela e o nome do período
        public string descricao;  
        public int custoEnergia;  
        public int custoEstrelas; 
    }

    [System.Serializable] 
    public class Periodo  // Cadastro do nome dos períodos e das ações
    {
        public string nomePeriodo; 
        public Acao acao1;
        public Acao acao2;
        
    }

    // Bloco responsável pelos períodos, criar lista com todos os períodos e os dias
    public List<Periodo> todosOsPeriodos; 
    private List<Periodo> periodosDoDia;  

    public TextMeshProUGUI textoUI; // Texto de interface para exibir opções e status

    private GameManager GM;     // Energia e estrela atual do player
    private int energiaTotal; 
    private int estrelas; 

    private int periodoAtual = 0; // qual o período atual
    private bool esperandoEscolha = true;

    void Start()
    {   // Pega o GameManager pela tag
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
    {   // aguarda o período e executa a ação de se o player a apertar 1 executa uma ação se aperta 2 executa outra
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

    void AplicarAcao(Acao acao)   //Diminuiu a energia e ajusta a estrela e garante q fique apenas 5 opções no dia
    {
        energiaTotal -= acao.custoEnergia;
        estrelas += acao.custoEstrelas;
        estrelas = Mathf.Clamp(estrelas, 0, 5);

        Debug.Log($"Escolheu: {acao.descricao}");
        Debug.Log($"Energia: {energiaTotal}, Estrelas: {estrelas}");

        esperandoEscolha = false;

        if (estrelas < 3) // se estrela for menor que 3, acaba o jogo e tempo de transição
        {
            textoUI.text = "Você perdeu! Estrelas abaixo de 3.";
            Invoke(nameof(FinalizarDia), 2f);
            return;
        }

        Invoke(nameof(ProximoPeriodo), 0.5f);
    }

    void MostrarPeriodoAtual()   // Avança um dia 
    {
        if (periodoAtual >= periodosDoDia.Count)
        {
            textoUI.text = "Dia finalizado! Voltando...";
            Invoke(nameof(FinalizarDia), 2f);
            return;
        }

        esperandoEscolha = true;

        var p = periodosDoDia[periodoAtual]; // Monta o texto com nome do período e as duas opções de ação


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
        MostrarPeriodoAtual(); // prócimo período
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

    List<Periodo> SortearPeriodos(List<Periodo> listaOriginal, int quantidade)  // sorteia as ações para aparecer de forma aleatória
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
