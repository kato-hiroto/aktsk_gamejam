using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeView : MonoBehaviour
{
    // Start is called before the first frame update

    private Text view;
    void Start()
    {
        view = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        view.text = DB.playerLife.ToString();
    }
}
