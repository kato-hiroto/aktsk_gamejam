using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private float initialSpeed = 1f;
    [SerializeField] private float reductionRate = 0.9f;
    [SerializeField] private float maximumSpeed = 10f;

    private float timer = 0f;
    private float waveTime = 20f;

    // Update is called once per frame
    private void Start()
    {
        waveTime = DB.waveTime;
    }
    void Update()
    {
        if(!DB.isStarted) return;
        
        DB.gameTime += Time.deltaTime;

        timer += Time.deltaTime;
        if(timer > waveTime)
        {
            DB.wave += 1;
            DB.waveTrigger = true;
            timer = 0f;
        }
        //DB.pictureSetMovementSpeed = - (maximumSpeed - initialSpeed) * (Mathf.Pow(reductionRate, DB.gameTime)) + maximumSpeed;
        //DB.pictureSetMovementSpeed = Mathf.Min(maximumSpeed, initialSpeed + DB.gameTime * reductionRate);
        //Debug.Log(DB.pictureSetMovementSpeed);
    }
}
