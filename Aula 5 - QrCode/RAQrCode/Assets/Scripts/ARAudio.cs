using UnityEngine;

public class ARAudio : MonoBehaviour
{
    private AudioSource audioSource;

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
        audioSource = arObject.GetComponentInChildren<AudioSource>(true);

        if (audioSource != null)
        {
            audioSource.Stop(); // começa desligado
        }
        else
        {
            Debug.LogWarning("AudioSource não encontrado no objeto AR");
        }
    }

    // Chamado pelo botão do Canvas
    public void ToggleAudio()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource é null");
            return;
        }

        Debug.Log("🔊 ToggleAudio chamado");

        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }

}
