using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("move");
            StartCoroutine(WaitForMovingToGame());
        }
    }

    IEnumerator WaitForMovingToGame() {
        yield return new WaitForSeconds(0.67f);
        SceneManager.LoadScene("Game");
    }
}
