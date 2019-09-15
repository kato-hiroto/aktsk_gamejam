using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextureSetting : ScriptableObject
{
    public Sprite sprite;
    public Texture texture;

    public bool red = true;
    public bool orange = true;
    public bool yellow = true;
    public bool green = true;
    public bool cyan = true;
    public bool blue = true;
    public bool purple = true;
}
