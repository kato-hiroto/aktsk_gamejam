using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // スコア更新フラグ
    public bool isUpdatedHigh = false;

    // Start is called before the first frame update
    private bool isWaitingTitle = false;
    private AfterGameAnimController animCont;
    void Start()
    {
        isWaitingTitle = false;
        animCont = GameObject.Find("UICanvas").GetComponent<AfterGameAnimController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DB.playerLife < 0f && DB.isStarted)
        {
            DB.isStarted = false;
            int max = PlayerPrefs.GetInt("Score");
            // スコア更新
            if ((int)DB.gameScore > max) {
                isUpdatedHigh = true;
                PlayerPrefs.SetInt("Score", (int)DB.gameScore);
            }
            animCont.DoGameOverAnim();
            StartCoroutine(Waiter(1f, true));
        }
        if (isWaitingTitle && Input.GetKeyDown(KeyCode.Space))
        {
            animCont.GoStartAnim();
            StartCoroutine(TitleWaiter(1f));
        }
    }

    private IEnumerator Waiter(float sec, bool flag)
    {
        yield return new WaitForSeconds(sec);
        isWaitingTitle = flag;
    }

    private IEnumerator TitleWaiter(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("Title");
    }
}
