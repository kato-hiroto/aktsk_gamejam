using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightTargetScript : MonoBehaviour
{
    [SerializeField] private Transform spotlightSprite;

    //[SerializeField] private Transform tes;

    public Vector3 targetPosition;
    public float maxSpeed = 1f;

    public float maxRadius = 3.5f;
    public float minRadius = 1f;
    
    private Material spotlightMaterial;

    private Vector3 lastTargetPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        spotlightMaterial = spotlightSprite.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        //targetPosition = tes.position;

        
        Vector3 velocity = targetPosition - transform.position;
        float minError = 1f;
        if (velocity.sqrMagnitude < minError * minError)
        {
            transform.position = targetPosition + Vector3.left * DB.pictureSetMovementSpeed * Time.deltaTime;
           // Debug.Log("Thisis");
        }
        else
        {
            if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            }

            transform.Translate(velocity * Time.deltaTime * 10f);
        }

        float targetRadius = velocity.sqrMagnitude > 1.5f * 1.5f ? minRadius : maxRadius;
        if(lastTargetPos == targetPosition)
        {
            targetRadius = 0.5f;
        }
        Debug.Log(lastTargetPos + ":" + targetPosition);

        float currentRadius = spotlightMaterial.GetFloat("_Radius");
        float radiusDif = targetRadius - currentRadius;
        radiusDif /= Mathf.Abs(radiusDif + 0.001f);
        spotlightMaterial.SetFloat("_Radius", Mathf.Clamp(currentRadius + radiusDif * 10f * Time.deltaTime, minRadius, maxRadius));
        
        Vector3 p = transform.position;
        spotlightMaterial.SetVector("_Focus", new Vector4(p.x, p.y, p.z));

        lastTargetPos = targetPosition;
    }

}
