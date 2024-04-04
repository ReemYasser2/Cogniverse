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

    [SerializeField] float speed;
    float targetFillAmount = 0.6f;

    public void onClick()
    {
        StartCoroutine(AnimateFill(highAccuracyImage, highAccuracyText, targetFillAmount));
        StartCoroutine(AnimateFill(lastAccuracyImage, lastAccuracyText, targetFillAmount));
        StartCoroutine(AnimateFill(highScoreImage, highScoreText, targetFillAmount));
        StartCoroutine(AnimateFill(lastScoreImage, lastScoreText, targetFillAmount));
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
