using UnityEngine;

public class EaseInBounce : MonoBehaviour
{
    [SerializeField] private float jumpHight;
    [SerializeField] private int numberOfBounces;
    [SerializeField] private float fallingSpeed;

    private Vector3 _startPos;
    private bool _checkUp;
    private int _countTimes;
    private float _hightbuf;
    private float _speedbuf;
    
    [HideInInspector] public bool easeBounceEnd;
    
    private void Start()
    {
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (easeBounceEnd)
            EaseInBounceEffect();
    }

    public void TurnOnEaseBounceEffect()
    {
        easeBounceEnd = true;
        _checkUp = false;
        _speedbuf = fallingSpeed;
        _hightbuf = jumpHight;
        _countTimes = 0;
    }
    
    private void EaseInBounceEffect()
    {
        if (!_checkUp)
        {
            if (transform.position.y <= (_startPos.y + _hightbuf))
                transform.position = Vector2.MoveTowards(transform.position, 
                    new Vector2(_startPos.x, transform.position.y) + (Vector2.up * _hightbuf),
                    _speedbuf * Time.fixedDeltaTime);
            else
                _checkUp = true;
        }
        else if (numberOfBounces != _countTimes)
        {
            if (transform.position.y > _startPos.y)
                transform.position = Vector2.MoveTowards(transform.position, 
                    _startPos, _speedbuf * Time.fixedDeltaTime);
            else
            {
                _countTimes++;
                _checkUp = false;
                _speedbuf /= 1.5f;
                _hightbuf *= 1.5f;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _startPos, _speedbuf * Time.fixedDeltaTime);
            if (transform.position.y <= _startPos.y)
                easeBounceEnd = false;
        }
    }
}
