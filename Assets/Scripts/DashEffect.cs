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
    SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponent<SpriteRenderer>();


    public void OnShowEffect(Transform trans, Sprite sprite, int index, float duration)
    {
        this.gameObject.SetActive(true);
        SpriteRenderer.sprite = sprite;
        transform.position = trans.position;
        transform.localScale = trans.localScale;
        SpriteRenderer.color = new Color(1, 1, 1, 1f / index);
        StartCoroutine(ProcessEffect(duration));
    }

    private IEnumerator ProcessEffect(float duration = 0.2f)
    {
        yield return new WaitForSeconds(duration);
        this.gameObject.SetActive(false);
    }
}
