using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    [SerializeField] private float jumpHight;
    [SerializeField] private int numberOfBounces;
    [SerializeField] private float fallingSpeed;
    
    private Vector3 _startPos;
    private bool _checkUp;
    private int _countTimes;
    private float _hightbuf;
    private float _speedbuf;
    private float _infelicityOfFallen;
    
    [HideInInspector] public bool bounceEnd;
    private void Awake()
    {
        _infelicityOfFallen = 0.07200003f;
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (bounceEnd)
            BounceEffectFunc();
    }

    public void TurnOnBounceEffect()
    {
        bounceEnd = true;
        _checkUp = false;
        _speedbuf = fallingSpeed;
        _hightbuf = jumpHight;
        _countTimes = 0;
    }
    
    private void BounceEffectFunc()
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
                _speedbuf *= 1.2f;
                _hightbuf /= 2;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                _startPos, _speedbuf * Time.fixedDeltaTime);
            if (transform.position.y <= _startPos.y)
            {
                if (transform.position.y < _startPos.y)
                    transform.position = new Vector3(_startPos.x,_startPos.y + _infelicityOfFallen, _startPos.z);
                bounceEnd = false;
            }
        }
    }
}
