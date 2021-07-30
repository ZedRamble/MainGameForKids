using UnityEngine;
using Random = UnityEngine.Random;

public class SquareScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetSquare;
    [SerializeField] private SpriteRenderer backgroundSquare;
    [SerializeField] private GameObject particleSystemGameObject;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private BounceEffect bounceTarget;
    [SerializeField] private EaseInBounce easeInBounce;
    
    [HideInInspector] public SetValue setValue;
    
    private void Awake()
    {
        RandomBgColor();
    }

    private void OnMouseDown()
    {
        if (!setValue.gameOver)
        {
            setValue.compareAnswerRes = GetAnswer(targetSquare.sprite.name);
            if (!setValue.compareAnswerRes)
            {
                easeInBounce.TurnOnEaseBounceEffect();
            }
            else
            {
                bounceTarget.TurnOnBounceEffect();
                particleSystemGameObject.SetActive(true);
                particleSystem.Play();
                DoIfAnswerTrue();
            }
        }
    }

    private void DoIfAnswerTrue()
    {
        if (setValue.levelCount < setValue.nMatrixRaw)
        {
            setValue.levelCount++;
            setValue.SetValueToImages(setValue.levelCount);
        }
        else
            setValue.gameOver = true;
        setValue.compareAnswerRes = false;
    }
    
    private void RandomBgColor()
    {
        float r = Random.Range(0.6f, 2);
        float g = Random.Range(0.6f, 2);
        float b = Random.Range(0.6f, 2);
        backgroundSquare.color = new Color(r, g, b, 1);
    }
    
    private bool GetAnswer(string name)
    {
        if (setValue.questionData.Identifier.ToLower() == name.ToLower())
            return true;
        return false;
    }
}
