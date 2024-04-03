using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RadialProgress : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Image image;
    [SerializeField] float speed;
    float targetFillAmount = 0.6f;

    public void onClick()
    {
        StartCoroutine(AnimateFill());
    }

    IEnumerator AnimateFill()
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
