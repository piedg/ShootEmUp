using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int scoreValue;

    [Header("Missile Settings")]
    [SerializeField] float fireRate = 0.5f;
    float nextFire = 0.0f;
    Vector3 missilePos;

    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    GameObject enemyPoolObj;
    ObjectPool enemyMissilePool;

    private void Awake()
    {
        enemyPoolObj = GameObject.FindGameObjectWithTag("EnemyMissilePool");
        enemyMissilePool = enemyPoolObj.GetComponent<ObjectPool>();
    }

    void FixedUpdate()
    {
        if (Time.fixedTime > nextFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFire = Time.fixedTime + GetRandomSpawnTime();

        GameObject missile = enemyMissilePool.GetObjectFromPool();
        AudioController.Instance.PlayShootAudio();

        //Set missile transform
        missilePos.Set(transform.position.x, 0f, transform.position.z - 5f);
        missile.transform.SetPositionAndRotation(missilePos, Quaternion.LookRotation(Vector3.up));

        //Active from Pool
        missile.SetActive(true);
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(fireRate - spawnTimeVariance, fireRate + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
