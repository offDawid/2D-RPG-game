using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Text levelText;
    private Image expBarImage;

    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        expBarImage = transform.Find("bar").GetComponent<Image>();
        SetExpBarSize(.5f);
        SetLevel(8);
    }

    private void SetExpBarSize(float expNormalized)
    {
        expBarImage.fillAmount = expNormalized;
    }

    private void SetLevel(int levelNumber)
    {
        levelText.text = "" + (levelNumber);
    }
}
