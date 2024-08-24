using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab; 
    public Transform plane; 

    public float spawnDistance = 10f; 
    public float spawnInterval = 2f; 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnMissile), spawnInterval, spawnInterval); 
    }

    private void SpawnMissile()
    {
        // Plane objesinin yok olup olmadýðýný kontrol et
        if (plane == null)
        {
            Debug.LogWarning("Plane object has been destroyed. Stopping missile spawn.");
            CancelInvoke("SpawnMissile"); // Spawn iþlemini durdur
            return;
        }
        
        float randomAngle = Random.Range(0f, 360f);
        
        Vector2 spawnPosition = (Vector2)plane.position + (Vector2)(Quaternion.Euler(0, 0, randomAngle) * Vector2.up * spawnDistance);
        
        GameObject missile = Instantiate(missilePrefab, spawnPosition, Quaternion.identity);

        Obstacle obstacleScript = missile.GetComponent<Obstacle>(); 
        if (obstacleScript != null)
        {
            obstacleScript.target = plane; 
        }
        else
        {
            Debug.LogWarning("Missile prefab doesn't have an Obstacle script attached.");
        }
    }
}
