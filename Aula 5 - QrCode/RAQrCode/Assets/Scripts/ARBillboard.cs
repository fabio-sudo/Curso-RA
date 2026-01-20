using UnityEngine;

public class ARBillboard : MonoBehaviour
{
    private Camera arCamera;

    private void Start()
    {
        // Pega automaticamente a câmera principal do AR
        arCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (arCamera == null) return;

        // Direção do popup até a câmera
        Vector3 direction = transform.position - arCamera.transform.position;

        // Mantém o popup olhando para a câmera
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
