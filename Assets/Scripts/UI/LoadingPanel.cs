using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] private FadeInEffect fadeInEffect;
    [SerializeField] private FadeInEffectImage fadeInEffectImage;
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private Image image;
    
    [HideInInspector] public bool checkLoading;
    [HideInInspector] public bool loadingOver;
    
    private Color _startColorText = Color.black;
    private Color _startColorImage = Color.white;
    private Color _endColor = Color.clear;
    private void OnEnable()
    {
        fadeInEffectImage.SetFadeValueImage(image, _startColorImage, _endColor, 1/2.3f);
        fadeInEffect.SetFadeValueText(tmpText, _startColorText, _endColor,1/2.3f);
    }

    private void Update()
    {
        if (tmpText.color == _endColor && !checkLoading)
        {
            loadingOver = true;
            checkLoading = true;
        }
    }
}
