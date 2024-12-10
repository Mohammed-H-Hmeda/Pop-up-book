using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Book : MonoBehaviour
{
    //handle scaling objects
    public Transform[] YScalingobjects;
    public Transform[] ZScalingObjects;
    Vector3[] Yscales;
    Vector3[] Zscales;
    float yscale;
    float zscale;
    //handle rotating objects +x
    public Transform[] plusXObj;
    float rotobjX;
    Quaternion[] RotatingObjectInitialX;
    //book rotation
    Quaternion initialRotation;
    float bookrotation;
    //handle camer movement
    private Vector3 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        //getting scaling objects initial
        Yscales = new Vector3[YScalingobjects.Length];
        for (int counter = 0; counter < YScalingobjects.Length; counter++)
        {
            Yscales[counter] = YScalingobjects[counter].localScale;
        }

        Zscales = new Vector3[ZScalingObjects.Length];
        for (int counter = 0; counter < ZScalingObjects.Length; counter++)
        {

            Zscales[counter] = ZScalingObjects[counter].localScale;
        }

        //rotating scaling objects initial
        RotatingObjectInitialX = new Quaternion[plusXObj.Length];
        for (int counter = 0; counter < plusXObj.Length; counter++)
        {
            RotatingObjectInitialX[counter] = plusXObj[counter].rotation;
        }
        
        //setting initial values
        initialRotation = transform.rotation;
        bookrotation = 0;
        yscale = Yscales[0].y;
        zscale = Zscales[0].z;
        rotobjX = plusXObj[0].rotation.eulerAngles.x;
        Debug.Log(rotobjX);






    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        float mouseDeltaX = mousePosition.x - lastMousePosition.x;

        if (Input.GetMouseButton(0))
        {
            if (mouseDeltaX < 0)
            {

                bookrotation -= 100 * Time.deltaTime;
                bookrotation = Mathf.Clamp(bookrotation, 0, 180);

                yscale -= 1 * Time.deltaTime * 0.7f;
                yscale = Mathf.Clamp(yscale, 0, 1);

                zscale -= 1 * Time.deltaTime * 0.6f;
                zscale = Mathf.Clamp(zscale, 0, 1);

                rotobjX -= 50 * Time.deltaTime;
                rotobjX = Mathf.Clamp(rotobjX, 270, 360);

                UpdateYScale();
                UpdateRotation();
                UpdateZScale();
            }






            else if (mouseDeltaX > 0)
            {
                bookrotation += 100 * Time.deltaTime;
                bookrotation = Mathf.Clamp(bookrotation, 0, 180);

                yscale += 1 * Time.deltaTime * 0.7f;
                yscale = Mathf.Clamp(yscale, 0, 1);

                zscale += 1 * Time.deltaTime * 0.6f;
                zscale = Mathf.Clamp(zscale, 0, 1);

                rotobjX += 50 * Time.deltaTime;
                rotobjX = Mathf.Clamp(rotobjX, 270, 360);

                UpdateYScale();
                UpdateRotation();
                UpdateZScale();

            }
        }
        transform.rotation = initialRotation * Quaternion.Euler(bookrotation, 0, 0);

        void UpdateYScale()
        {
            for (int scalecounter = 0; scalecounter < YScalingobjects.Length; scalecounter++)
            {
                YScalingobjects[scalecounter].localScale = new Vector3(Yscales[scalecounter].x, yscale, Yscales[scalecounter].z);
            }

        }
        void UpdateZScale()
        {
            for (int scalecounter = 0; scalecounter < ZScalingObjects.Length; scalecounter++)
            {
                ZScalingObjects[scalecounter].localScale = new Vector3(Zscales[scalecounter].x, Zscales[scalecounter].y, zscale);
            }

        }
        void UpdateRotation()
        {
            for (int counter = 0; counter < plusXObj.Length; counter++)
            {

                plusXObj[counter].localRotation = Quaternion.Euler(rotobjX, RotatingObjectInitialX[counter].y, RotatingObjectInitialX[counter].z);

            }


        }


    }
}
