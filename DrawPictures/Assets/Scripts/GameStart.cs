using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DB.Initialize();
        StartCoroutine("CountDown");
    }
    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(4f);
        // Debug.Log(3);
        // yield return new WaitForSeconds(1.0f);
        // Debug.Log(2);
        // yield return new WaitForSeconds(1.0f);
        // Debug.Log(1);
        // yield return new WaitForSeconds(1.0f);
        // Debug.Log("GO!");
        // yield return new WaitForSeconds(1.0f);
        var am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.Play("BGM");
        DB.isStarted = true;
    }
}
