using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Cook : MonoBehaviour , IInterractable
{
    public ClientAI client;

    public void Interract()
    {
        throw new System.NotImplementedException();
    }

    public Effect GetEffect()
    {
        throw new System.NotImplementedException();
    }

    //Main Effect
    InterractableHandler _interractableHandler;

    public Image loadingLine;
    private Image loadingBackground;

    private float fillSpeed = 1.0f;
    private Coroutine fillCoroutine;
    private Coroutine fadeCoroutine;

    [Inject]
    public void Construct(InterractableHandler interractableHandler)
    {
        _interractableHandler = interractableHandler;

    }

    private void Awake()
    {
        loadingBackground = GameObject.Find("Loading_background").GetComponent<Image>();
        loadingLine = loadingBackground.transform.GetChild(0).GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FillProcess();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelProcess();
        }
    }

    //FillProcess
    public void FillProcess()
    {
        fillCoroutine = StartCoroutine(FillFloat());
    }

    public IEnumerator FillFloat()
    {
        fadeCoroutine = StartCoroutine(FadeImageCoroutine(1f));

        loadingLine.fillAmount = loadingLine.fillAmount;
        while (loadingLine.fillAmount < 1)
        {
            loadingLine.fillAmount += fillSpeed * Time.deltaTime;
            yield return null;
        }

        loadingLine.fillAmount = 1;

        Interract();
    }

    //CancelProcess
    public void CancelProcess()
    {
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
            fillCoroutine = null;
        }

        StartCoroutine(CancellationFloat());
    }

    public IEnumerator CancellationFloat()
    {
        loadingLine.fillAmount = loadingLine.fillAmount;
        while (loadingLine.fillAmount > 0)
        {
            loadingLine.fillAmount -= fillSpeed * 2f * Time.deltaTime;
            yield return null;
        }

        loadingLine.fillAmount = 0;
        fadeCoroutine = StartCoroutine(FadeImageCoroutine(0f));
    }

    private IEnumerator FadeImageCoroutine(float targetAlpha)
    {
        float fadeDuration = 0.4f;

        CanvasGroup canvasGroupBackground = loadingBackground.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroupLine = loadingBackground.GetComponent<CanvasGroup>();

        if (canvasGroupBackground == null || canvasGroupLine == null)
        {
            Debug.LogError("CanvasGroup component not found on Image");
            yield break;
        }

        float startAlphaBackground = canvasGroupBackground.alpha;
        float startAlphaLine = canvasGroupBackground.alpha;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            canvasGroupBackground.alpha = Mathf.Lerp(startAlphaBackground, targetAlpha, t);
            canvasGroupLine.alpha = Mathf.Lerp(startAlphaLine, targetAlpha, t);
            yield return null;
        }

        canvasGroupBackground.alpha = targetAlpha; // Устанавливаем точное целевое значение
    }
}
