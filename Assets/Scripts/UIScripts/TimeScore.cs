using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeScore : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField] private float currentScore = 1000;
    bool canDecrease;

    private void Start()
    {
        canDecrease = true;
    }
    //allows score to decrease. can be turned off later


    private void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        if (canDecrease)
        {
            currentScore -= 1 * Time.deltaTime;
        }
        //Decreases score overtime. faster completion equals bigger score. Deltatime ensures 1 score decays over 1 second
        if(currentScore < 1)
        {
            canDecrease = false;
        }
        
        //if score is too low then it wont decrease.
        //IT WORKS! SOMETHNING WORKED!. . . now to stop it when level ends.

    }



}

