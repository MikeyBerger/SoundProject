using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChnageScene : MonoBehaviour
{
    public float SceneTimer;
    public float SceneLimit;
    //public float SoundTimer;
    //public float SoundLimit;
    public string Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneTimer += Time.deltaTime;
        //SoundTimer += Time.deltaTime;
        if (SceneTimer >= SceneLimit)
        {
            SceneManager.LoadScene(Tutorial);
        }


    }
}
