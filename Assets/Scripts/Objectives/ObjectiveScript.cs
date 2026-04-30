using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveScript : MonoBehaviour
{
    public Text MainObjectiveText;
    public Text SideObjectiveText1;
    public Text SideObjectiveText2;

    public float currentAmount1;
    public float currentAmount2;
    public float requiredAmount1;
    public float requiredAmount2;

    void Start()
    {
        MainObjectiveText.text = "Reach the end of the level";
        SideObjectiveText1.text = $"Defeat 5 enemies ({currentAmount1}/{requiredAmount1})";
        SideObjectiveText2.text = $"Defeat 10 enemies ({currentAmount2}/{requiredAmount2})";

        currentAmount1 = 0;
        currentAmount2 = 0;
        requiredAmount1 = 5;
        requiredAmount2 = 10;
    }

    public void KilledEnemy()
    {
        currentAmount1 = Mathf.Clamp(++currentAmount1, 0, requiredAmount1);
        currentAmount2 = Mathf.Clamp(++currentAmount2, 0, requiredAmount2);
    }

}
