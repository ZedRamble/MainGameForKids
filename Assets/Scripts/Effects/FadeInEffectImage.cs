using UnityEngine;
using UnityEngine.UI;

public class FadeInEffectImage : MonoBehaviour
{
    private float _speed;
    private float _countTime;
    private bool _doneText;
    private Image _imageM ;
    private Color _startColor;
    private Color _endColor;
    private bool _fadeImage;
    private float _maxTime;
    
    private void Awake()
    {
        _maxTime = 3;
    }
    
    private void Update()
    {
        if (_doneText && _fadeImage)
            ImageLerpFunc();
    }
    
    public void SetFadeValueImage(Image image, Color startColor, Color endColor, float speed)
    {
        _imageM = image;
        _startColor = startColor;
        _endColor = endColor; 
        _speed = speed;
        _fadeImage = true;
        _countTime = 0;
        _doneText = true;
    }
    
    private void ImageLerpFunc()
    {
        if (_countTime <= _maxTime)
        {
            _imageM.color = Color32.Lerp(_startColor, _endColor, _countTime);
            _countTime += Time.deltaTime * _speed;
        }
        else
        {
            _fadeImage = false;
            _doneText = false;
        }
    }
}
