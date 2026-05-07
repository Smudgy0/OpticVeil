using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
public void NextScene1()
    {
        SceneManager.LoadScene("Level 1 (Tutorial)");
    }
    public void NextScene2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void NextScene3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void NextScene0()
    {
        SceneManager.LoadScene("Main Menu");
    }
    //All scenes labeled to easily tell which ones which. Useful for the Level select and going to specific levels
    public void FixTime()
    {
        Time.timeScale = 1.0f;
        //Unpauses the game when button is clicked. fixing the "permamently paused game" bug
    }

}
