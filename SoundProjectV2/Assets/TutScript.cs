using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutScript : MonoBehaviour
{
    private bool ButtonPressed;
    public string LevelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonPressed)
        {
            SceneManager.LoadScene(LevelName);
        }
    }

    public void OnButton(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            ButtonPressed = true;
        }
    }
}
