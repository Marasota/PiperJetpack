using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakesController : MonoBehaviour
{
    [SerializeField] private ObjectPoller _poller;
    [SerializeField] private Transform _muffinPos;
    private string []tags  = {"Default", "Default", "Default", "Adult", "Adult", "Heart", "Star", "Star", "Pyramid", "Pyramid" };

    int timing = 0;
    int currentTag = 0;
    int maxTag;
    bool isReady = true;

    void Start()
    {
        maxTag = tags.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            isReady = false;
            currentTag = Random.Range(0, maxTag);
            timing = Random.Range(2, 6);
            Invoke("SpawnCake", timing);
        }
    }

    public void SpawnCake()
    {
        _poller.GetObjectFromPool(tags[currentTag], new Vector2(_muffinPos.position.x,Random.Range(-2.7f,5.3f)), _muffinPos.rotation);
        isReady = true;
    }
}
