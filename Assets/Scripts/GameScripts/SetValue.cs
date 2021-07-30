using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetValue : MonoBehaviour
{
    [SerializeField] private GameObject squareMain;
    [SerializeField] private GetData gameData;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private GameObject bagroundGameObject;
    public int nMatrixRaw;
    public int mMatrixCol;
    public FadeInEffect fadeInEffect;
    public FadeInEffectImage fadeInEffectImage;
    
    [HideInInspector] public List<CardData> cardDatas;
    [HideInInspector] public List<CardData> forQuestionCardData;
    [HideInInspector] public CardData questionData;
    [HideInInspector] public bool startButton;
    [HideInInspector] public int levelCount;
    [HideInInspector] public bool initStat;
    [HideInInspector] public bool gameOver;
    [HideInInspector] public bool compareAnswerRes;
    
    private GameObject[][] _squareArray;
    private SpriteRenderer[][] _spriteRenderers;
    private List<CardData> _questionsUsed;
    private SetValueFuncs _setValueFuncs;
    private bool _nonActive;

    private void Awake()
    {
        _spriteRenderers = new SpriteRenderer[nMatrixRaw][];
        _setValueFuncs = new SetValueFuncs();
        _nonActive = false;
    }
    
    private void Update()
    {
        if (!_nonActive && startButton)
        {
            initStat = InitObjects();
            _nonActive = true;
        }
    }
    
    private bool InitObjects()
    {
        float coef = 0.0f;
        var orthographicSize = Camera.main.orthographicSize;
        var localScale = bagroundGameObject.transform.localScale;
        var scale = squareMain.transform.localScale;
        float cameraScale = orthographicSize + nMatrixRaw - 2;
        
        localScale = new Vector3(localScale.x + ((cameraScale - orthographicSize) * 0.25f),
            localScale.y + ((cameraScale - orthographicSize) * 0.25f), 1);
        bagroundGameObject.transform.localScale = localScale;
        orthographicSize = cameraScale;
        Camera.main.orthographicSize = orthographicSize;
        Vector2 spawnVector = new Vector2(-(scale.x * (int)(nMatrixRaw/2) + coef),
            scale.y * (int)(mMatrixCol/2) + coef);
        
        _squareArray = GenerateMatrix.MatrixGenerate(squareMain, spawnVector, GetComponent<SetValue>(), nMatrixRaw, mMatrixCol, coef);
        for (int i = 0; i < nMatrixRaw; i++)
        {
            _spriteRenderers[i] = new SpriteRenderer[mMatrixCol];
            _spriteRenderers[i] = GenerateMatrix.GetSpriteRendererFromGMArray(_squareArray[i]);
        }
        _questionsUsed = new List<CardData>();
        return true;
    }
    
    public void SetValueToImages(int level)
    {
        forQuestionCardData = new List<CardData>();
        cardDatas = new List<CardData>(gameData.CardData);
        for (int i = 0; i < levelCount; i++)
        {
            _setValueFuncs.SetToImage(_spriteRenderers[i], cardDatas, forQuestionCardData);
            _setValueFuncs.TurnOnAndOF(_squareArray[i], true);
            if (level == 1)
                _setValueFuncs.BounceEffectTurnOn(_squareArray[i]);
        }
        questionData = _setValueFuncs.QuestionRandom(_questionsUsed, forQuestionCardData, questionText, fadeInEffect);
    }

    public void RestartGame()
    {
        questionText.text = "";
        if (_squareArray != null)
        {
            foreach (GameObject[] gmArr in _squareArray)
                _setValueFuncs.TurnOnAndOF(gmArr,false);
        }
    }
}
