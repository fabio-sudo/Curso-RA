using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private Transform modelObject;
    public float rotationStep = 15f;

    private void OnEnable()
    {
        ARObjectEvents.OnARObjectSpawned += SetModel;
    }

    private void OnDisable()
    {
        ARObjectEvents.OnARObjectSpawned -= SetModel;
    }

    public void SetModel(Transform newModel)
    {
        modelObject = newModel;
        Debug.Log("Objeto AR recebido pelo Canvas");
    }

    public void RotateLeft()
    {
        if (modelObject == null) return;
        modelObject.Rotate(0f, rotationStep, 0f, Space.World);
    }

    public void RotateRight()
    {
        if (modelObject == null) return;
        modelObject.Rotate(0f, -rotationStep, 0f, Space.World);
    }
}
