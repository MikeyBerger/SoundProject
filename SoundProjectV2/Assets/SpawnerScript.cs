using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public Transform Asteroid;
    public Transform Coin;
    public float Timer;
    public float Limit;
    public float Seconds;
    private int RandNum;

    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(Seconds);
        Instantiate(Coin, transform.position, transform.rotation);
        StopAllCoroutines();
    }

    IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(Seconds);
        Instantiate(Asteroid, transform.position, transform.rotation);
        StopAllCoroutines();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandNum = Random.Range(0, 100);
        Timer += Time.deltaTime;
        if (Timer >= Limit && RandNum < 50)
        {
            //Instantiate(Coin, transform.position, transform.rotation);
            StartCoroutine(SpawnCoin());
            Timer = 0;
        }
        else if (Timer <= 50)
        {
            //Instantiate(Asteroid, transform.position, transform.rotation);
            StartCoroutine(SpawnAsteroid());
            Timer = 0;
        }

    }
}
