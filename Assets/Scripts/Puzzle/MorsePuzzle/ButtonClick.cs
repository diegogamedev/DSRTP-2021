﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    private bool listening = false;
    private int clicks = 0;

    public MorseManager morseManager;

    public MeshRenderer buttonMaterial;

    public ParticleSystem interaction;

    void Update()
    {
        if (listening)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interaction.Play();
                clicks++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ListeningTime());
        }
    }

    public void TurnOff()
    {
        GetComponent<Collider>().enabled = false;
        enabled = false;
        interaction.Stop();
    }

    IEnumerator ListeningTime()
    {
        listening = true;
        buttonMaterial.material.color = Color.blue;
        yield return new WaitForSeconds(5);
        buttonMaterial.material.color = Color.white;
        listening = false;
        morseManager.CheckResolution(clicks);
        clicks = 0;
    }
}
