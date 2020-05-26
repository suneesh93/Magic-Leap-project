using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DynamicBeam : MonoBehaviour
{
    public GameObject controller;
    public LineRenderer beamline;
    public Color startcolor;
    public Color endcolor;
    // Start is called before the first frame update
    void Start()
    {
        beamline = GetComponent<LineRenderer>();
        beamline.startColor = startcolor;
        beamline.endColor = endcolor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            beamline.useWorldSpace = true;
            beamline.SetPosition(0, transform.position);
            beamline.SetPosition(1, hit.point);

        }
        else
        {
            beamline.useWorldSpace = false;
            beamline.SetPosition(0, transform.position);
            beamline.SetPosition(1, Vector3.forward * 5);
        }
    }
}
