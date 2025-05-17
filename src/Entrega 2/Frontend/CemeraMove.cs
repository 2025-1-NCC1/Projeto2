using UnityEngine;

public class CemeraMove : MonoBehaviour
{
    public float sensibilidade = 2.0f; //sensibilidade mouse
   
   private float mouseX = 0.0f, mouseY = 0.0f; // declara varoáveis e mantém ao iniciar o jogo a câmera sem nenhuma rotação 
   
    
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;  // Atualiza a rotação horizontal acumulada com base no movimento do mouse no eixo X
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade; // Atualiza a rotação vertical acumulada com base no movimento do mouse no eixo Y (invertido para simular visão natural)


        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        // Aplica a rotação a câmera (transform) com base nos valores acumulados

    }
}




