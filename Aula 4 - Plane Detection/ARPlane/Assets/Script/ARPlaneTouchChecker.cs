using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class ARPlaneTouchChecker : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public TextMeshProUGUI debugText;

    private List<ARRaycastHit> hits = new();

    void Update()
    {
        // 🔴 Verifica Touchscreen
        if (Touchscreen.current == null)
        {
            debugText.text = "❌ Touchscreen.current NULL";
            return;
        }

        // 🔴 Verifica se existe toque
        if (Touchscreen.current.touches.Count == 0)
        {
            debugText.text = "Sem toque";
            return;
        }

        //=====================Inicia se passar pelas validações
        var touch = Touchscreen.current.touches[0];

        // 🔴 Apenas quando o toque começa
        if (touch.press.wasPressedThisFrame)
        {
            //Método que exibe a captura
            CapturaToque(touch);
        }   
    }


    //Metodo exibir se o touch foi realizado
    private void CapturaToque(TouchControl touch)
    {
        Vector2 touchPosition = touch.position.ReadValue();

        AtualizaDebug($"Toque em: {touchPosition}");

        if (raycastManager == null)
        {
            AtualizaDebug("❌ RaycastManager NULL");
            return;
        }

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            AtualizaDebug("✅ Clicou em um PLANO AR");
        else
            AtualizaDebug("❌ Não clicou em plano");
    }

    //Escreve no UI
    private void AtualizaDebug(string msg)
    {
        if (debugText != null)
            debugText.text = msg;
    }


    //Guarda o Plano detectado
    public bool TryGetPlaneHit(Vector2 touchPosition, out Pose hitPose)
    {
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            hitPose = hits[0].pose;
            return true;
        }

        hitPose = default;
        return false;
    }

}
