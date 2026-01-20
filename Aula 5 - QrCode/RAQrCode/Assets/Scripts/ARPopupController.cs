using UnityEngine;

public class ARPopupController : MonoBehaviour
{
    private GameObject popup;

    private void OnEnable()
    {
        ARObjectEvents.OnARObjectSpawned += OnObjectSpawned;
    }

    private void OnDisable()
    {
        ARObjectEvents.OnARObjectSpawned -= OnObjectSpawned;
    }

    private void OnObjectSpawned(Transform arObject)
    {
        ARPopup popupComponent = arObject.GetComponentInChildren<ARPopup>(true);

        if (popupComponent != null)
        {
            popup = popupComponent.gameObject;
            popup.SetActive(false);
        }
        else
        {
            Debug.LogWarning("ARPopup não encontrado no objeto AR");
        }
    }

    public void TogglePopup()
    {
        if (popup == null) return;
        popup.SetActive(!popup.activeSelf);
    }
}
