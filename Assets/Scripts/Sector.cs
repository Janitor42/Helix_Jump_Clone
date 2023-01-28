using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;

    public void Awake()
    {
        UpdateMaterial();
    }
    public void UpdateMaterial()
    {
        GetComponent<Renderer>().sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player)) 
        {
            if (IsGood)
            {
                player.Bounce();
            }
            else
            {

                player.Die();
            }
        }
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
