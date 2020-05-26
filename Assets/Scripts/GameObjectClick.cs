using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA;

//#if UNITY_LUMIN
using UnityEngine;
using System;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.XR.WSA;
//#endif

//new:suneesh
using System;
using HoloToolkit.Unity;
using System.Threading;
using System.Threading.Tasks;
using HoloToolkit.Unity.SpatialMapping;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Vuforia;

using System.IO;
using UnityEditor;
using Parabox.STL;

//ends here:suneesh
public class GameObjectClick : MonoBehaviour
{
    private GameObject AllOrgans;
    public GameObject RibcageObject;
    public GameObject KidneyObject;
    public GameObject HeartObject;
    public GameObject LungsObject;
    public GameObject LiverObject;
    public GameObject ChestObject;
    public GameObject BarrelChestObject;
    public GameObject AuscultationSites;
    private Text VoiceCommandText;
    private bool lockRibsFlag;

    //#if UNITY_LUMIN

    //new code suneesh 2 lines

    private Vector3 originalPosition;
    private Quaternion originalRotation;
//#endif
    // Use this for initialization
    void Start()
    {
        AllOrgans = new GameObject();
        RibcageObject = GameObject.Find("Ribcage");
        KidneyObject = GameObject.Find("Kidneys");
        HeartObject = GameObject.Find("Heart");
        LungsObject = GameObject.Find("Lungs");
        LiverObject = GameObject.Find("Liver");
        ChestObject = GameObject.Find("Chest");
        BarrelChestObject = GameObject.Find("BarrelChest");
        AuscultationSites = GameObject.Find("AuscultationSites");
        lockRibsFlag = false;

//#if UNITY_LUMIN
        KidneyObject.SetActive(false);
        HeartObject.SetActive(false);
        LungsObject.SetActive(false);
        LiverObject.SetActive(false);
        ChestObject.SetActive(false);
        BarrelChestObject.SetActive(false);
        AuscultationSites.SetActive(false);

        
        //theobject();         
//#endif

    }

    // Update is called once per frame
    void Update()
    {
        GameObject child = new GameObject("All Organs");
        GameObject ribs = GameObject.Find("Ribcage");
        ribs.transform.parent = child.transform;
        KidneyObject.transform.parent = child.transform;
        HeartObject.transform.parent = child.transform;
        LungsObject.transform.parent = child.transform;
        LiverObject.transform.parent = child.transform;
        ChestObject.transform.parent = child.transform;
        BarrelChestObject.transform.parent = child.transform;

        //vuforia target code:
        var TargetImage = GameObject.Find("ImageTarget");
        if (TargetImage == false)
            Debug.Log("NO IMAGE TARGET FOUND!");
        if (lockRibsFlag == false)
        {
            child.transform.parent = TargetImage.transform;
            child.transform.position = new Vector3(0, 0, 0);
        }
        //
        child.AddComponent<BoxCollider>();
        //For occlusion:
        //child.AddComponent<SpatialMappingRenderer>();

        //ribs:                    
        GameObject.Find("StockRibs_FBX").SetActive(true);
        GameObject.Find("StockRibs_FBX").GetComponent<MeshRenderer>().enabled = true;
        GameObject ribs_child = new GameObject("StockRibs_FBX");
        ribs_child.transform.parent = ribs.transform;
        ribs_child.transform.Rotate(0, 90, -105);
        ribs_child.transform.position = new Vector3(0, 0, 0);


        //chest:

        GameObject.Find("ChestFBX").SetActive(true);
        GameObject.Find("ChestFBX").GetComponent<MeshRenderer>().enabled = true;
        GameObject chestchild = GameObject.Find("ChestFBX");
        chestchild.transform.parent = ChestObject.transform;
        chestchild.transform.Rotate(90, 0, 0);
        //chestchild.transform.Rotate(0, 90, -105);
        chestchild.transform.position = new Vector3(0, 0, 0);

        //barrel chest:

        GameObject.Find("BarrelChestFBX").SetActive(true);
        GameObject.Find("BarrelChestFBX").GetComponent<MeshRenderer>().enabled = true;
        GameObject barrelchestchild = GameObject.Find("BarrelChestFBX");
        barrelchestchild.transform.parent = BarrelChestObject.transform;
        barrelchestchild.transform.Rotate(90, 0, 0);
        //barrelchestchild.transform.Rotate(0, 90, -105);
        barrelchestchild.transform.position = new Vector3(-0.08f, 0.25f, 0);


        //clavicles:

        GameObject.Find("TheClavs").SetActive(true);
        GameObject.Find("clavicleL").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("clavicleR").GetComponent<MeshRenderer>().enabled = true;
        GameObject claviclechild = GameObject.Find("TheClavs");
        claviclechild.transform.parent = ribs.transform;
        claviclechild.transform.position = new Vector3(0, 0, 0);

        //auscultation points:

        GameObject auscpointschild = GameObject.Find("AuscultationSites");
        auscpointschild.transform.parent = ribs.transform;
        auscpointschild.transform.Rotate(0, 0, 0);
        auscpointschild.transform.position = new Vector3(0, -0.01f, 0);


        //heart:
        GameObject.Find("real heart animated").SetActive(true);
        GameObject.Find("real heart animated").GetComponent<SkinnedMeshRenderer>().enabled = true;
        GameObject heartchild = GameObject.Find("real heart animated");
        heartchild.transform.parent = HeartObject.transform;
        heartchild.transform.Rotate(90, 0, 0);
        heartchild.transform.position = new Vector3(0.02f, -0.04f, -0.08f);

        //lungs:
        GameObject.Find("SK_Lungs").SetActive(true);
        GameObject.Find("Lungs_element_1").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Lungs_element_2").GetComponent<SkinnedMeshRenderer>().enabled = true;
        GameObject.Find("Lungs_element_3").GetComponent<SkinnedMeshRenderer>().enabled = true;
        GameObject.Find("Lungs_element_4").GetComponent<SkinnedMeshRenderer>().enabled = true;
        GameObject lungschild = GameObject.Find("SK_Lungs");
        lungschild.transform.parent = LungsObject.transform;
        lungschild.transform.Rotate(70, 0, 0);
        lungschild.transform.position = new Vector3(0, -0.05f, -0.05f);
    }

    #region VOICE_INPUT

    public void MoveRibsMethod()
    {
//#if UNITY_LUMIN
        AllOrgans = GameObject.Find("All Organs");
        if (AllOrgans.GetComponent<TapToPlace>() != null)
            AllOrgans.GetComponent<TapToPlace>().enabled = true;
        else
            AllOrgans.AddComponent<TapToPlace>();
        
//#endif
    }

    public void AdjustRibsMethod()
    {
//#if UNITY_LUMIN
        AllOrgans = GameObject.Find("All Organs");
        if (AllOrgans.GetComponent<HandDragging>() != null)
            AllOrgans.GetComponent<HandDragging>().enabled = true;
        else
            AllOrgans.AddComponent<HandDragging>();
        
//#endif
    }

    public void ResizeRibsMethod()
    {
//#if UNITY_LUMIN
        AllOrgans = GameObject.Find("All Organs");
        if (AllOrgans.GetComponent<HandResize>() != null)
            AllOrgans.GetComponent<HandResize>().enabled = true;
        else
            AllOrgans.AddComponent<HandResize>();
//#endif
    }

    public void RotateRibsMethod()
    {
//#if UNITY_LUMIN
        AllOrgans = GameObject.Find("All Organs");
        if (AllOrgans.GetComponent<HandRotate>() != null)
            AllOrgans.GetComponent<HandRotate>().enabled = true;
        else
            AllOrgans.AddComponent<HandRotate>();
//#endif
    }

    public void DoneMethod()
    {
//#if UNITY_LUMIN
        AllOrgans = GameObject.Find("All Organs");
        if (AllOrgans.GetComponent<HandDragging>() != null)
            AllOrgans.GetComponent<HandDragging>().enabled = false;
        if (AllOrgans.GetComponent<HandRotate>() != null)
            AllOrgans.GetComponent<HandRotate>().enabled = false;
        if (AllOrgans.GetComponent<HandResize>() != null)
            AllOrgans.GetComponent<HandResize>().enabled = false;
        if (AllOrgans.GetComponent<TapToPlace>() != null)
            AllOrgans.GetComponent<TapToPlace>().enabled = false;
//#endif
    }

    public void LockRibsMethod()
    {
//#if UNITY_LUMIN
        lockRibsFlag = true;
        AllOrgans = GameObject.Find("All Organs");
        var GameObjectTemp = GameObject.Find("TempGameObject");
        AllOrgans.transform.parent = GameObjectTemp.transform;
        //AllOrgans.transform.position = AllOrgans.transform.position;
//#endif
    }

    public void ResetRibsMethod()
    {
//#if UNITY_LUMIN
        lockRibsFlag = false;
        AllOrgans = GameObject.Find("All Organs");
        var TargetImage = GameObject.Find("ImageTarget");
        if (TargetImage == false)
           Debug.Log("NO IMAGE TARGET FOUND!");
        AllOrgans.transform.parent = TargetImage.transform;
        AllOrgans.transform.position = TargetImage.transform.position;
        //AllOrgans.transform.Rotate(0, 0, 0, Space.World);
        if (originalRotation != null)
        {
            AllOrgans.transform.rotation = originalRotation;
            AllOrgans.transform.Rotate(0, 130, 0);
        }
//#endif
    }
    public void RemoveRibsMethod()
    {
//#if UNITY_LUMIN
        lockRibsFlag = false;
        AllOrgans = GameObject.Find("All Organs");
        Destroy(AllOrgans);
//#endif
    }

    public void HelpMethod()
    {
//#if UNITY_LUMIN
        VoiceCommandText = GameObject.Find("Voice Commands Text").GetComponent<Text>();
        float t = 0;        
        VoiceCommandText.enabled = true;
        /*if (t < 5)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            VoiceCommandText.enabled = true;
        }
        else
            VoiceCommandText.enabled = false;*/
//#endif
    }

    public void HideTextMethod()
    {
//#if UNITY_LUMIN
        VoiceCommandText = GameObject.Find("Voice Commands Text").GetComponent<Text>();
        VoiceCommandText.enabled = false;
//#endif
    }

    public void ShowRibsMethod()
    {
//#if UNITY_LUMIN
        RibcageObject.SetActive(true);
//#endif
    }

    public void HideRibsMethod()
    {
//#if UNITY_LUMIN
        RibcageObject.SetActive(false);
//#endif
    }

    public void ShowChestMethod()
    {
//#if UNITY_LUMIN
        ChestObject.SetActive(true);
//#endif
    }

    public void HideChestMethod()
    {
//#if UNITY_LUMIN
        ChestObject.SetActive(false);
//#endif
    }

    public void ShowBarrelChestMethod()
    {
//#if UNITY_LUMIN
        BarrelChestObject.SetActive(true);
//#endif
    }

    public void HideBarrelChestMethod()
    {
//#if UNITY_LUMIN
        BarrelChestObject.SetActive(false);
//#endif
    }

    public void ShowKidneyMethod()
    {
//#if UNITY_LUMIN
        KidneyObject.SetActive(true);
//#endif
    }

    public void HideKidneyMethod()
    {
//#if UNITY_LUMIN
        KidneyObject.SetActive(false);
//#endif
    }

    public void ShowHeartMethod()
    {
//#if UNITY_LUMIN
        HeartObject.SetActive(true);
//#endif
    }

    public void HideHeartMethod()
    {
//#if UNITY_LUMIN
        HeartObject.SetActive(false);
//#endif
    }

    public void ShowLungsMethod()
    {
//#if UNITY_LUMIN
        LungsObject.SetActive(true);
//#endif
    }

    public void HideLungsMethod()
    {
//#if UNITY_LUMIN
        LungsObject.SetActive(false);
//#endif
    }

    public void ShowLiverMethod()
    {
//#if UNITY_LUMIN
        LiverObject.SetActive(true);
//#endif
    }

    public void HideLiverMethod()
    {
//#if UNITY_LUMIN
        LiverObject.SetActive(false);
//#endif
    }

    public void ShowGuideMethod()
    {
//#if UNITY_LUMIN

        GameObject.Find("AuscultationSites").SetActive(true);
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
//#endif
    }

    public void HideGuideMethod()
    {
//#if UNITY_LUMIN

        GameObject.Find("AuscultationSites").SetActive(true);
        GameObject.Find("Aortic Area").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Pulmonic Area").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Erb's Point").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Tricuspid Area").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Mitral Area").GetComponent<MeshRenderer>().enabled = false;

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
//#endif
    }




    #endregion

    //#if UNITY_LUMIN
    #region THE_OBJECT
    //public void theobject()
    //{

        
        //ends here:suneesh
    //}
    #endregion
        
//#endif
}