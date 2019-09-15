using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    private Image img = null;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {        
        float lifeVal = DB.playerLife / DB.playerMaxLife;
        img.fillAmount = lifeVal;
        if (lifeVal > 0.5f)
        {
            img.color = Color.green;
        }
        else if (lifeVal > 0.2f)
        {
            img.color = Color.yellow;
        }
        else
        {
            img.color = Color.red;
        }
    }
}
