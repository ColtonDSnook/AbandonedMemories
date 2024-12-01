using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraSlide : MonoBehaviour
{
    public Transform cameraTrans;
    public Vector3 startPos;
    public Vector3 endPos;
    public float moveSpeed = 1.0f;

    private bool moved = false;

    public void ToggleCam()
    {
        StopAllCoroutines();
        if (moved)
        {
            StartCoroutine(MoveCam(startPos));
        }
        else
        {
            StartCoroutine(MoveCam(endPos));
        }
        moved = !moved;
    }

    private IEnumerator MoveCam(Vector3 targetPostion)
    {
        while (Vector3.Distance(cameraTrans.position, targetPostion) > 0.1f)
        {
            cameraTrans.position = Vector3.Lerp(cameraTrans.position, targetPostion, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
