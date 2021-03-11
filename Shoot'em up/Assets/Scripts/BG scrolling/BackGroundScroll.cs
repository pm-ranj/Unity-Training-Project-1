using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] float ScrollingSpeed = 0.5f;
    private MeshRenderer MeshRenderer;
    private float Xscroll;

    void Awake()
    {
        MeshRenderer = gameObject.GetComponent<MeshRenderer>();
       
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Xscroll = Time.time * ScrollingSpeed;
        Vector2 offset = new Vector2(Xscroll, 0f);
        MeshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
