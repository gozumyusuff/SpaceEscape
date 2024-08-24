using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private GameObject MissileExplosionPrefab;
    [SerializeField] private GameObject MissilePlanePrefab;

    private void OnEnable()
    {
        MissileCollision.MissileBetweenCrashEvent += CreateMissileExplosion;
        GameOverManager.GameOverEvent += CreatePlaneExplosion;
    }
    private void OnDisable()
    {
        MissileCollision.MissileBetweenCrashEvent -= CreateMissileExplosion;
        GameOverManager.GameOverEvent -= CreatePlaneExplosion;
    }

    private void CreateMissileExplosion(Vector3 position)
    {
        CreateVFX(MissileExplosionPrefab, position);
    }
    private void CreatePlaneExplosion(Vector3 position)
    {
        CreateVFX(MissilePlanePrefab, position);
    }
    private void CreateVFX(GameObject prefab,Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

}
