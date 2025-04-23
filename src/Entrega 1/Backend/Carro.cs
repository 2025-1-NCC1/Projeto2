using UnityEngine;

public class CarroMover : MonoBehaviour
{
    public float velocidade = 5f;

    private float tempoDecorrido = 0f;
    private enum Estado { Indo, Espera1, Voltando, Espera2 }
    private Estado estadoAtual = Estado.Indo;

    void Update()
    {
        tempoDecorrido += Time.deltaTime;

        switch (estadoAtual)
        {
            case Estado.Indo:
                if (tempoDecorrido < 6f)
                {
                    transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
                }
                else
                {
                    estadoAtual = Estado.Espera1;
                    tempoDecorrido = 0f;
                }
                break;

            case Estado.Espera1:
                if (tempoDecorrido >= 6f)
                {
                    transform.Rotate(0f, 180f, 0f);
                    estadoAtual = Estado.Voltando;
                    tempoDecorrido = 0f;
                }
                break;

            case Estado.Voltando:
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
                if (tempoDecorrido >= 10f)
                {
                    // Reinicia o ciclo: gira novamente e volta ao início
                    transform.Rotate(0f, 180f, 0f);
                    estadoAtual = Estado.Indo;
                    tempoDecorrido = 0f;
                }
                break;
        }
    }
}
