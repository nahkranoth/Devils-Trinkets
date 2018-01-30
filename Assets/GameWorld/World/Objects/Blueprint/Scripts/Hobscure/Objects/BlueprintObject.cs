using UnityEngine;
using System.Collections;
using Hobscure.Items;
using Zenject;
using Hobscure.Objects;

public class BlueprintObject : MonoBehaviour {

    public bool placeable;
    public MeshRenderer matrend;

    public Color disabledColor;
    public Color enabledColor;

    void Start()
    {
        placeable = true;
        matrend.materials[0].color = enabledColor;
    }

    void OnTriggerEnter(Collider other)
    {
        placeable = false;
        matrend.materials[0].color = disabledColor;
    }

    void OnTriggerExit(Collider other)
    {
        placeable = true;
        matrend.materials[0].color = enabledColor;
    }

    public void SetItem(Item item, ObjectManager objectManager)
    {
        matrend = GetComponent<MeshRenderer>();
        var obj = objectManager.GetObjectByName(item.name);
        var meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null) { 
            matrend.materials[0].mainTexture = meshRenderer.sharedMaterials[0].mainTexture;
            matrend.materials[0].color = enabledColor;
        }
    }
}
