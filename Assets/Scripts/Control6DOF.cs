using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class Control6DOF : MonoBehaviour
{
    #region Private Variables
    private MLInputController _controller;
    #endregion

    #region Public Variable
    public GameObject _line;
    #endregion

    #region Unity Methods
    void Start()
    {
        //Start receiving input by the Control
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }
    void OnDestroy()
    {
        //Stop receiving input by the Control
        MLInput.Stop();
    }
    void Update()
    {
        //Attach the Beam GameObject to the Control
        transform.position = _controller.Position;
        transform.rotation = _controller.Orientation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            _line.GetComponent<LineRenderer>().enabled = true;
            _line.GetComponent<LineRenderer>().useWorldSpace = true;
            _line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            _line.GetComponent<LineRenderer>().SetPosition(1, hit.point);
        }

        else
        {
            _line.GetComponent<LineRenderer>().enabled = false;
            //_line.GetComponent<LineRenderer>().useWorldSpace = false;
            //_line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            //_line.GetComponent<LineRenderer>().SetPosition(1, Vector3.forward * 5);
        }

    }

    //Bumper to remove objects:
    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.gameObject.tag == "NewRibs")
                {

                    GameObject.Find("NewRibs").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("default").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("default").GetComponent<MeshCollider>().enabled = false;
                }

                //hit.transform.gameObject.SetActive(false);
                if (hit.transform.gameObject.tag == "StockRibs_FBX")
                {
                    GameObject.Find("StockRibs_FBX").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("clavicleL").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("clavicleR").GetComponent<MeshRenderer>().enabled = false;
                    //collider
                    GameObject.Find("StockRibs_FBX").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("clavicleL").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("clavicleR").GetComponent<MeshCollider>().enabled = false;

                }
                else if (hit.transform.gameObject.tag == "real heart animated")
                {
                    GameObject.Find("real heart animated").GetComponent<SkinnedMeshRenderer>().enabled = false;
                    //collider
                    GameObject.Find("real heart animated").GetComponent<SphereCollider>().enabled = false;
                }
                else if (hit.transform.gameObject.tag == "SK_Lungs")
                {
                    GameObject.Find("Lungs_element_1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Lungs_element_2").GetComponent<SkinnedMeshRenderer>().enabled = false;
                    GameObject.Find("Lungs_element_3").GetComponent<SkinnedMeshRenderer>().enabled = false;
                    GameObject.Find("Defective Lungs").GetComponent<SkinnedMeshRenderer>().enabled = false;
                    GameObject.Find("Lungs_element_4").GetComponent<SkinnedMeshRenderer>().enabled = false;
                    //collider
                    GameObject.Find("Lungs_element_1").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("Lungs_element_2").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("Lungs_element_3").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("Defective Lungs").GetComponent<MeshCollider>().enabled = false;
                    GameObject.Find("Lungs_element_4").GetComponent<MeshCollider>().enabled = false;



                }
                else if (hit.transform.gameObject.tag == "AusculationSites")
                {
                    GameObject.Find("Aortic Area").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Erb's Point").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Mitral Area").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Pulmonic Area").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Tricuspid Area").GetComponent<MeshRenderer>().enabled = false;

                    GameObject.Find("Line1").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Line2").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Line3").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Line4").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Line5").GetComponent<MeshRenderer>().enabled = false;

                    GameObject.Find("Sphere01").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Sphere02").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Sphere03").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Sphere04").GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Sphere05").GetComponent<MeshRenderer>().enabled = false;

                    //collider
                    GameObject.Find("Aortic Area").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Erb's Point").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Mitral Area").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Pulmonic Area").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Tricuspid Area").GetComponent<BoxCollider>().enabled = false;

                    GameObject.Find("Line1").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Line2").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Line3").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Line4").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Line5").GetComponent<BoxCollider>().enabled = false;

                    GameObject.Find("Sphere01").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Sphere02").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Sphere03").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Sphere04").GetComponent<BoxCollider>().enabled = false;
                    GameObject.Find("Sphere05").GetComponent<BoxCollider>().enabled = false;

                }
                else if (hit.transform.gameObject.tag == "ChestFBX")
                {
                    GameObject.Find("ChestFBX").GetComponent<MeshRenderer>().enabled = false;
                    //collider
                    GameObject.Find("ChestFBX").GetComponent<BoxCollider>().enabled = false;
                }
                else if (hit.transform.gameObject.tag == "BarrelChestFBX")
                {
                    GameObject.Find("BarrelChestFBX").GetComponent<MeshRenderer>().enabled = false;
                    //collider
                    GameObject.Find("BarrelChestFBX").GetComponent<BoxCollider>().enabled = false;
                }
                else
                    Debug.Log("Hit a Button");
                               
            }
        }
       
    }

    #endregion
}