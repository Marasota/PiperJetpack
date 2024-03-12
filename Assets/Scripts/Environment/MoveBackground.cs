using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private SpeedSystem _speedSystem;
    private Transform _backTransform;
    private float _backSize; 
    private float _backPos = 0f;
    void Start()
    {
        _backTransform = GetComponent<Transform>();
        _backSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        _backPos += _speedSystem.GetSpeed() * Time.deltaTime;
        _backPos = Mathf.Repeat(_backPos, _backSize);
        _backTransform.position = new Vector3(_backPos,0f , 50f);
    }
}
