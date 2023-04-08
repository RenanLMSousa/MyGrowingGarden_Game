using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    public Cloud cloud;

    public List<Sprite> cloudList;

    public float SpawnTime;

    public float minSpeed;
    public float maxSpeed;

    public float minSize;
    public float maxSize;


    private float timeSinceLastSpawn = 0;

    private void Start()
    {
        SpawnCloud();
    }
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        
        if(timeSinceLastSpawn >= SpawnTime)
        {
            SpawnCloud();
        
        }
    }
    void SpawnCloud()
    {
        Cloud cloud = Instantiate(this.cloud);
        cloud.transform.position = this.transform.position;
        float speed = Random.Range(minSpeed, maxSpeed);
        cloud.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;
        cloud.GetComponent<SpriteRenderer>().sprite = cloudList[Random.Range(0, cloudList.Count - 1)];
        cloud.GetComponent<SpriteRenderer>().sortingOrder = -2;
        cloud.transform.localScale = new Vector3(1, 1, 1) * Random.Range(minSize, maxSize);
        cloud.transform.SetParent(this.transform);
        timeSinceLastSpawn = 0;
    }

}

