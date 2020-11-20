using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipScript : MonoBehaviour
{

    Vector2 Movement;
    public bool IsShooting;
    public Transform Laser;
    public Transform LaserSpawner;
    private Rigidbody2D RB;
    public float Speed;
    public float BulletForce;
    public Transform AudioClip;
    public Transform ExplosionClip;
    public Transform AudioPos;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    private int HeartNum;
    public string GameOver;

    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(0);
       // Instantiate(MuzzleFlash, MuzzleFlashPoint.position, MuzzleFlashPoint.rotation);
        Transform BulletPrefab = Instantiate(Laser, LaserSpawner.position, LaserSpawner.rotation);
        Instantiate(AudioClip, LaserSpawner.position, LaserSpawner.rotation);

        Rigidbody2D BulletRB = BulletPrefab.GetComponent<Rigidbody2D>();
        BulletRB.AddForce(LaserSpawner.up * BulletForce, ForceMode2D.Impulse);
        StopAllCoroutines();
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        #region Up and Down
        if (IsCentered && !IsUp && !IsDown && UpButton)
        {
            transform.position = UpPos.position;
            IsUp = true;
            IsCentered = false;
            IsDown = false;
            DownButton = false;
        }
        else if (!IsUp && !IsDown && DownButton)
        {
            transform.position = DownPos.position;
            IsDown = true;
            IsCentered = false;
            IsUp = false;
            UpButton = false;
        }
        #endregion

        #region Centered
        if (IsUp && DownButton)
        {
            transform.position = CenterPos.position;
            IsDown = false;
            IsUp = false;
            IsCentered = true;
            UpButton = false;
            DownButton = true;
        }

        if (IsDown && UpButton)
        {
            transform.position = DownPos.position;
            IsUp = false;
            IsDown = false;
            IsCentered = true;
            UpButton = true;
            DownButton = false;
        }
        #endregion
        */
        RB.velocity = new Vector2(0, Movement.y) * Speed * Time.deltaTime;
        if (IsShooting)
        {
            StartCoroutine(StartShooting());
            
            //Instantiate(Laser, LaserSpawner.position, LaserSpawner.rotation);
            IsShooting = false;
        }


        if(HeartNum == 2)
        {
            Heart3.enabled = false;
        }
        else if (HeartNum == 1)
        {
            Heart2.enabled = false;
        }
        else if (HeartNum == 0)
        {
            SceneManager.LoadScene(GameOver);
        }
    }

    #region InputActions
    public void OnShoot(InputAction.CallbackContext ctx)
    {
        IsShooting = true;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnMoveUp(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            //UpButton = true;
        }
    }

    public void OnMoveDown(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            //DownButton = true;
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            HeartNum--;
            Instantiate(ExplosionClip, AudioPos.position, AudioPos.rotation);
        }
    }

}
