using TMPro;
using UnityEngine;

public class FadeInEffect : MonoBehaviour
{
    private float _speed;
    private float _countTime;
    private bool _doneText;
    private TMP_Text _tmpText;
    private Color _startColor;
    private Color _endColor;
    private bool _fadeText;
    private float _maxTime;

    private void Awake()
    {
        _maxTime = 3;
    }

    private void Update()
    {   
        if (_doneText && _fadeText)
            TextLerpFunc();
    }

    public void SetFadeValueText(TMP_Text tmpText, Color startColor, Color endColor, float speed)
    {
        _tmpText = tmpText;
        _startColor = startColor;
        _endColor = endColor;
        _speed = speed;
        _fadeText = true;
        _countTime = 0;
        _doneText = true;
    }
    
    private void TextLerpFunc()
    {
        if (_countTime <= _maxTime)
        {
            _tmpText.color = Color32.Lerp(_startColor, _endColor, _countTime);
            _countTime += Time.deltaTime * _speed;
        }
        else
        {
            _fadeText = false;
            _doneText = false;
        }
    }
}
