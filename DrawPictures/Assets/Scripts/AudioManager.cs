using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Dictionary<string, AudioSource> myAudios = new Dictionary<string, AudioSource>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var tmp = transform.GetChild(i);
            myAudios.Add(tmp.gameObject.name, tmp.GetComponent<AudioSource>());
        }
    }

    // 指定audioのワンショット再生
    public void PlayOneShot(string name)
    {
        myAudios[name].PlayOneShot(myAudios[name].clip);
    }

    // 指定audioの通常再生
    public void Play(string name)
    {
        myAudios[name].Play();
    }
}
