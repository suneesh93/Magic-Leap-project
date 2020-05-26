using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class MyControl : MonoBehaviour
{
    public MLPersistentBehavior persistentBehavior;
    //private GameObject _cube, _camera;
    private GameObject _imgTarget, _camera;
    private MLInputController _controller;
    private const float _distance = 2.0f;

    private void Start()
    {
        //cube = GameObject.Find("Cube");
        _imgTarget = GameObject.Find("ImageTarget");
        _camera = Camera.main.gameObject;

        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }
    private void OnDestroy()
    {
        MLInput.Stop();
    }
    private void Update()
    {
        //if (_controller.TriggerValue > 0.2f)
        //{
            //_cube.transform.position = _camera.transform.position + _camera.transform.forward * _distance;
            //_cube.transform.rotation = _camera.transform.rotation;
            /*_imgTarget.transform.position = _imgTarget.transform.position + _imgTarget.transform.forward * _distance;
            _imgTarget.transform.rotation = _imgTarget.transform.rotation;*/
            persistentBehavior.UpdateBinding();
        //}
    }
}


