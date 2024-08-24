using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public GameObject PlaneExplosionPrefab; //1 dependency

    public GameOverManager gameOverManager;
    public static Action<Vector3> MissileBetweenCrashEvent;

    private void Start()
    {
        if (gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOverManager>(); // Sahnede bulunan GameOverManager'i bulup ata
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            MissileBetweenCrashEvent.Invoke(transform.position); //event tetiklendi            
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }

        if (collision.gameObject.CompareTag("Plane"))
        {            
            GameOverManager.GameOverEvent.Invoke(transform.position);
            Destroy(collision.gameObject);
            Destroy(gameObject);            
        }
    }

    

}
