using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorGimmick : MonoBehaviour
{
    public GameObject floor;
    public float RotationSpeed = 90f;
    public float StopInterval = 2f;
    public float StopDuration = 1f;

    private bool isRotation = true;
    private Coroutine RotateCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        StartCoroutine(RotationAndStop());
    }

    IEnumerator RotationAndStop()
    {
        isRotation = true;
        float elapsedTime = 0f;

        while (elapsedTime < StopInterval)
        {
            if (isRotation)
            {
                transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //’âŽ~’†
        isRotation = false;
        yield return new WaitForSeconds(StopDuration);
    }
}
