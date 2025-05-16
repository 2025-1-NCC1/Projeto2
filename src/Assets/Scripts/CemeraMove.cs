using UnityEngine;

public class CemeraMove : MonoBehaviour
{
    public float sensibilidade = 2.0f; //sensibilidade mouse
   
   private float mouseX = 0.0f, mouseY = 0.0f; // declara vari�veis e mant�m ao iniciar o jogo a c�mera sem nenhuma rota��o
   
    
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;  // Atualiza a rota��o horizontal acumulada com base no movimento do mouse no eixo X
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade; // Atualiza a rota��o vertical acumulada com base no movimento do mouse no eixo Y (invertido para simular vis�o natural)


        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        // Aplica a rota��o � c�mera (transform) com base nos valores acumulados

    }
}




