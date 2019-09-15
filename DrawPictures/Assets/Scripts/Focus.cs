using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    public SpotlightTargetScript focusFrame;
    private int myID;

    private Transform tf;
    
    // Start is called before the first frame update
    public void Init(int objectID, SpotlightTargetScript focusFrame)
    {
        this.focusFrame = focusFrame;
        this.myID = objectID;

        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (myID == DB.focusID)
        {
            /*float Error = Vector3.SqrMagnitude(focusFrame.position - tf.position);
            if (Error > 0.2f)
            {
                focusFrame.position = Vector3.Lerp(focusFrame.position, tf.position, 0.5f) + Vector3.forward;
            }
            else
            {
                focusFrame.position = tf.position + Vector3.forward;
            }*/

            focusFrame.targetPosition = tf.position;
        }
    }
}
