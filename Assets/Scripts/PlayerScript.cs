using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 _moveDir = new Vector3(0, 0, 0);
    [SerializeField] float _playerMoveSpeed = 2f;
    [SerializeField] private float _bulletMoveSpeed = 10f;

    private int _numberOfBullets = 50;

    [SerializeField] private GameObject _bulletSpawnField;
    [SerializeField] private GameObject _bulletObject;

    private List<GameObject> _activeBullets = new List<GameObject>();
    private List<GameObject> _inactiveBullets = new List<GameObject>();

    [SerializeField] private GameObject _bulletShootPoint;

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

        if (Input.GetKeyDown(KeyCode.Space)) //SHOOT
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        _inactiveBullets[0].transform.position = _bulletShootPoint.transform.position;
        _inactiveBullets[0].transform.rotation = this.gameObject.transform.rotation;
        _inactiveBullets[0].GetComponent<BulletScript>().SetBulletSpeed(_bulletMoveSpeed);
        _inactiveBullets[0].SetActive(true);
        _activeBullets.Add(_inactiveBullets[0]);
        _inactiveBullets.RemoveAt(0);
    }

    public void BulletDied(GameObject m_bullet)
    {
        _activeBullets.Remove(m_bullet);
        _inactiveBullets.Add(m_bullet);
    }
    private void FixedUpdate()
    {
        this.gameObject.transform.position += (_moveDir * (_playerMoveSpeed * Time.deltaTime));
    }
}
