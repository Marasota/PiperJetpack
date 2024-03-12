using UnityEngine;

public class SpeedSystem : MonoBehaviour
{

   /* public delegate void SpeedChanged(float newSpeed);
    public static event SpeedChanged OnSpeedChanged;*/

    [SerializeField]
    private float _startSpeed;


    private float _commonSpeed = 0;



    private void Awake()
    {
        SetSpeed(_startSpeed);
    }

    private void Start()
    {
       // _startSpeed = _commonSpeed;
    }

    public float GetStartSpeed()
    {
        return _startSpeed;
    }
    public float GetSpeed()
    {
        return _commonSpeed;
    }

    public void SetSpeed(float speed)
    {
        _commonSpeed = speed;
       // OnSpeedChanged(_commonSpeed);
    }
    public void SpeedUp(float boost)
    {
        _commonSpeed += boost;
     //   OnSpeedChanged(_commonSpeed);
    }
}
