﻿using UnityEngine;
using System.Collections;

public class BeamShot : MonoBehaviour
{

    float timer = 0.0f;
    float effectDisplayTime = 0.2f;
    float length = 0.0f;
    Ray shotRay;
    RaycastHit shotHit;
    ParticleSystem beamParticle;
    LineRenderer lineRenderer;

    // Use this for initialization
    void Awake()
    {
        beamParticle = GetComponent<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        length += 0.1f;

        //timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            shot();
        }
        if (timer >= effectDisplayTime)
        {
            disableEffect();
        }
    }

    private void shot()
    {
        timer = 0f;
        beamParticle.Stop();
        beamParticle.Play();
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        shotRay.origin = transform.position;
        shotRay.direction = transform.forward;

        int layerMask = 0;
        if (Physics.Raycast(shotRay, out shotHit, length, layerMask))
        {
            // hit 
        }
        lineRenderer.SetPosition(
            1,
            shotRay.origin + shotRay.direction * length
            );
    }

    private void disableEffect()
    {
        beamParticle.Stop();
        lineRenderer.enabled = false;
    }
}