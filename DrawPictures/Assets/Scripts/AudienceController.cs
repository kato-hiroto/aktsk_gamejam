using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudienceController : MonoBehaviour
{
    public Animator audienceAnim;
    public Animator commentAnim;
    public Text commentText;

    private AudioManager am = null;

    private void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private List<string> goodMessageList = new List<string>(){
        "Fantastic!", 
        "Marvelous!!",
        "Beautiful...!",
        "Nice Color!!"
    };
    private List<string> badMessageList = new List<string>(){
        "Too Strange!", 
        "Frightful...",
        "Cheap.",
        "Difficult for us."
    };
    private List<string> blankMessageList = new List<string>(){
        "Do Work.", 
        "Don't trifle with us!",
        "Too White!"
    };

    public void callGood(string message) {
        audienceAnim.SetTrigger("good");
        commentAnim.SetTrigger("good");
        am.PlayOneShot("CheerShort");
        commentText.text = message;
    }
    
    public void callGoodRandom() {
        int rndm = Random.Range(0, goodMessageList.Count);
        audienceAnim.SetTrigger("good");
        commentAnim.SetTrigger("good");
        am.PlayOneShot("CheerShort");
        commentText.text = goodMessageList[rndm];
    }

    public void callBad(string message) {
        audienceAnim.SetTrigger("bad");
        commentAnim.SetTrigger("bad");
        am.PlayOneShot("BooingShort");
        commentText.text = message;
    }
    
    public void callBadRandom() {
        int rndm = Random.Range(0, badMessageList.Count);
        audienceAnim.SetTrigger("bad");
        commentAnim.SetTrigger("bad");
        am.PlayOneShot("BooingShort");
        commentText.text = badMessageList[rndm];
    }
    
    public void callBlank(string message) {
        audienceAnim.SetTrigger("bad");
        commentAnim.SetTrigger("bad");
        am.PlayOneShot("BooingShort");
        commentText.text = message;
    }
    
    public void callBlankRandom() {
        int rndm = Random.Range(0, blankMessageList.Count);
        audienceAnim.SetTrigger("bad");
        commentAnim.SetTrigger("bad");
        am.PlayOneShot("BooingShort");
        commentText.text = blankMessageList[rndm];
    }
}
