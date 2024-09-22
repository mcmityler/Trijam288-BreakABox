using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 _moveDir = new Vector3(0, 0, 0);
    [SerializeField] float _moveSpeed = 2f;

    private int _numberOfBullets = 30;

    [SerializeField] private GameObject _bulletSpawnField;
    [SerializeField] private GameObject _bulletObject;

    private List<GameObject> _activeBullets = new List<GameObject>();
    private List<GameObject> _inactiveBullets = new List<GameObject>();

    private void Awake()
    {
        InitBullets();
    }

    void InitBullets()
    {
        //spawn bullet pool
        for (int i = 0; i < _numberOfBullets; i++)
        {
            GameObject m_newBullet = Instantiate(_bulletObject, _bulletSpawnField.transform); //spawn new bullet 
            _inactiveBullets.Add(m_newBullet); //add new bullet to inactive bullet list to spawn later
        }
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A)) //LEFT
        {
            _moveDir = new Vector3(-1, _moveDir.y, 0);
        }
        if (Input.GetKey(KeyCode.D)) //RIGHT
        {
            _moveDir = new Vector3(1, _moveDir.y, 0);
        }
        if (Input.GetKey(KeyCode.S)) //DOWN
        {
            _moveDir = new Vector3(_moveDir.x, -1, 0);
        }
        if (Input.GetKey(KeyCode.W)) //UP
        {
            _moveDir = new Vector3(_moveDir.x, 1, 0);
        }
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.position += (_moveDir * (_moveSpeed * Time.deltaTime));
    }
}
