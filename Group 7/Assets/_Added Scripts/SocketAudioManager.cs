using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketAudioManager : MonoBehaviour
{
    private XRSocketInteractor socketInteractor; // The XR socket interactor component
    private AudioSource currentAudioSource; // Reference to the current audio source

    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(OnItemAttached);
        socketInteractor.selectExited.AddListener(OnItemDetached);
    }

    private void OnDestroy()
    {
        socketInteractor.selectEntered.RemoveListener(OnItemAttached);
        socketInteractor.selectExited.RemoveListener(OnItemDetached);
    }

    private void OnItemAttached(SelectEnterEventArgs args)
    {
        // Get the AudioSource component from the attached item
        AudioSource attachedAudioSource = args.interactableObject.transform.GetComponent<AudioSource>();

        if (attachedAudioSource != null)
        {
            // Stop any currently playing audio
            if (currentAudioSource != null)
            {
                currentAudioSource.Stop();
            }

            // Set the attached audio source as the current audio source
            currentAudioSource = attachedAudioSource;

            // Play the audio
            currentAudioSource.Play();
        }
    }

    private void OnItemDetached(SelectExitEventArgs args)
    {
        // Stop the current audio if it exists
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
            currentAudioSource = null;
        }
    }
}

