using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class DashEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    SpriteRenderer SpriteRenderer => spriteRenderer ??= GetComponent<SpriteRenderer>();
    

    public float Delay = 0.5f;
    Transform transform;
    public Transform tr => transform ??= GetComponent<Transform>();

    public void OnEffect()
    {
        SpriteRenderer PspriteRenderer = GetComponentInParent<SpriteRenderer>();
        transform.gameObject.SetActive(true);
        SpriteRenderer.sprite = PspriteRenderer.sprite;
    }

    public void OffEffect()
    {
        transform.gameObject.SetActive(false);
    }
}
