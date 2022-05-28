using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] int damage;
    public int Damage { get { return damage; } }

    [SerializeField] int speed;

    [SerializeField] bool isEnemy;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ShootDirection();
    }

    void OnEnable()
    {
        StartCoroutine(DisableObject(5));
    }

    IEnumerator DisableObject(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    void ShootDirection()
    {
        if (isEnemy)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = -transform.up * speed;
        }
    }

    public void OnHit()
    {
        gameObject.SetActive(false);
    }
}
