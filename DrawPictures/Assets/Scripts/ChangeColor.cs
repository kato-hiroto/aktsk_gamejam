using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Initで設定する変数
    public int myObjectID {get; private set;} = -1;
    private DB.ColorID correctColorID = DB.ColorID.Null;

    // コンポーネントの保持
    private AudioManager am = null;
    private Transform tf = null;
    private SpriteRenderer correctFrontSR = null;
    private SpriteRenderer correctBackSR = null;
    private SpriteRenderer answerFrontSR = null;
    private SpriteRenderer answerBackSR = null;

    // 内部で保持する値
    private DB.ColorID answerColorID = DB.ColorID.Null;

    // フラグ
    public bool isAlreadyCatchedFocus {get; private set;} = false;
    public bool isCorrect {get; private set;} = false;
    public bool isAlreadySetColor {get; private set;} = false;

    // Generatorによる初期値設定
    public void Init(int objID, DB.ColorID colID, Material mat)
    {
        // AudioManagerの取得
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        // 自分のSprite取得
        var tmpCorrect = transform.Find("Correct");
        var tmpAnswer  = transform.Find("Answer");
        //correctFrontSR = tmpCorrect.Find("FrontPicture").GetComponent<SpriteRenderer>();
        correctBackSR = tmpCorrect.Find("BackPicture").GetComponent<SpriteRenderer>();
        //answerFrontSR = tmpAnswer.Find("FrontPicture").GetComponent<SpriteRenderer>();
        answerBackSR = tmpAnswer.Find("BackPicture").GetComponent<SpriteRenderer>();
        tf = transform;

        myObjectID = objID;
        correctColorID = colID;

        correctBackSR.material = mat;
        answerBackSR.material = mat;
        // Spriteのセット
        //correctFrontSR.sprite = sprite;
        //answerFrontSR.sprite = sprite;
        correctBackSR.color = DB.colorCode[(int)correctColorID];
    }
    
    // Update is called once per frame
    private void Update()
    {
        // 自分にフォーカス
        if (DB.focusID == myObjectID)
        {
            if (tf == null || 10f < tf.position.x)
            {
                // 見えていないなら却下
                return;
            }
            if (!isAlreadyCatchedFocus)
            {
                // 先行入力なら却下（次の入力から取得）
                DB.currentColorID = DB.ColorID.Null;
                isAlreadyCatchedFocus = true;
            }
            else if (DB.currentColorID != DB.ColorID.Null)
            {
                // そうでない & 色IDがID.Nullでないなら色取得
                answerColorID = DB.currentColorID;
                answerBackSR.color = DB.colorCode[(int)answerColorID];

                // 合否判定
                isCorrect = (answerColorID == correctColorID);
                am.PlayOneShot("Painting");

                // 色を取得したらDBを次へ更新
                DB.currentColorID = DB.ColorID.Null;
                DB.focusID += 1;
                isAlreadySetColor = true;
                
                //ブラシを表示
                BrushScript.Instance.Appear(answerColorID, transform);
            }
        }
    }
}
