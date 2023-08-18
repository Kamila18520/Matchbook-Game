using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Obs³uguje zdarzenia kiedy zapa³ka zostanie nakliknieta


----------------------------------------------------------------------------------------------------------- */
public class ClickController : MonoBehaviour
{

    private LTDescr matchAnim;
    public float scaleByPercentage;



    public string difficulty;
    public bool isPressed;
    public bool isOn;
    public bool isOff;
    public Vector3 sampleScale;
    public GameObject Container;
    private AudioSource matchSound;
    private object spriteRenderer;

    public void Start()
    {

        matchSound = GetComponentInParent<AudioSource>();

        difficulty = ModeDifManager.difficulty;


        Container = GameObject.Find("ContainerForNumbers");
        scaleByPercentage = 1.2f;
        sampleScale = transform.localScale;
        PutMatchAnimation();
  
    }

    public void OnMouseDown()
    {


        if(!Container.GetComponent<MarkMatches>().isPressed && gameObject.GetComponent<SpriteRenderer>().enabled == true)

        {
            Debug.Log("Zostala zaznaczona zapalka");
            isPressed= true;
            Container.GetComponent<MarkMatches>().isPressed = true;
            MatchAnimation();
            
        }
        else if (Container.GetComponent<MarkMatches>().isPressed && gameObject.GetComponent<SpriteRenderer>().enabled == true)

        {          

            if(isPressed) 
            {
                Debug.Log("Zosta³a odznaczona zapa³ka ktora wczesniej byla juz zaznaczona");
                Container.GetComponent<MarkMatches>().isPressed= false;
                isPressed= false;
                StopAnimation();
                
            }
            else if(!isPressed) 
            {
                Debug.Log("Zostala zaznaczona nowa zapalka");
                 
                    Container.GetComponent<MarkMatches>().EnableIfIsPressed();
                      MatchAnimation();
                

                     isPressed = true;
                

            }
        }
          else if(Container.GetComponent<MarkMatches>().isPressed && gameObject.GetComponent<SpriteRenderer>().enabled == false)

        {       
              

                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Container.GetComponent<MarkMatches>().isPressed = false;
                Container.GetComponent<MarkMatches>().DisableMatchIfIsPressed();
                Container.GetComponent<CheckIfWin>().Check();
                matchSound.Play();
                PutMatchAnimation();
                isPressed = false;

        }


    }

    private void MatchAnimation()
    {
       
       matchAnim = LeanTween.scale(gameObject, new Vector3(sampleScale.x * scaleByPercentage, sampleScale.y * scaleByPercentage, sampleScale.z * scaleByPercentage), .6f)
            .setLoopPingPong()
             .setEase(LeanTweenType.easeInOutSine);
    }


    public void StopAnimation()
    {

        // Zatrzymaj animacjê za pomoc¹ LeanTween.cancel() i przeka¿ ID tweenu
        LeanTween.cancel(matchAnim.id);
        transform.localScale = Vector3.Lerp(sampleScale, transform.localScale, Time.deltaTime);
        
    }

    public void PutMatchAnimation()
    {
        
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = transform.localScale * 1.3f;
        gameObject.transform.localScale = targetScale;

        LeanTween.scale(gameObject, originalScale, 0.3f).setEase(LeanTweenType.easeOutQuad);
    }

    public void WrongSetAnimation()
    {
        Vector3 originalScale = transform.localScale;

    }


}
