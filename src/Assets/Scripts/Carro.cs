using UnityEngine;

public class CarroMover : MonoBehaviour
{
    public float velocidade = 5f; //velocidade do carro

    private float tempoDecorrido = 0f; // Tempo que passou desde a �ltima mudan�a de estado
    private enum Estado { Indo, Espera1, Voltando, Espera2 } // Enumera��o que define os estados poss�veis do carro: indo, esperando, voltando, esperando

    private Estado estadoAtual = Estado.Indo; // Estado atual do carro, iniciando com "Indo"


    void Update()
    {

        tempoDecorrido += Time.deltaTime;

        // Verifica o estado atual do carro e executa o comportamento correspondente

        switch (estadoAtual)
        {

            case Estado.Indo:
                if (tempoDecorrido < 6f) // Enquanto o tempo for menor que 6 segundos, o carro anda para frente

                {
                    transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
                }
                else
                {
                    estadoAtual = Estado.Espera1; // Quando chegar a 6 segundos, muda para o estado de espera e reseta o tempo

                    tempoDecorrido = 0f;
                }
                break;

            case Estado.Espera1:
                // Ap�s esperar 6 segundos parado, gira o carro 180 graus e muda para o estado de "Voltando"

                if (tempoDecorrido >= 6f)
                {
                    transform.Rotate(0f, 180f, 0f);
                    estadoAtual = Estado.Voltando;
                    tempoDecorrido = 0f;
                }
                break;

            case Estado.Voltando:
                // Carro anda para frente novamente (que agora � "para tr�s" por causa da rota��o)

                if (tempoDecorrido < 6f)
                {
                    transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
                }
                else
                {
                    estadoAtual = Estado.Espera2;
                    tempoDecorrido = 0f;
                }
                break;

            case Estado.Espera2:
                // Ap�s 6 segundos voltando, entra no segundo estado de espera

                if (tempoDecorrido >= 10f)
                {
                    // Reinicia o ciclo: gira novamente e volta ao in�cio
                    transform.Rotate(0f, 180f, 0f);
                    estadoAtual = Estado.Indo;
                    tempoDecorrido = 0f;
                }
                break;
        }
    }
}
