using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public Vector3 initalPos;
    float horizontalInput, verticalInput;
    [SerializeField] float moveSpeed;

    [Header("Missile Settings")]
    [SerializeField] float fireRate = 0.5f;
    float nextFire = 0.0f;

    Vector3 missilePos;
    Rigidbody rb;

    GameObject playerPoolObj;
    ObjectPool playerMissilePool;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerPoolObj = GameObject.FindGameObjectWithTag("PlayerMissilePool");
        playerMissilePool = playerPoolObj.GetComponent<ObjectPool>();
    }

    private void Start()
    {
        initalPos = transform.position;
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        Movement(horizontalInput);
        Shoot();
    }

    void Movement(float _input)
    {
        rb.velocity = Vector3.right * _input * moveSpeed;
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.fixedTime > nextFire)
        {
            nextFire = Time.fixedTime + fireRate;

            GameObject missile = playerMissilePool.GetObjectFromPool();

            //Set missile 
            missilePos.Set(transform.position.x, 0f, -15f);
            missile.transform.SetPositionAndRotation(missilePos, Quaternion.LookRotation(Vector3.up));

            //Active from Pool
            missile.SetActive(true);

            AudioController.Instance.PlayShootAudio();
        }
    }
}
