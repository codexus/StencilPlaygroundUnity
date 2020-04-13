using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    private static int stencilPropertyName = Shader.PropertyToID("_StencilTest");

    [SerializeField] private Material[] materials;

    [SerializeField] private Transform cameraTransform;


    private bool wasInFront;
    private bool inOtherWorld;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != cameraTransform) return;
        wasInFront = IsInFront();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform != cameraTransform) return;
        bool isInFront = IsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }
        wasInFront = isInFront;
    }

    private bool IsInFront()
    {
        Vector3 pos = transform.InverseTransformPoint(cameraTransform.position);
        return pos.z >= 0 ? true : false;
    }

    private void SetMaterials(bool fullRender)
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetInt(stencilPropertyName, (int)(fullRender ? CompareFunction.NotEqual : CompareFunction.Equal));
        }
    }
}
