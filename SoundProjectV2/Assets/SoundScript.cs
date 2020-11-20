using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundScript : MonoBehaviour
{
    public bool Explosion;
    public bool Laser;
    public bool GameOver;
    public bool Coin;
    public bool Wind;

    
    public AudioSource ExplosionSource;
    public AudioSource LaserSource;
    public AudioSource GameOverSource;
    public AudioSource CoinSource;
    public AudioSource WindSource;
    
    /*
    public Transform ExplosionSource;
    public Transform LaserSource;
    public Transform GameOverSource;
    public Transform CoinSource;
    public Transform WindSource;
    */

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2f);
        
        ExplosionSource.enabled = false;
        LaserSource.enabled = false;
        GameOverSource.enabled = false;
        CoinSource.enabled = false;
        WindSource.enabled = false;
        
        Explosion = false;
        Laser = false;
        GameOver = false;
        Coin = false;
        Wind = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ExplosionSource.enabled = false;
        LaserSource.enabled = false;
        GameOverSource.enabled = false;
        CoinSource.enabled = false;
        WindSource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Explosion)
        {
            ExplosionSource.enabled = true;
            LaserSource.enabled = false;
            GameOverSource.enabled = false;
            CoinSource.enabled = false;
            WindSource.enabled = false;
            StartCoroutine(Stop());
        }
        else if (Laser)
        {
            LaserSource.enabled = true;
            ExplosionSource.enabled = false;
            GameOverSource.enabled = false;
            CoinSource.enabled = false;
            WindSource.enabled = false;
            StartCoroutine(Stop());
        }
        else if (GameOver)
        {
            GameOverSource.enabled = true;
            ExplosionSource.enabled = false;
            CoinSource.enabled = false;
            WindSource.enabled = false;
            LaserSource.enabled = false;
            StartCoroutine(Stop());
        }
        else if (Coin)
        {
            CoinSource.enabled = true;
            ExplosionSource.enabled = false;
            LaserSource.enabled = false;
            GameOverSource.enabled = false;
            //CoinSource.enabled = false;
            WindSource.enabled = false;
            StartCoroutine(Stop());
        }
        else if (Wind)
        {
            WindSource.enabled = true;
            ExplosionSource.enabled = false;
            LaserSource.enabled = false;
            GameOverSource.enabled = false;
            CoinSource.enabled = false;
            StartCoroutine(Stop());
        }
    }

    #region InputActions
    public void OnExplosion(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Explosion = true;
        }
    }

    public void OnLaser(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Laser = true;
        }
    }

    public void OnGameOver(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            GameOver = true;
        }
    }

    public void OnCoin(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Coin = true;
        }
    }

    public void OnWind(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Wind = true;
        }
    }

    public void OnCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            //ExplosionSource.enabled = false;
            //LaserSource.enabled = false;
            ///GameOverSource.enabled = false;
            //CoinSource.enabled = false;
            //WindSource.enabled = false;
        }
    }
    #endregion
}
