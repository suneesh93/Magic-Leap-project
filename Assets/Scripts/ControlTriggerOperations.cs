using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class ControlTriggerOperations : MonoBehaviour
{
    #region Private Variables
    private MLInputController controller;
    bool trigger;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        //MLInput.OnControllerButtonDown += UpdateTriggerInfo;
        controller = MLInput.GetController(MLInput.Hand.Left);
    }
    void OnDestroy()
    {
        //Stop receiving input by the Control
        MLInput.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.Position;
        transform.rotation = controller.Orientation;
        UpdateTriggerInfo();

    }

    //Trigger to select objects:
    //void UpdateTriggerInfo(byte controller_id, MLInputControllerButton button)
    void UpdateTriggerInfo()
    {
        
        if (controller.TriggerValue > 0.8f)
        {
            
                RaycastHit hit;
                if (Physics.Raycast(controller.Position, transform.forward, out hit))
                {
                    //switch (hit.transform.gameObject.tag)
                    //{
                    //case "Buttons Collider":
                    if (hit.transform.gameObject.tag == "Buttons Collider")
                    {                      
                        GameObject.Find("Hide Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Hide Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Models Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Models Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Sounds Button Text").GetComponent<Text>().enabled = true;

                        GameObject.Find("Hide Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Models Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //case "Models Collider":
                    if (hit.transform.gameObject.tag == "Models Collider")
                    {
                        GameObject.Find("Lungs Model Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Defective Lungs Model Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Heart Model Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Ribs Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Chest Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Barrel Chest Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Ausculation Sites Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Hide Ausculation Sites Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Lungs Model Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Defective Lungs Model Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Heart Model Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Ribs Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Chest Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Barrel Chest Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Ausculation Sites Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Hide Ausculation Sites Button Text").GetComponent<Text>().enabled = true;


                        GameObject.Find("Lungs Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Defective Lungs Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Heart Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Ribs Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Chest Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Barrel Chest Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Guide Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Hide Guide Collider").GetComponent<BoxCollider>().enabled = true;
                }

                    //case "Sounds Collider":
                    if (hit.transform.gameObject.tag == "Sounds Collider")
                    {
                        GameObject.Find("Lung Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Heart Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Heart Sounds Button Text").GetComponent<Text>().enabled = true;

                        GameObject.Find("Lung Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Heart Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //case "Heart Sounds Collider":
                    if (hit.transform.gameObject.tag == "Heart Sounds Collider")
                    {
                        GameObject.Find("Stop Heart Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Stop Heart Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Heart Sounds Collider").GetComponent<BoxCollider>().enabled = true;

                        GameObject.Find("Heartbeat").GetComponent<AudioSource>().enabled = true;
                    }

                    //case "Stop Heart Sounds Collider":
                    if (hit.transform.gameObject.tag == "Stop Heart Sounds Collider")
                    {
                        GameObject.Find("Heartbeat").GetComponent<AudioSource>().enabled = false;

                        GameObject.Find("Stop Heart Sounds Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Stop Heart Sounds Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Stop Heart Sounds Collider").GetComponent<BoxCollider>().enabled = false;

                    }

                //case "Lung Sounds Collider":
                    if (hit.transform.gameObject.tag == "Lung Sounds Collider")
                    {

                        GameObject.Find("Bronchial Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("BronchoVesicular Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Vesicular Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Tracheal Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Wheezing Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Bronchial Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("BronchoVesicular Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Vesicular Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Tracheal Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Wheezing Button").GetComponent<Image>().enabled = true;

                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = true;



                        //GameObject.Find("Stop Lung Sounds Button").SetActive(true);

                        GameObject.Find("Bronchial Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("BronchoVesicular Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Vesicular Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Tracheal Collider").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Wheezing Collider").GetComponent<BoxCollider>().enabled = true;
                        //GameObject.Find("Stop Lung Sounds Collider").SetActive(true);
                    }

                

                    //case "Bronchial Collider":
                    if (hit.transform.gameObject.tag == "Bronchial Collider")
                    {
                        GameObject.Find("Bronchial").GetComponent<AudioSource>().enabled = true;
                        GameObject.Find("BronchoVesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Tracheal").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Vesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Wheezing").GetComponent<AudioSource>().enabled = false;

                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //"BronchoVesicular Collider":
                    if (hit.transform.gameObject.tag == "BronchoVesicular Collider")
                    {
                        GameObject.Find("Bronchial").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("BronchoVesicular").GetComponent<AudioSource>().enabled = true;
                        GameObject.Find("Tracheal").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Vesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Wheezing").GetComponent<AudioSource>().enabled = false;

                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //"Tracheal Collider":
                    if (hit.transform.gameObject.tag == "Tracheal Collider")
                    {
                        GameObject.Find("Bronchial").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("BronchoVesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Tracheal").GetComponent<AudioSource>().enabled = true;
                        GameObject.Find("Vesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Wheezing").GetComponent<AudioSource>().enabled = false;

                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //case "Vesicular Collider":
                    if (hit.transform.gameObject.tag == "Vesicular Collider")
                    {
                        GameObject.Find("Bronchial").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("BronchoVesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Tracheal").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Vesicular").GetComponent<AudioSource>().enabled = true;
                        GameObject.Find("Wheezing").GetComponent<AudioSource>().enabled = false;

                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //case "Wheezing Collider":
                    if (hit.transform.gameObject.tag == "Wheezing Collider")
                    {
                        GameObject.Find("Bronchial").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("BronchoVesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Tracheal").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Vesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Wheezing").GetComponent<AudioSource>().enabled = true;

                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = true;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = true;
                    }

                    //case "Stop Lung Sounds Collider":
                    if (hit.transform.gameObject.tag == "Stop Lung Sounds Collider")
                    {
                        GameObject.Find("Bronchial").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("BronchoVesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Tracheal").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Vesicular").GetComponent<AudioSource>().enabled = false;
                        GameObject.Find("Wheezing").GetComponent<AudioSource>().enabled = false;

                        GameObject.Find("Bronchial Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("BronchoVesicular Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Vesicular Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Tracheal Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Wheezing Button Text").GetComponent<Text>().enabled = false;

                        GameObject.Find("Bronchial Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("BronchoVesicular Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Vesicular Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Tracheal Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Wheezing Button").GetComponent<Image>().enabled = false;

                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = false;
                    }

                    //case "Chest Collider":
                    if (hit.transform.gameObject.tag == "Chest Collider")
                    {
                        GameObject.Find("ChestFBX").GetComponent<MeshRenderer>().enabled = true;
                        if (GameObject.Find("BarrelChestFBX").GetComponent<MeshRenderer>().enabled != false)
                            GameObject.Find("BarrelChestFBX").GetComponent<MeshRenderer>().enabled = false;
                    //collider
                    GameObject.Find("ChestFBX").GetComponent<BoxCollider>().enabled = true;
                    if (GameObject.Find("BarrelChestFBX").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("BarrelChestFBX").GetComponent<BoxCollider>().enabled = false;
                }

                    //case "Barrel Chest Collider":
                    if (hit.transform.gameObject.tag == "Barrel Chest Collider")
                    {
                        GameObject.Find("BarrelChestFBX").GetComponent<MeshRenderer>().enabled = true;
                        if (GameObject.Find("ChestFBX").GetComponent<MeshRenderer>().enabled != false)
                            GameObject.Find("ChestFBX").GetComponent<MeshRenderer>().enabled = false;
                    //collider
                        GameObject.Find("BarrelChestFBX").GetComponent<BoxCollider>().enabled = true;
                        if (GameObject.Find("ChestFBX").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("ChestFBX").GetComponent<BoxCollider>().enabled = false;
                }

                    //case "Lungs Collider":
                    if (hit.transform.gameObject.tag == "Lungs Collider")
                    {                        
                        GameObject.Find("Lungs_element_1").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Lungs_element_2").GetComponent<SkinnedMeshRenderer>().enabled = true;
                        GameObject.Find("Lungs_element_3").GetComponent<SkinnedMeshRenderer>().enabled = true;
                        GameObject.Find("Lungs_element_4").GetComponent<SkinnedMeshRenderer>().enabled = true;
                    //collider
                        GameObject.Find("Lungs_element_1").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("Lungs_element_2").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("Lungs_element_3").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("Lungs_element_4").GetComponent<MeshCollider>().enabled = true;
                    }

                    //case "Defective Lungs Collider":
                    if (hit.transform.gameObject.tag == "Defective Lungs Collider")
                    {                        
                        GameObject.Find("Lungs_element_1").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Lungs_element_2").GetComponent<SkinnedMeshRenderer>().enabled = true;
                        GameObject.Find("Lungs_element_3").GetComponent<SkinnedMeshRenderer>().enabled = false;
                        GameObject.Find("Defective Lungs").GetComponent<SkinnedMeshRenderer>().enabled = true;
                        GameObject.Find("Lungs_element_4").GetComponent<SkinnedMeshRenderer>().enabled = true;
                    //collider
                        GameObject.Find("Lungs_element_1").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("Lungs_element_2").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("Lungs_element_3").GetComponent<MeshCollider>().enabled = false;
                        GameObject.Find("Defective Lungs").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("Lungs_element_4").GetComponent<MeshCollider>().enabled = true;
                    }



                    //case "Heart Collider":
                    if (hit.transform.gameObject.tag == "Heart Collider")
                    {
                        GameObject.Find("real heart animated").GetComponent<SkinnedMeshRenderer>().enabled = true;
                        //collider
                        GameObject.Find("real heart animated").GetComponent<SphereCollider>().enabled = true;
                    }   

                    //case "Ribs Collider":
                    if (hit.transform.gameObject.tag == "Ribs Collider")
                    {
                        GameObject.Find("StockRibs_FBX").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("clavicleL").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("clavicleR").GetComponent<MeshRenderer>().enabled = true;
                        //collider
                        GameObject.Find("StockRibs_FBX").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("clavicleL").GetComponent<MeshCollider>().enabled = true;
                        GameObject.Find("clavicleR").GetComponent<MeshCollider>().enabled = true;
                    }
                                        

                    //case "Guide Collider":
                    if (hit.transform.gameObject.tag == "Guide Collider")
                    {
                        GameObject.Find("AusculationSites").SetActive(true);
                        GameObject.Find("Aortic Area").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Pulmonic Area").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Erb's Point").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Tricuspid Area").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Mitral Area").GetComponent<MeshRenderer>().enabled = true;

                        GameObject.Find("Line1").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Line2").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Line3").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Line4").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Line5").GetComponent<MeshRenderer>().enabled = true;

                        GameObject.Find("Sphere01").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Sphere02").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Sphere03").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Sphere04").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("Sphere05").GetComponent<MeshRenderer>().enabled = true;

                        //collider
                        GameObject.Find("Aortic Area").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Erb's Point").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Mitral Area").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Pulmonic Area").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Tricuspid Area").GetComponent<BoxCollider>().enabled = true;

                        GameObject.Find("Line1").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Line2").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Line3").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Line4").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Line5").GetComponent<BoxCollider>().enabled = true;

                        GameObject.Find("Sphere01").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Sphere02").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Sphere03").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Sphere04").GetComponent<BoxCollider>().enabled = true;
                        GameObject.Find("Sphere05").GetComponent<BoxCollider>().enabled = true;

                    }

                if (hit.transform.gameObject.tag == "Hide Guide Collider")
                {
                    if (GameObject.Find("Aortic Area").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Aortic Area").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Pulmonic Area").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Pulmonic Area").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Erb's Point").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Erb's Point").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Tricuspid Area").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Tricuspid Area").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Mitral Area").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Mitral Area").GetComponent<MeshRenderer>().enabled = false;

                    if (GameObject.Find("Line1").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Line1").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Line2").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Line2").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Line3").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Line3").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Line4").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Line4").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Line5").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Line5").GetComponent<MeshRenderer>().enabled = false;


                    if (GameObject.Find("Sphere01").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Sphere01").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Sphere02").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Sphere02").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Sphere03").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Sphere03").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Sphere04").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Sphere04").GetComponent<MeshRenderer>().enabled = false;
                    if (GameObject.Find("Sphere05").GetComponent<MeshRenderer>().enabled != false)
                        GameObject.Find("Sphere05").GetComponent<MeshRenderer>().enabled = false;

                    //collider
                    if (GameObject.Find("Aortic Area").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Aortic Area").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Pulmonic Area").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Pulmonic Area").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Erb's Point").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Erb's Point").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Tricuspid Area").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Tricuspid Area").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Mitral Area").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Mitral Area").GetComponent<BoxCollider>().enabled = false;

                    if (GameObject.Find("Line1").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Line1").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Line2").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Line2").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Line3").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Line3").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Line4").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Line4").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Line5").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Line5").GetComponent<BoxCollider>().enabled = false;


                    if (GameObject.Find("Sphere01").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Sphere01").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Sphere02").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Sphere02").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Sphere03").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Sphere03").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Sphere04").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Sphere04").GetComponent<BoxCollider>().enabled = false;
                    if (GameObject.Find("Sphere05").GetComponent<BoxCollider>().enabled != false)
                        GameObject.Find("Sphere05").GetComponent<BoxCollider>().enabled = false;



                }
                //case "Hide Collider":
                if (hit.transform.gameObject.tag == "Hide Collider")
                    {

                        GameObject.Find("Hide Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Models Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Sounds Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Lungs Model Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Defective Lungs Model Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Heart Model Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Ribs Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Chest Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Barrel Chest Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Ausculation Sites Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Hide Ausculation Sites Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Lung Sounds Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Heart Sounds Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Bronchial Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("BronchoVesicular Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Vesicular Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Tracheal Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Wheezing Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Stop Lung Sounds Button Text").GetComponent<Text>().enabled = false;
                        GameObject.Find("Stop Heart Sounds Button Text").GetComponent<Text>().enabled = false;

                        GameObject.Find("Hide Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Models Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Sounds Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Lungs Model Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Defective Lungs Model Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Heart Model Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Ribs Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Chest Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Barrel Chest Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Ausculation Sites Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Hide Ausculation Sites Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Lung Sounds Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Heart Sounds Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Bronchial Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("BronchoVesicular Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Vesicular Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Tracheal Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Wheezing Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Stop Heart Sounds Button").GetComponent<Image>().enabled = false;
                        GameObject.Find("Stop Lung Sounds Button").GetComponent<Image>().enabled = false;
                        

                        GameObject.Find("Hide Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Models Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Sounds Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Lungs Model Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Defective Lungs Model Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Heart Model Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Ribs Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Chest Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Barrel Chest Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Guide Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Hide Guide Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Lungs Sounds Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Heart Sounds Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Bronchial Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("BronchoVesicular Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Vesicular ButtCollideron").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Tracheal Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Wheezing Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Stop Heart Sounds Collider").GetComponent<BoxCollider>().enabled = false;
                        GameObject.Find("Stop Lung Sounds Collider").GetComponent<BoxCollider>().enabled = false;
                    }

                        //default:
                            //Debug.Log("Nothing Selected");
                            //break;               


                    //}

                }               

            
        }


    }
}
