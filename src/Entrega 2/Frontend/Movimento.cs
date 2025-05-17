using UnityEngine;

public class Movimento : MonoBehaviour
{
    public Transform cameraTransform; // Se não for atribuído, vamos pegar a Main Camera automaticamente

    private Vector3 entradasJogador; // Armazena a direção do movimento das teclas WASD
    private CharacterController characterController; //movimentação física do jogador 
    private float velocidadeJogador = 4f; // velocidade de movimento 

    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); // Pega a referência para o componente CharacterController anexado ao GameObject


        // Se não foi atribuído no Inspector, tenta pegar automaticamente
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {  // Captura os inputs de movimentação (WASD / setas) nos eixos horizontal (A/D ou ←/→) e vertical (W/S ou ↑/↓)

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Pega os vetores de direção da câmera

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ignora a rotação vertical da câmera (evita que o jogador ande pra cima ou pra baixo)

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Combina os inputs com os vetores da câmera para mover o jogador na direção correta

        entradasJogador = forward * vertical + right * horizontal;

        // Move o personagem usando o CharacterController, levando em conta o tempo entre os frames

        characterController.Move(entradasJogador * Time.deltaTime * velocidadeJogador);
    }
}
