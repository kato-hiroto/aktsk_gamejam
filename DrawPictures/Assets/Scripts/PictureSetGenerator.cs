using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PictureSetGenerator : MonoBehaviour
{
    [SerializeField] private Texture emptyTexture;
    [SerializeField] private TextureSet[] textureSets;
    [SerializeField] private GameObject pictureSetPrefab;

    [SerializeField] private Transform pictureSetInitPosition;

    [SerializeField] private SpotlightTargetScript focusFrame;

    [SerializeField] private Shader multipleTextureShader;
    [SerializeField] private int materialBufferNum = 5;

    [SerializeField] float twoTexTime = 20f;
    [SerializeField] float threeTexTime = 60f;
    [SerializeField] float fourTexTime = 80f;

    private Transform lastGeneratedPictureSet;

    private int colorIDTypeLength;

    private int currentObjectID = 0;
    private int currentMaterialIndex = 0;

    private Material[] materialBuffer;


    private float generateSpaceMargine = 2.8f;
    private float generateTimeMargine = 1.5f;

    private float distanceBase = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        colorIDTypeLength = Enum.GetValues(typeof(DB.ColorID)).Length;
        Debug.Log(colorIDTypeLength);
        
        //マテリアルバッファの作成
        materialBuffer = new Material[materialBufferNum];
        for (int i = 0; i < materialBuffer.Length; i++)
        {
            materialBuffer[i] = new Material(multipleTextureShader);
        }
        MaterialInit();

        DB.pictureSetMovementSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //始まってない場合
        if (!DB.isStarted) return;

        //最初に生成する場合
        if (lastGeneratedPictureSet == null)
        {
            DB.pictureSetMovementSpeed = 2f;
            distanceBase = 15;
            PictureSetGenerate();
            DB.waveTrigger = true;
            return;
        }

        //ある程度動いたら生成
        /*
        float moveDistance = Mathf.Abs(lastGeneratedPictureSet.position.x - pictureSetInitPosition.position.x);
        if (moveDistance > pictureSetInterval)
        {
            PictureSetGenerate();
        }
        */
        if (DB.waveTrigger)
        {
            Debug.Log(DB.wave);
            DB.waveTrigger = false;

            switch (DB.wave)
            {
                case 0:
                    StartCoroutine(Builder(15f, 2f));
                    break;
                case 1:
                    StartCoroutine(Builder(10f, 3f));
                    break;
                case 2:
                    StartCoroutine(Builder(12f, 3.5f));
                    break;
                case 3:
                    StartCoroutine(Builder(1f, 1.5f));
                    break;
                case 4:
                    StartCoroutine(Builder(3f, 2f));
                    break;
                case 5:
                    StartCoroutine(Builder(6f, 5f));
                    break;
                case 6:
                    StartCoroutine(Builder(9f, 7f));
                    break;
                case 7:
                    StartCoroutine(Builder(4f, 6f));
                    break;
                case 8:
                    StartCoroutine(Builder(10f, 7f));
                    break;
                case 9:
                    StartCoroutine(Builder(5f, 6.5f));
                    break;
                case 10:
                    StartCoroutine(Builder(5f, 8f));
                    break;
                default:
                    float sp = Random.Range(4f, 10f);
                    float ra = Random.Range(2f, 10f);
                    StartCoroutine(Builder(ra, sp));
                    break;
            }
        }        
    }

    private IEnumerator Builder(float distance, float speed)
    {
        float time = DB.waveTime - generateTimeMargine;
        float timer = 0f;
        float startSpeed = DB.pictureSetMovementSpeed;
        float speedDelta = speed - startSpeed;
        float startDist = distanceBase;
        float distDelta = distance - startDist;
        while (timer < time)
        {
            DB.pictureSetMovementSpeed = startSpeed + speedDelta*timer/time;
            distanceBase = startDist + distDelta * timer / time;
            timer += Time.deltaTime;
            float moveDistance = Mathf.Abs(lastGeneratedPictureSet.position.x - pictureSetInitPosition.position.x);
            if (moveDistance > distanceBase + generateSpaceMargine)
            {
                PictureSetGenerate();
                
            }
           // Debug.Log(DB.pictureSetMovementSpeed);
           // Debug.Log(distanceBase);
            yield return null;
        }
    }

    void PictureSetGenerate()
    {
        GameObject ps = Instantiate(pictureSetPrefab);
        lastGeneratedPictureSet = ps.transform;
        lastGeneratedPictureSet.position = pictureSetInitPosition.position;

        //正解の色の決定
        DB.ColorID correctColor = ColorDecision();
        
        //マテリアルの作成
        Material currentMaterial = materialBuffer[currentMaterialIndex];
        MakeMaterial(currentMaterial);

        //ChangeColorの初期化
        ChangeColor changeColor = ps.GetComponent<ChangeColor>();
        changeColor.Init(currentObjectID, correctColor, currentMaterial);

        //Focusの初期化
        Focus focus = ps.GetComponent<Focus>();
        focus.Init(currentObjectID, focusFrame);
        
        currentObjectID++;
        currentMaterialIndex = (currentMaterialIndex + 1) % materialBufferNum;
    }

    DB.ColorID ColorDecision()
    {
        return (DB.ColorID) Random.Range(1, colorIDTypeLength);
    }

    void MakeMaterial(Material mat)
    {
        //背景色の決定
        mat.SetColor("_BGColor", Color.HSVToRGB(Random.value, 0.25f, 1f));

        //テクスチャセットの決定
        Texture[] textureSet = textureSets[Random.Range(0, textureSets.Length)].textures;

        {
            const string texName = "_ColorTex";
            mat.SetTexture(texName, textureSet[Random.Range(0, textureSet.Length)]);
            mat.SetTextureScale(texName, Vector2.one * Random.Range(0.3f, 1f));
            mat.SetTextureOffset(texName, RandomOffset(0.8f));
        }

        if (DB.gameTime > twoTexTime)
        {
            const string texName = "_Tex1";
            mat.SetTexture(texName, textureSet[Random.Range(0, textureSet.Length)]);
            mat.SetTextureScale(texName, Vector2.one * Random.Range(0.4f, 1.5f));
            mat.SetTextureOffset(texName, RandomOffset(1f));
            
            mat.SetColor("_Color1", RandomColor());
        }
        
        if (DB.gameTime > threeTexTime)
        {
            const string texName = "_Tex2";
            mat.SetTexture(texName, textureSet[Random.Range(0, textureSet.Length)]);
            mat.SetTextureScale(texName, Vector2.one * Random.Range(0.4f, 0.7f));
            mat.SetTextureOffset(texName, RandomOffset(1f));
            
            mat.SetColor("_Color2", RandomColor());
        }
        
        if (DB.gameTime > fourTexTime)
        {
            const string texName = "_Tex3";
            mat.SetTexture(texName, textureSet[Random.Range(0, textureSet.Length)]);
            mat.SetTextureScale(texName, Vector2.one * Random.Range(1.1f, 1.5f));
            mat.SetTextureOffset(texName, RandomOffset(1f));
            
            mat.SetColor("_Color3", RandomColor());
        }
    }

    void MaterialInit()
    {
        foreach (var mat in materialBuffer)
        {
            mat.SetTexture("_Tex1", emptyTexture);
            mat.SetTexture("_Tex2", emptyTexture);
            mat.SetTexture("_Tex3", emptyTexture);
        }
    }

    Vector2 RandomOffset(float range)
    {
        float min = -range;
        float max = range;
        return new Vector2(Random.Range(min, max), Random.Range(min, max));
    }

    Color RandomColor()
    {
        return DB.colorCode[(int) ColorDecision()];
    }
}
