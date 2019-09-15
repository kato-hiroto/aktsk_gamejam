using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Transform tf;

    void Start()
    {
        tf = transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (DB.isStarted)
        {
            tf.position += Vector3.left * DB.pictureSetMovementSpeed * Time.deltaTime;
        }
    }
}
