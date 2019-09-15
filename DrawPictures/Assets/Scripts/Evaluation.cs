using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluation : MonoBehaviour
{
    private string JudgeLineName = "JudgeLine";
    private string JudgeManName = "JudgeMan";
    private ChangeColor changeColor;
    private JudgeMan judgeman;
    // Start is called before the first frame update
    void Start()
    {
        changeColor = GetComponent<ChangeColor>();
        judgeman = GameObject.Find("JudgeMan").GetComponent<JudgeMan>();
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.name == JudgeLineName)
        {
            if (!changeColor.isAlreadySetColor)
            {
                DB.focusID += 1;
                DB.playerLife -= 0.5f;
            }

            judgeman.JudgeView(changeColor.isCorrect, changeColor.isAlreadySetColor);
            if (changeColor.isCorrect)
            {
                DB.gameScore += 1;
            }
            else
            {
                DB.playerLife -= 1.0f;
            }
        }
    }
}
