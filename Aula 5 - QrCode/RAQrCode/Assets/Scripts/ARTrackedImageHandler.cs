using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedImageHandler : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // Quando um novo marker for detectado
        foreach (var trackedImage in args.added)
        {
            if (trackedImage.transform.childCount > 0)
            {
                Transform spawnedObject = trackedImage.transform.GetChild(0);

                // DISPARA O EVENTO
                ARObjectEvents.OnARObjectSpawned?.Invoke(spawnedObject);
            }
        }
    }
}
