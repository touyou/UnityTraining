﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour{
    public Transform UnityChan;
    public Transform stopPosition;
    [SceneName]
    public string nextLevel;
    private Camera m_camera;

    void Awake(){
        m_camera = GetComponent<Camera>();
    }

    void LateUpdate(){
        var right = m_camera.ViewportToWorldPoint(Vector2.right);
        var center = m_camera.ViewportToWorldPoint(Vector2.one * 0.5f);

        if (center.x < UnityChan.position.x){
            var pos = m_camera.transform.position;

            if (Math.Abs(pos.x - UnityChan.position.x) >= 0.0000001f){
                m_camera.transform.position = new Vector3(UnityChan.position.x, pos.y, pos.z);
            }
        }

        if (stopPosition.position.x - right.x < 0){
            StartCoroutine(INTERNAL_Clear());
            enabled = false;
        }
    }

    private IEnumerator INTERNAL_Clear(){
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player){
            player.SendMessage("Clear", SendMessageOptions.DontRequireReceiver);
        }

        yield return new WaitForSeconds(3);
        Application.LoadLevel(nextLevel);
    }
}
