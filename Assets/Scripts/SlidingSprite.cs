using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingSprite : MonoBehaviour
{
    public RectTransform spriteRectTransform;
    public Vector3 onScreenPosition;
    public Vector3 offScreenPosition;
    public float slideSpeed = 1.0f;
    public float delay = 1.0f;
 

    private bool isOnScreen = false;

    public void ToggleSprite()
    {
        Debug.Log("ToggleSprite called");
        StopAllCoroutines();
        if (isOnScreen)
        {
            StartCoroutine(SlideSprite(offScreenPosition));
        }
        else
        {
            StartCoroutine(SlideSprite(onScreenPosition));
        }
        isOnScreen = !isOnScreen;
    }

    private IEnumerator SlideSprite(Vector3 targetPosition)
    {
        Debug.Log("SlideSprite started");
        if (!isOnScreen)
        {
            yield return new WaitForSeconds(delay);
        }

        while (Vector3.Distance(spriteRectTransform.anchoredPosition, targetPosition) > 0.1f)
        {
            spriteRectTransform.anchoredPosition = Vector3.Lerp(spriteRectTransform.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
            yield return null;
        }
        spriteRectTransform.anchoredPosition = targetPosition;
        Debug.Log("SlideSprite finished");
    }
}
