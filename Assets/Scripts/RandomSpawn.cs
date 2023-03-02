using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject[] SpawnObjects;
    float RandX;
    int randomOption;
    public float delay = 5f;
    public float speed = 3f;
    float nextTimeToSpawn;
    Vector3 whereToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        nextTimeToSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTimeToSpawn){
            nextTimeToSpawn = Time.time + delay;
            RandX = Random.Range(-20f, 20f);
            whereToSpawn = new Vector3(RandX, -17.9f, 350);
            randomOption = Random.Range(0, SpawnObjects.Length);
            GameObject go = Instantiate(SpawnObjects[randomOption], whereToSpawn, Quaternion.identity);
            go.AddComponent<Move>();
            go.GetComponent<Move>().speed = speed;
        }
    }
}
public class Move : MonoBehaviour{
    public float speed;

    void Update(){
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }
}




