using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMySelf : MonoBehaviour
{
    private float limitXAxisValue = -30f;
    private Transform tf;
    
    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (tf.position.x < limitXAxisValue)
        {
            Destroy(gameObject);
        }
    }
}
