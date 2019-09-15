using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DB
{
    public enum ColorID
    {
        Null,
        Red,
        Orange,
        Yellow,
        Green,
        Cyan,
        Blue,
        Purple
    }

    public static ColorID currentColorID = ColorID.Null;
    public static int focusID = 0;
    public static float gameTime = 0f;
    public static float pictureSetMovementSpeed = 10f;
    public static float gameScore = 0f;
    public static float playerLife = 10f;
    public static float playerMaxLife = 10f;
    public static bool isStarted = false;
    public static int wave = 0;
    public static bool waveTrigger = false;
    public static float waveTime = 20f;
    public static List<Color> colorCode = new List<Color>() {
        Color.white,
        Color.red,
        new Color(1.0f, 0.5f, 0f),
        Color.yellow,
        Color.green,
        Color.cyan,
        Color.blue,
        new Color(0.8f,0f, 1.0f)
    };
    
    public static void Initialize()
    {
        currentColorID = ColorID.Null;
        focusID = 0;
        gameTime = 0f;
        pictureSetMovementSpeed = 10f;
        gameScore = 0f;
        playerMaxLife = 10f;
        playerLife = playerMaxLife;
        isStarted = false;
        wave = 0;
        waveTrigger = false;
    }
}
