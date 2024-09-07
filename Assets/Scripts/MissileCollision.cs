using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public GameObject PlaneExplosionPrefab; 
    public GameOverManager gameOverManager;
    public static Action<Vector3> MissileBetweenCrashEvent;

    private void Start()
    {
        if (gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOverManager>(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            MissileBetweenCrashEvent.Invoke(transform.position);             
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }

        if (collision.gameObject.CompareTag("Plane"))
        {            
            Destroy(collision.gameObject);
            Destroy(gameObject);            
            GameOverManager.GameOverEvent.Invoke(transform.position);
        }
    }

    

}
