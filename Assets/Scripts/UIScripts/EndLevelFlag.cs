using Unity.Cinemachine;
using UnityEngine;

public class EndLevelFlag : MonoBehaviour, IInteractable
{
    public GameObject endLevelScreen;
    bool IsCollected;
    public bool CanInteract()
    {
        return !IsCollected;
        //makes sure item is interactable)
    }
    public void Interact()
    {
        if (!CanInteract()) return;
        endLevelScreen.SetActive(true);
        //if interacted with, shows end results screen.
        

        Time.timeScale = 0f;
        //Pauses the game. stops score from dropping and enemies from attacking by freezing time
    }

    
}
