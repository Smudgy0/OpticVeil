using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveScript : MonoBehaviour
{
    public Text MainObjectiveText;
    public Text SideObjectiveText1;
    public Text SideObjectiveText2;

    public float CurrentAmount;
    public float RequiredAmount1;
    public float RequiredAmount2;

    void Start()
    {
        MainObjectiveText.text = "Reach the end of the level";
        SideObjectiveText1.text = $"Defeat 5 enemies ({CurrentAmount}/{RequiredAmount1})";
        SideObjectiveText2.text = $"Defeat 10 enemies ({CurrentAmount}/{RequiredAmount2})";

        CurrentAmount = 0;


    }
}
