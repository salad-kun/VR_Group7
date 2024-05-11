using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial_Hand : MonoBehaviour
{
    [Tooltip("The material that's switched to.")]
    public Material otherMaterial = null;

    //added
    [SerializeField] private bool findChild = false;

    private bool usingOther = false;
    private MeshRenderer meshRenderer = null;
    private Material originalMaterial = null;

    //function called before Start()
    private void Awake()
    {
        InitializeMaterial();
    }

    //added
    private void InitializeMaterial()
    {
        if (meshRenderer == null)
        {
            if (findChild)
            {
                meshRenderer = GetComponentInChildren<MeshRenderer>();
            }
            else
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }

            Debug.Log("mesh renderer: " + meshRenderer);

            if (meshRenderer)
            {
                originalMaterial = meshRenderer.material;
            }
        }
    }

    public void SetOtherMaterial()
    {
        InitializeMaterial();
        usingOther = true;
        meshRenderer.material = otherMaterial;
    }

    public void SetOriginalMaterial()
    {
        InitializeMaterial();
        usingOther = false;
        meshRenderer.material = originalMaterial;
    }

    public void ToggleMaterial()
    {
        usingOther = !usingOther;

        if (usingOther)
        {
            meshRenderer.material = otherMaterial;
        }
        else
        {
            meshRenderer.material = originalMaterial;
        }
    }
}
