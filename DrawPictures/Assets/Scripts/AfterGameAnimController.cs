using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterGameAnimController : MonoBehaviour
{
    public Animator baseAnim;
    public Text resultText;
    public Text scoreText;

    private AudioManager am = null;
    private GameOver gameOver = null;
    private int score = 0;


    private void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
    }

    // ゲームオーバー後のアニメーション
    public void DoGameOverAnim()
    {
        // アニメーション開始
        baseAnim.SetTrigger("gameover");

        // スコア取得
        score = Mathf.FloorToInt(DB.gameScore);

        // resultテキストの設置
        resultText.text = retMessageFromScore(score);

        // scoreテキストの設置
        int highscore = PlayerPrefs.GetInt("Score", score);
        string line1 = $"Your Score : {score}\n";
        string line2 = $"High Score : {highscore}";
        scoreText.text = line1 + line2;
    }

    // スタート画面に戻るアニメーション
    public void GoStartAnim()
    {
        baseAnim.SetTrigger("restart");
    }

    // ゲーム開始時のアニメーション開始
    public void OpenCurtainAnim()
    {
        baseAnim.SetTrigger("start");
    }

    // スコアに応じたテキスト生成
    private string retMessageFromScore(int tmpScore) {
        // ハイスコアの時は歓声
        if (gameOver.isUpdatedHigh)
        {
            StartCoroutine(WaitForVoice("CheerLong"));
            return "New Record!!";
        }
        else if (tmpScore < 10)
        {
            StartCoroutine(WaitForVoice("BooingLong"));
            return "You should work seriously.";
        }
        else if (tmpScore < 30)
        {
            StartCoroutine(WaitForVoice("CheerLong"));
            return "You can do it better next time!";            
        }
        else if (tmpScore < 60)
        {
            StartCoroutine(WaitForVoice("CheerLong"));
            return "Good job! Thank you!";            
        }
        if (tmpScore < 120)
        {
            StartCoroutine(WaitForVoice("CheerLong"));
            return "Awesome work! Amasing job!!";    
        } else
        {
            StartCoroutine(WaitForVoice("CheerLong"));
            return "You are the top of artist!!";  
        }
    }

    IEnumerator WaitForVoice(string soundName) {
        yield return new WaitForSeconds(3f);
        am.PlayOneShot(soundName);
        baseAnim.SetTrigger("audience");
    }
}
