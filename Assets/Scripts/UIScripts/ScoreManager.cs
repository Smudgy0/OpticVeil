using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField] private int scoreAmount = 0;

    public void AddScore()
    {
        scoreAmount++;
        scoreText.text = "Score: " + scoreAmount.ToString();
    }
    //shows score updating to score value
}
