using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSceneBehaviour : StateMachineBehaviour
{
    public float fadeTime = 0.5f;
    private float timeElapsed = 0f;
    SpriteRenderer spriteRenderer;
    Color startColor;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed += Time.deltaTime;
        float newAlpha = startColor.a * (1 - timeElapsed / fadeTime);

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

        if (timeElapsed > fadeTime)
        {
            SceneManager.LoadScene(2);
        }
    }
}
