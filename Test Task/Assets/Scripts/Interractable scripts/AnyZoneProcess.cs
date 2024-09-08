using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

enum ZoneType
{
    CashZone,
    GiveZone,
    CookZone
}

public class AnyZoneProcess : MonoBehaviour
{
    public Image loadingLine;
   
    private float fillSpeed = 1f;

    private Coroutine cancellationCoroutine;
    private Coroutine fillCoroutine;

    private void Awake()
    {
        loadingLine = GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            fillCoroutine = StartCoroutine(FillFloat());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if(fillCoroutine != null)
            {
                StopCoroutine(fillCoroutine);
                fillCoroutine = null;
            }
            
            StartCoroutine(CancellationFloat());
        }
    }

    private IEnumerator FillFloat()
    {
        loadingLine.fillAmount = loadingLine.fillAmount;
        while (loadingLine.fillAmount < 1 )
        {
            loadingLine.fillAmount += fillSpeed * Time.deltaTime;
            yield return null;
        }

        loadingLine.fillAmount = 1;
    }

    private IEnumerator CancellationFloat()
    {
        loadingLine.fillAmount = loadingLine.fillAmount;
        while (loadingLine.fillAmount > 0)
        {
            loadingLine.fillAmount -= fillSpeed * 2f * Time.deltaTime;
            yield return null;
        }

        loadingLine.fillAmount = 0;
    }

}
