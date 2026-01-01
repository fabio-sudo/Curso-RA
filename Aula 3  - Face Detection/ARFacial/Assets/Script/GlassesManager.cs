using UnityEngine;

public class GlassesManager : MonoBehaviour
{
    public GameObject[] glasses;

    [Header("Óculos inicial (-1 = nenhum)")]
    public int defaultGlasses = 0;

    void Start()
    {
        // registra no Canvas
        if (GlassesUIController.Instance != null)
        {
            GlassesUIController.Instance.Register(this);
        }

        // desativa todos
        DisableAll();

        // ativa um padrão (se quiser)
        if (defaultGlasses >= 0 && defaultGlasses < glasses.Length)
        {
            glasses[defaultGlasses].SetActive(true);
        }
    }

    public void ActivateGlasses(int index)
    {
        if (index < 0 || index >= glasses.Length)
            return;

        DisableAll();
        glasses[index].SetActive(true);
    }

    void DisableAll()
    {
        foreach (var g in glasses)
            if (g != null)
                g.SetActive(false);
    }
}
