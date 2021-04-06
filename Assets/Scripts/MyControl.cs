using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class MyControl : MonoBehaviour
{
    public MLPersistentBehavior persistentBehavior;

    //
    public MLPersistentBehavior persistentBehavior1;
    public MLPersistentBehavior persistentBehavior2;
    public MLPersistentBehavior persistentBehavior3;
    public MLPersistentBehavior persistentBehavior4;
    public MLPersistentBehavior persistentBehavior5;
    public MLPersistentBehavior persistentBehavior6;
    public MLPersistentBehavior persistentBehavior7;
    //

    //private GameObject _cube, _camera;
    private GameObject _imgTarget, _camera;
    //expt suneesh:
    private GameObject _ribs, _heart, _lungs, _defectiveLungs, _ausc, _chest, _barrelchest;
    //expt ends here
    private MLInputController _controller;
    //private const float _distance = 2.0f;

    private void Start()
    {
        //cube = GameObject.Find("Cube");
        _imgTarget = GameObject.Find("ImageTarget");
        //expt suneesh:
        _ribs = GameObject.Find("StockRibs_FBX");
        _heart = GameObject.Find("real heart animated");
        _lungs = GameObject.Find("SK_Lungs");
        _defectiveLungs = GameObject.Find("Defective Lungs");
        _ausc = GameObject.Find("AusculationSites");
        _chest = GameObject.Find("ChestFBX");
        _barrelchest = GameObject.Find("BarrelChestFBX"); 
        //expt ends here
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


