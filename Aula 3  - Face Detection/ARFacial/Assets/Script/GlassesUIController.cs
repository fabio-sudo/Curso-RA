using System;
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


    //chama metodo Trocar cor pelo botao
    public void SelectColor(Material material)
    {
        if (currentManager == null)
        {
            Debug.LogError("❌ Nenhum GlassesManager registrado");
            return;
        }

        currentManager.SetMaterial(material);
    }



}
