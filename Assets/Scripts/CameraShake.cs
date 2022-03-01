using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;
    
    Vector3 innisitalPosition;
    void Start()
    {
        innisitalPosition = transform.position;
        
    }

    public void Play() {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while(elapsedTime < shakeDuration) {
            transform.position = innisitalPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = innisitalPosition;
        
    }
}
