using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float Speed;
    public Transform BG;
    public Transform BGSpawner;

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(25f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BackGround")
        {
            Instantiate(BG, BGSpawner.position, BGSpawner.rotation);
            StartCoroutine(Disable());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BackGround")
        {
            Instantiate(BG, BGSpawner.position, BGSpawner.rotation);
            StartCoroutine(Disable());
        }
    }
}
