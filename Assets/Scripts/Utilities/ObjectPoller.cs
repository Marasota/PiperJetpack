using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoller : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int size;
    }
    public static ObjectPoller Instanse;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDctnry;
    private void Awake()
    {
        Instanse = this;
    }
    private void Start()
    {
        poolDctnry = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> queueOfObjects = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                queueOfObjects.Enqueue(obj);
            }
            poolDctnry.Add(pool.Tag, queueOfObjects);
        }
    }
    public GameObject GetObjectFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDctnry.ContainsKey(tag))
        {
            print("Неправильно введён тэг");
            //return null;
        }
        GameObject gameObjectToSpawn = poolDctnry[tag].Dequeue();
        gameObjectToSpawn.SetActive(true);
        gameObjectToSpawn.transform.position = position;
        gameObjectToSpawn.transform.rotation = rotation;
        poolDctnry[tag].Enqueue(gameObjectToSpawn);
        return gameObjectToSpawn;
    }
}
