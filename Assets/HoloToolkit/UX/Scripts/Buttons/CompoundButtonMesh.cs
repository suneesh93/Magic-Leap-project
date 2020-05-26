//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using System;
using UnityEngine;
using HoloToolkit.Unity;
using System.Threading.Tasks;
using HoloToolkit.Unity.InputModule;

using System.IO;
using UnityEditor;
using Parabox.STL;
//using System.Windows.Forms;
#if WINDOWS_UWP
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Windows;
#endif

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// Mesh button is a mesh renderer interactable with state data for button state
    /// </summary>
    [RequireComponent(typeof(CompoundButton))]
    public class CompoundButtonMesh : ProfileButtonBase<ButtonMeshProfile>
    {
        const float AnimationSpeedMultiplier = 25f;

        [Tooltip("Transform that scale and offset will be applied to.")]
        [DropDownComponent]
        public Transform TargetTransform;

        [Tooltip("Mesh renderer button for mesh button.")]
        [DropDownComponent]
        public MeshRenderer Renderer;

        /// <summary>
        /// Mesh Button State Data Set
        /// </summary>
        [Serializable]
        public class MeshButtonDatum
        {
            /// <summary>
            /// Constructor for mesh button datum
            /// </summary>
            public MeshButtonDatum(ButtonStateEnum state) { this.ActiveState = state; this.Name = state.ToString(); }

            /// <summary>
            /// Name string for datum entry
            /// </summary>
            public string Name;
            /// <summary>
            /// Button state the datum is active in
            /// </summary>
            public ButtonStateEnum ActiveState;
            /// <summary>
            /// Button mesh color to use in active state
            /// </summary>
            public Color StateColor = Color.white;
            /// <summary>
            /// Button mesh shader property to use in active state
            /// </summary>
            public float StateValue = 0f;
            /// <summary>
            /// Offset to translate mesh to in active state.
            /// </summary>
            public Vector3 Offset;
            /// <summary>
            /// Scale for mesh button in active state
            /// </summary>
            public Vector3 Scale;
        }

        private MeshButtonDatum currentDatum;

        /// <summary>
        /// The material used by button's Renderer after being modified
        /// </summary>
        private Material instantiatedMaterial;

        /// <summary>
        /// The material used by button's Renderer before being modified
        /// </summary>
        private Material sharedMaterial;


        private float lastTimePressed = 0f;

#if UNITY_EDITOR
        /// <summary>
        /// Called by CompoundButtonSaveInterceptor
        /// Prevents saving a scene with instanced materials
        /// </summary>
        public void OnWillSaveScene()
        {
            if (Renderer != null && instantiatedMaterial != null)
            {
                Renderer.sharedMaterial = sharedMaterial;
                GameObject.DestroyImmediate(instantiatedMaterial);
            }
        }
#endif

        protected void Start()
        {
            Button button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("No button attached to CompoundButtonMesh in " + name);
                enabled = false;
                return;
            }

            if (Profile == null)
            {
                Debug.LogError("No profile selected for CompoundButtonMesh in " + name);
                enabled = false;
                return;
            }

            button.StateChange += StateChange;
            // Disable this script if we're not using smooth changes
            enabled = Profile.SmoothStateChanges;
            // Set the current datum so our first state is activated
            currentDatum = Profile.ButtonStates[(int)ButtonStateEnum.Observation];
            UpdateButtonProperties(false);
        }

        /// <summary>
        /// On state change swap out the active mesh based on the state
        /// </summary>
        protected void StateChange(ButtonStateEnum newState)
        {
            if (newState == ButtonStateEnum.Pressed)
            {
                lastTimePressed = Time.time;
            }

            currentDatum = Profile.ButtonStates[(int)newState];

            // If we're not using smooth states, just set them now
            if (!Profile.SmoothStateChanges)
            {
                TargetTransform.localScale = currentDatum.Scale;
                TargetTransform.localPosition = currentDatum.Offset;

                if (Renderer != null)
                {
                    if (instantiatedMaterial == null)
                    {
                        sharedMaterial = Renderer.sharedMaterial;
                        instantiatedMaterial = new Material(sharedMaterial);
                        Renderer.sharedMaterial = instantiatedMaterial;
                    }

                    if (!string.IsNullOrEmpty(Profile.ColorPropertyName))
                    {
                        Renderer.sharedMaterial.SetColor(Profile.ColorPropertyName, currentDatum.StateColor);
                    }
                    if (!string.IsNullOrEmpty(Profile.ValuePropertyName))
                    {
                        Renderer.sharedMaterial.SetFloat(Profile.ValuePropertyName, currentDatum.StateValue);
                    }
                }
            }
        }

        protected void OnDisable()
        {
            StateChange(ButtonStateEnum.Disabled);
            UpdateButtonProperties(false);
        }
        //suneesh:new shabooya1
        /*
        public void OnInputClicked(InputClickedEventData eventData)
        {
#if UNITY_UWP
        FileOpenPick();
#endif

        }
        */
        //suneesh:new shabooya1 ends here

        protected async Task OpenFile()
        //private async void OpenFile()
        {
            Debug.Log("OpenFile");
            Button button = GetComponent<Button>();
            if (button != null)
            {
                StateChange(button.ButtonState);

                UnityEngine.Mesh[] meshes;
                Debug.Log("Button Present");

                //#if WINDOWS_UWP
                //suneesh:new shabooya
                /*

#if UNITY_UWP
    StorageFile selectedStorageFile;
    private async void FileOpenPick()
    {
        UnityEngine.WSA.Application.InvokeOnUIThread(async () =>
        {
            // Trigger file picker to select an image file
            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".stl");
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            selectedStorageFile = await fileOpenPicker.PickSingleFileAsync();

            if (selectedStorageFile != null)
            {
                // Application now has read/write access to the picked file
                Debug.Log("Picked file: " + selectedStorageFile.DisplayName);
            }
            else
            {
                // The picker was dismissed with no selected file
                Debug.Log("File picker operation cancelled");
            }
        }, false);
    }
           string path = selectedStorageFile.Path;
#endif
                //suneesh:new shabooya ends here
                */


#if WINDOWS_UWP
#if true

                    Debug.Log("OpenFilePicker");
                    FileOpenPicker openPicker = new FileOpenPicker();
                    openPicker.ViewMode = PickerViewMode.Thumbnail;
                    openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                    openPicker.FileTypeFilter.Add(".stl");
                
                    Debug.Log("Before await");
                    StorageFile file = await openPicker.PickSingleFileAsync();
                    Debug.Log("After await");

                    //new code:suneesh
                    if (file != null)
                    {               
                        Debug.Log("Picked file: " + file.DisplayName);
                    }
                    else
                    {
                    // The picker was dismissed with no selected file
                    Debug.Log("File picker operation cancelled");
                    }
                    //ends here:suneesh

                   string path = file.Path; // This may break with URIs, so we may have to adjust the STL code and pass a stream, which this object can do

#else
                string path = "";

#endif
    
#else
                
                //string path = EditorUtility.OpenFilePanel("Load stl", "", "stl");
                
#endif

               
                /*
                if (path.Length != 0)
                {
                    meshes = pb_Stl_Importer.Import(path);

                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Material defaultDiffuse = cube.GetComponent<MeshRenderer>().sharedMaterial;
                    GameObject.DestroyImmediate(cube);


                    foreach (UnityEngine.Mesh mesh in meshes)
                    {
                        GameObject child = new GameObject();
                        child.AddComponent<MeshFilter>().sharedMesh = mesh;
                        child.AddComponent<MeshFilter>();
                        child.AddComponent<MeshRenderer>().sharedMaterial = defaultDiffuse;
                    }

                    //foreach (UnityEngine.Mesh mesh in meshes)
                    //{
                    //    GameObject gameObject = new GameObject ();
                    //    MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
                    //    MeshFilter filter = gameObject.AddComponent<MeshFilter>();
                    //    filter.mesh = mesh;
                    //}
                }
                */
                
            }
        }

        protected void OnEnable()
        {
            Debug.Log("Button Pressed");
            OpenFile();
        }

        protected void Update()
        {
            UpdateButtonProperties(true);
        }

        protected void UpdateButtonProperties(bool smooth)
        {
            if (currentDatum == null)
            {
                return;
            }

            MeshButtonDatum datum = currentDatum;

            // If we're using sticky events, and we're still not past the 'sticky' pressed time, use that datum
            if (Profile.StickyPressedEvents && Time.time < lastTimePressed + Profile.StickyPressedTime)
            {
                datum = Profile.ButtonStates[(int)ButtonStateEnum.Pressed];
            }

            if (TargetTransform != null)
            {
                if (smooth)
                {
                    TargetTransform.localScale = Vector3.Lerp(
                        TargetTransform.localScale, datum.Scale,
                        Time.deltaTime * Profile.AnimationSpeed * AnimationSpeedMultiplier);
                    TargetTransform.localPosition = Vector3.Lerp(
                        TargetTransform.localPosition, datum.Offset,
                        Time.deltaTime * Profile.AnimationSpeed * AnimationSpeedMultiplier);
                }
                else
                {
                    TargetTransform.localScale = datum.Scale;
                    TargetTransform.localPosition = datum.Offset;
                }
            }

            // Set the color from the datum 
            if (Renderer != null)
            {
                if (instantiatedMaterial == null)
                {
                    sharedMaterial = Renderer.sharedMaterial;
                    instantiatedMaterial = new Material(sharedMaterial);
                    Renderer.sharedMaterial = instantiatedMaterial;
                }

                if (!string.IsNullOrEmpty(Profile.ColorPropertyName))
                {
                    if (smooth)
                    {
                        Renderer.sharedMaterial.SetColor(
                            Profile.ColorPropertyName,
                            Color.Lerp(Renderer.material.GetColor(Profile.ColorPropertyName),
                            datum.StateColor,
                            Time.deltaTime * Profile.AnimationSpeed * AnimationSpeedMultiplier));
                    }
                    else
                    {
                        Renderer.sharedMaterial.SetColor(
                            Profile.ColorPropertyName,
                            datum.StateColor);
                    }
                }
                if (!string.IsNullOrEmpty(Profile.ValuePropertyName))
                {
                    if (smooth)
                    {
                        Renderer.sharedMaterial.SetFloat(
                            Profile.ValuePropertyName,
                            Mathf.Lerp(Renderer.material.GetFloat(Profile.ValuePropertyName),
                            datum.StateValue,
                            Time.deltaTime * Profile.AnimationSpeed * AnimationSpeedMultiplier));
                    }
                    else
                    {
                        Renderer.sharedMaterial.SetFloat(Profile.ValuePropertyName, datum.StateValue);
                    }
                }
            }
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(CompoundButtonMesh))]
        public class CustomEditor : MRTKEditor { }
#endif
    }
}