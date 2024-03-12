using UnityEngine;

public class CakeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    public int partyCount;
    void Start()
    {
        _speed = GameObject.Find("SpeedSystem").GetComponent<SpeedSystem>().GetSpeed();
       // SpeedSystem.OnSpeedChanged += OnSpeedChanged;
        partyCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime, transform.position.y, 0f);
    }

    public void Decrease()
    {
        if (--partyCount <=0)
        {
            Revival();
        };
        
    }

    public void Revival()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        partyCount = transform.childCount;
        gameObject.SetActive(false);
    }

   /* private void OnSpeedChanged(float newSpeed)
    {
        _speed = newSpeed;
    }*/
}
