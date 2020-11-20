using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float Speed;
    private float Timer;
    public float Limit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        transform.Translate(0, Speed * Time.deltaTime, 0);

        if (Timer >= Limit)
        {
            Destroy(gameObject);
        }
    }
}
