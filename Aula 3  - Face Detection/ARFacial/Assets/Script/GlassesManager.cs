using UnityEngine;

public class GlassesManager : MonoBehaviour
{
    public GameObject[] glasses;

    [Header("Óculos inicial")]
    public int defaultGlasses = 0;

    private static int ultimoIndice = -1;

    //======================Será utilizada como referencia para oculos selecionado
    private GameObject activeGlasses;

    void Start()
    {
        if (GlassesUIController.Instance != null)
            GlassesUIController.Instance.Register(this);

        DisableAll();

        // 🔁 reaplica o último óculos quando o rosto voltar
        if (ultimoIndice >= 0 && ultimoIndice < glasses.Length)
        {
            ActivateGlasses(ultimoIndice);
        }
        else if (defaultGlasses >= 0 && defaultGlasses < glasses.Length)
        {
            ActivateGlasses(defaultGlasses);
        }
    }

    public void ActivateGlasses(int index)
    {
        if (index < 0 || index >= glasses.Length)
            return;

        DisableAll();
        glasses[index].SetActive(true);

        //guarda o último escolhido
        ultimoIndice = index;

        //========================Referencia do oculuos selecionado
        activeGlasses = glasses[index];
    }

    void DisableAll()
    {
        foreach (var g in glasses)
            if (g != null)
                g.SetActive(false);
    }



    //=========================Método para trocar a cor
    public void SetMaterial(Material mat)
    {
        if (activeGlasses == null) return;

        foreach (var r in activeGlasses.GetComponentsInChildren<Renderer>())
        {
            r.material = mat;
        }
    }
}
