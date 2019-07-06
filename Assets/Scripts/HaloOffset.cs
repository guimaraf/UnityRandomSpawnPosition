using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloOffset : MonoBehaviour
{
    public Material mt;
    float offset = 0;
    void Update()
    {
        offset += Time.deltaTime*0.04f;
        mt.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
