using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushScript : MonoBehaviour
{
    
    public static BrushScript Instance { get; private set; }

    [SerializeField] private float lifeTime = 0.5f;
    
    private SpriteRenderer brushSprite;
    private GameObject brushObject;

    private float currentLife = -1f;
    private Transform targetTf;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        brushObject = transform.Find("BrushObject").gameObject;
        brushSprite = transform.Find("BrushObject/brush_head").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLife > 0f)
        {
            currentLife -= Time.deltaTime;
            
            brushObject.SetActive(true);

            transform.position = targetTf.position;
        }
        else
        {
            brushObject.SetActive(false);
        }
    }

    public void Appear(DB.ColorID colorId, Transform tf)
    {
        brushSprite.color = DB.colorCode[(int) colorId];
        targetTf = tf;
        
        currentLife = lifeTime;
    }
}
