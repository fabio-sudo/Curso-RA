using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.InputSystem;

public class ARPortalSpawner : MonoBehaviour
{
    [Header("Dependências")]
    public ARPlaneTouchChecker touchChecker;
    public ARPlaneManager planeManager;

    [Header("Portal")]
    public GameObject portalPrefab;

    private GameObject portalInstanciado;

    void Update()
    {
        if (portalInstanciado != null) return;
        if (Touchscreen.current == null) return;
        if (Touchscreen.current.touches.Count == 0) return;

        var touch = Touchscreen.current.touches[0];

        if (touch.press.wasPressedThisFrame)
        {
            Vector2 pos = touch.position.ReadValue();

            if (touchChecker.TryGetPlaneHit(pos, out Pose pose))
            {
                portalInstanciado = Instantiate(
                    portalPrefab,
                    pose.position,
                    portalPrefab.transform.rotation
                );

                DesativarPlanos();
            }
        }
    }

    void DesativarPlanos()
    {
        if (planeManager == null) return;

        // 🔒 Para de detectar novos planos
        planeManager.enabled = false;

        // 👻 Oculta planos já existentes
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
