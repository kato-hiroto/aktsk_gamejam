using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーに対応した色IDをDBに挿入
public class InputReceiver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DB.currentColorID = DB.ColorID.Red;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DB.currentColorID = DB.ColorID.Orange;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DB.currentColorID = DB.ColorID.Yellow;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            DB.currentColorID = DB.ColorID.Green;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            DB.currentColorID = DB.ColorID.Cyan;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            DB.currentColorID = DB.ColorID.Blue;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            DB.currentColorID = DB.ColorID.Purple;
        }
        // else if (Input.GetKeyDown(KeyCode.Semicolon))
        // {
        //     DB.currentColorID = DB.ColorID.Purple;
        // }
    }

    public void ChoiceFromMouse(int intColorID) {
        DB.currentColorID = (DB.ColorID)intColorID;
    }
}
