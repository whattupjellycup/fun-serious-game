﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the selected object
/// </summary>
public class SelectOnInput : MonoBehaviour
{

    public EventSystem eventSystem;
    public GameObject gameObject;

    private bool selected;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && selected == false)
        {
            // select the object
            eventSystem.SetSelectedGameObject(gameObject);
            selected = true;
        }
    }
    // deselect the object
    private void OnDisable()
    {
        selected = false;
    }
}