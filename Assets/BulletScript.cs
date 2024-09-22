using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _bulletMoveSpeed = 1f; //speed that the bullet travels


    private void Start()
    {
        this.gameObject.SetActive(false); //deactivate bullets as they spawn with the bullet item pool
    }

    private void OnEnable()
    {
        this.gameObject.GetComponent<Rigidbody2D>().totalForce = Vector2.zero; //reset bullet speed on enabled
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _bulletMoveSpeed); //start the bullet speed

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
