using UnityEngine;

public class Movimento : MonoBehaviour
{
    public Transform cameraTransform; // Se não for atribuído, vamos pegar a Main Camera automaticamente

    private Vector3 entradasJogador;
    private CharacterController characterController;
    private float velocidadeJogador = 4f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        // Se não foi atribuído no Inspector, tenta pegar automaticamente
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        entradasJogador = forward * vertical + right * horizontal;

        characterController.Move(entradasJogador * Time.deltaTime * velocidadeJogador);
    }
}
