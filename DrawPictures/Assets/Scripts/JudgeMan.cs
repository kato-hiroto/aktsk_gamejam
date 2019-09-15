using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeMan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float durationTimeSec = 1f;

    private AudienceController animCont;
    private SpriteRenderer correctRenderer;
    private SpriteRenderer inCorrectRenderer;
    private float isInCorrectTimer = 0;
    private float isCorrectTimer = 0;
    void Start()
    {
        animCont = GameObject.Find("UICanvas").GetComponent<AudienceController>();
        correctRenderer = transform.Find("Correct").GetComponent<SpriteRenderer>();
        inCorrectRenderer = transform.Find("InCorrect").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isCorrectTimer > 0)
        {
            inCorrectRenderer.enabled = false;
            correctRenderer.enabled = true;
            isCorrectTimer -= Time.deltaTime;
        }
        else if (isInCorrectTimer > 0)
        {
            correctRenderer.enabled = false;
            inCorrectRenderer.enabled = true;
            isInCorrectTimer -= Time.deltaTime;
        }
        else
        {
            correctRenderer.enabled = false;
            inCorrectRenderer.enabled = false;
        }
    }

    public void JudgeView(bool isCorrect, bool isAlready)
    {
        if (isCorrect)
        {
            isInCorrectTimer = 0f;
            isCorrectTimer = durationTimeSec;
            animCont.callGoodRandom();
        }
        else if (isAlready)
        {
            isCorrectTimer = 0f;
            isInCorrectTimer = durationTimeSec;
            animCont.callBadRandom();
        }
        else {
            isCorrectTimer = 0f;
            isInCorrectTimer = durationTimeSec;
            animCont.callBlankRandom();
        }
    }
}
