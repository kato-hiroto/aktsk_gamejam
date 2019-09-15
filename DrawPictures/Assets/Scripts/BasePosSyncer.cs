using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePosSyncer : MonoBehaviour
{
    public Transform backpos;
    public float backpos_x = 0f;

    private Vector3 startPos;

    void Start() {
        startPos = backpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        backpos.position = new Vector3(-backpos_x, startPos.y, startPos.z);
    }
}
