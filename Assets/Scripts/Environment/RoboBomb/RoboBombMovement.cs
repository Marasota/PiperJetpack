using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboBombMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private string[] triggers = { "Idle", "Idle", "Idle", "Spin", "Spin", "Spin2" };

    void Start()
    {
        _speed = GameObject.Find("SpeedSystem").GetComponent<SpeedSystem>().GetSpeed();
        var rand = Random.Range(0,6);

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Animator>().SetTrigger(triggers[rand]);
        }
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime, transform.position.y, 0f);
    }
}
