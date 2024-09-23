using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _bulletMoveSpeed = 1f; //speed that the bullet travels
    private GameObject _player;


    private void Start()
    {
        this.gameObject.SetActive(false); //deactivate bullets as they spawn with the bullet item pool
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetBulletSpeed(float m_speed)
    {
        _bulletMoveSpeed = m_speed;
    }
    private void OnEnable()
    {
       var mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
       var object_pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        var angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        this.gameObject.GetComponent<Rigidbody2D>().totalForce = Vector2.zero; //reset bullet speed on enabled
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.right * _bulletMoveSpeed); //start the bullet speed

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit something");
        if (other.CompareTag("Wall"))
        {
            Debug.Log("hit wall");

            this.gameObject.SetActive(false);
            _player.GetComponent<PlayerScript>().BulletDied(this.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            other.GetComponent<BoxScript>().ExplodeBox();
            this.gameObject.SetActive(false);
            _player.GetComponent<PlayerScript>().BulletDied(this.gameObject);
        }
    }
}
