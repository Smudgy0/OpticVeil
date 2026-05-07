using Unity.Cinemachine;
using UnityEngine;

public class EndLevelFlag : MonoBehaviour, IInteractable
{
    public GameObject endLevelScreen;
    bool IsCollected;
    public bool CanInteract()
    {
        return !IsCollected;
    }
    public void Interact()
    {
        if (!CanInteract()) return;
        endLevelScreen.SetActive(true);
        

        Time.timeScale = 0f;
    }

    
}
