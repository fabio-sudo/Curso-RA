using UnityEngine;

public class GlassesUIController : MonoBehaviour
{
    public static GlassesUIController Instance;

    private GlassesManager currentManager;

    void Awake()
    {
        Instance = this;
    }

    // chamado pelo GlassesGroup quando ele nasce
    public void Register(GlassesManager manager)
    {
        currentManager = manager;
        Debug.Log("✅ GlassesManager registrado no Canvas");
    }

    // chamado pelos botões
    public void SelectGlasses(int index)
    {
        if (currentManager == null)
        {
            Debug.LogError("❌ Nenhum GlassesManager registrado");
            return;
        }

        currentManager.ActivateGlasses(index);
    }
}
