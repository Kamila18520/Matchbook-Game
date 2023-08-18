using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsAnimation : MonoBehaviour//, IPointerEnterHandler
{

    public float maxPlayScalePulse = 1.15f;
    public float maxScale = 1.15f;
    public float pulseDuration = 0.5f;
    public bool wasActive = false;


    public Vector3 originalScale;

    [SerializeField] private bool PlayButton = false;

    public void Start()
    {
 
        originalScale = transform.localScale;
        gameObject.transform.localScale = originalScale;
       StartAnim();

        if(PlayButton) 
        {
            StartPulseAnimation();
        }



    }


    public void StartAnim()
    {

        Vector3 changedScale = originalScale * maxScale;
        gameObject.transform.localScale = changedScale;

        LeanTween.scale(gameObject, originalScale, pulseDuration).
               setEase(LeanTweenType.easeOutQuint)
               .setLoopOnce();
        wasActive= true;
        //gameObject.transform.localScale = originalScale;



    }

    private void StartPulseAnimation()
    {
        gameObject.transform.localScale = originalScale;
        LeanTween.scale(gameObject, originalScale * maxPlayScalePulse, pulseDuration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();
    }

    public void ButtonNextStepAnim()
    {

        originalScale = transform.localScale;
           LeanTween.scale(gameObject, originalScale * maxScale, pulseDuration).
               setEase(LeanTweenType.easeOutCirc);
        gameObject.transform.localScale = originalScale;

    }
}



