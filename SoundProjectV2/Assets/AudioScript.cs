using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource AS;
    public float Timer;
    public float Limit;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= Limit)
        {
            AS.enabled = true;
        }
    }
}
