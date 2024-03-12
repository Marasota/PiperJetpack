using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboBombsController : MonoBehaviour
{
    [SerializeField] private ObjectPoller _poller;
    [SerializeField] private Transform _roboPos;
    private string[] tags = { "DefaultB", "DefaultB", "DefaultB", "DefaultB", "Double","Double", "Double","Trible", "Trible", "Lol" };

    int timing = 0;
    int currentTag = 0;
    int maxTag;
    bool isReady = true;

    void Start()
    {
        maxTag = tags.Length;
    }


    void Update()
    {
        if (isReady)
        {
            isReady = false;
            currentTag = Random.Range(0, maxTag);
            timing = Random.Range(4, 8);
            Invoke("SpawnCake", timing);
        }
    }

    public void SpawnCake()
    {
        _poller.GetObjectFromPool(tags[currentTag], new Vector2(_roboPos.position.x, Random.Range(-2.7f, 5.3f)), _roboPos.rotation);
        isReady = true;
    }
}
