using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private GameObject _boxExplodeParticles;
    // Start is called before the first frame update
    void Start()
    {
        _boxExplodeParticles = GameObject.FindGameObjectWithTag("BoxParticles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeBox()
    {
        _boxExplodeParticles.transform.position = this.gameObject.transform.position;
        _boxExplodeParticles.GetComponent<ParticleSystem>().Play();
        FindObjectOfType<AudioManager>().Play("BoxBreak");
    }
}
