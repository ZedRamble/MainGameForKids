using UnityEngine;
using UnityEngine.UI;

public class ButtonFuncs : MonoBehaviour
{
    [SerializeField] private GameObject winPanel; 
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Color endColor;
    
    private bool _startButton;
    private bool _restartButton;
    private bool _winPanelActive;
    private float _fadeSpeed;
    private SetValue _setValue;
    private LoadingPanel _loadingPanelFunc;
    
    private void Awake()
    {
        _fadeSpeed = 1 / 2.4f;
        _loadingPanelFunc = loadingPanel.GetComponent<LoadingPanel>();
        _setValue = GetComponent<SetValue>();
    }
    
    private void Update()
    {
        if (_setValue.initStat && _setValue.startButton)
            FirstInit();
        if (_setValue.gameOver && !_winPanelActive)
            GameOverFunc();
        if (_loadingPanelFunc.loadingOver && _restartButton)
            LoadingPanelFunc();
    }

    private void FirstInit()
    {
        _setValue.initStat = false;
        _setValue.levelCount = 1;
        _setValue.SetValueToImages(_setValue.levelCount);
    }

    private void GameOverFunc()
    {
        winPanel.SetActive(true);
        Image image = winPanel.GetComponent<Image>();
        _setValue.fadeInEffectImage.SetFadeValueImage(image, Color.clear, endColor, _fadeSpeed);
        _winPanelActive = true;
    }

    private void LoadingPanelFunc()
    {
        _setValue.levelCount = 0;
        _setValue.startButton = true;
        _setValue.initStat = true;
        _setValue.gameOver = false;
        _winPanelActive = false;
        _restartButton = false;
        loadingPanel.SetActive(false);
        _loadingPanelFunc.loadingOver = false;
        _loadingPanelFunc.checkLoading = false;
    }
    
    public void StartButton()
    {
        _setValue.startButton = true;
    }

    public void RestartButton()
    {
        _restartButton = true;
        winPanel.SetActive(false);
        _setValue.RestartGame();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
