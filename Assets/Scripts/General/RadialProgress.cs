using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RadialProgress : MonoBehaviour
{
    [SerializeField] TMP_Text highAccuracyText;
    [SerializeField] Image highAccuracyImage;
    [SerializeField] TMP_Text lastAccuracyText;
    [SerializeField] Image lastAccuracyImage;
    
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] Image highScoreImage;
    [SerializeField] TMP_Text lastScoreText;
    [SerializeField] Image lastScoreImage;

    [SerializeField] TMP_Text lastRTGOText;
    [SerializeField] TMP_Text highRTGOText;
    [SerializeField] TMP_Text lastRTNOGOText;
    [SerializeField] TMP_Text highRTNOGOText;

    public GameObject RTcanvase;
    [SerializeField] float speed;

    public void ShowDualStat()
    {
        StartCoroutine(AnimateFill(highAccuracyImage, highAccuracyText, DatabaseGamesVariables.highestAccuracyDual));
        StartCoroutine(AnimateFill(lastAccuracyImage, lastAccuracyText, DatabaseGamesVariables.lastAccuracyDual));
        StartCoroutine(AnimateFill(highScoreImage, highScoreText, DatabaseGamesVariables.highestScoreDual));
        StartCoroutine(AnimateFill(lastScoreImage, lastScoreText, DatabaseGamesVariables.lastScoreDual));

        RTcanvase.SetActive(true);

        lastRTGOText.text = "Latest Go Response Time: " + Mathf.Round(DatabaseGamesVariables.lastGoRTDual * 100f) / 100f;
        highRTGOText.text = "Lowest Go Response Time: " + Mathf.Round(DatabaseGamesVariables.highestGoRTDual * 100f) / 100f;
        lastRTNOGOText.text = "Latest No Go Response Time: " + Mathf.Round(DatabaseGamesVariables.lastNoRTDual * 100f) / 100f;
        highRTNOGOText.text = "Lowest No Go Response Time: " + Mathf.Round(DatabaseGamesVariables.highestNoRTDual * 100f) / 100f;
    }

    public void ShowTrailStat()
    {
        StartCoroutine(AnimateFill(highAccuracyImage, highAccuracyText, DatabaseGamesVariables.highestAccuracyTrail));
        StartCoroutine(AnimateFill(lastAccuracyImage, lastAccuracyText, DatabaseGamesVariables.lastAccuracyTrail));
        StartCoroutine(AnimateFill(highScoreImage, highScoreText, DatabaseGamesVariables.highestScoreTrail));
        StartCoroutine(AnimateFill(lastScoreImage, lastScoreText, DatabaseGamesVariables.lastScoreTrail));

        RTcanvase.SetActive(false);
    }

    public void ShowFocusStat()
    {
        StartCoroutine(AnimateFill(highAccuracyImage, highAccuracyText, DatabaseGamesVariables.highestAccuracyFF));
        StartCoroutine(AnimateFill(lastAccuracyImage, lastAccuracyText, DatabaseGamesVariables.lastAccuracyFF));
        StartCoroutine(AnimateFill(highScoreImage, highScoreText, DatabaseGamesVariables.highestScoreFF));
        StartCoroutine(AnimateFill(lastScoreImage, lastScoreText, DatabaseGamesVariables.lastScoreFF));

        RTcanvase.SetActive(true);

        lastRTGOText.text = "Latest Go Response Time: " + Mathf.Round(DatabaseGamesVariables.lastGoRTFF * 100f) / 100f;
        highRTGOText.text = "Lowest Go Response Time: " + Mathf.Round(DatabaseGamesVariables.highestGoRTFF * 100f) / 100f;
        lastRTNOGOText.text = "Latest No Go Response Time: " + Mathf.Round(DatabaseGamesVariables.lastNoRTFF * 100f) / 100f;
        highRTNOGOText.text = "Lowest No Go Response Time: " + Mathf.Round(DatabaseGamesVariables.highestNoRTFF * 100f) / 100f;
    }
    
    public void ShowWhackStat()
    {
        StartCoroutine(AnimateFill(highAccuracyImage, highAccuracyText, DatabaseGamesVariables.highestAccuracyWhack));
        StartCoroutine(AnimateFill(lastAccuracyImage, lastAccuracyText, DatabaseGamesVariables.lastAccuracyWhack));
        StartCoroutine(AnimateFill(highScoreImage, highScoreText, DatabaseGamesVariables.highestScoreWhack));
        StartCoroutine(AnimateFill(lastScoreImage, lastScoreText, DatabaseGamesVariables.lastScoreWhack));

        RTcanvase.SetActive(true);

        lastRTGOText.text = "Latest Go Response Time: " + Mathf.Round(DatabaseGamesVariables.lastGoRTWhack * 100f) / 100f;
        highRTGOText.text = "Lowest Go Response Time: " + Mathf.Round(DatabaseGamesVariables.highestGoRTWhack * 100f) / 100f;
        lastRTNOGOText.text = "Latest No Go Response Time: " + Mathf.Round(DatabaseGamesVariables.lastNoRTWhack * 100f) / 100f;
        highRTNOGOText.text = "Lowest No Go Response Time: " + Mathf.Round(DatabaseGamesVariables.highestNoRTWhack * 100f) / 100f;
    }

    IEnumerator AnimateFill(Image image, TMP_Text text, float targetFillAmount)
    {
        float currentFillAmount = 0f;

        while (currentFillAmount < targetFillAmount)
        {
            currentFillAmount += speed * Time.deltaTime;
            image.fillAmount = currentFillAmount;
            text.text = Mathf.RoundToInt(currentFillAmount * 100) + "%";
            yield return null;
        }

        // Ensure the fill amount is exactly the target value
        image.fillAmount = targetFillAmount;
        text.text = Mathf.RoundToInt(targetFillAmount * 100) + "%";
    }
}
