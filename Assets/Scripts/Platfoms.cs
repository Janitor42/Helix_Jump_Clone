using System.Linq;
using UnityEngine;

public class Platfoms : MonoBehaviour
{
    public GameObject Sector;
    public GameObject DestroyPlatformParticle;
    public Vector3 GetSector;

    public void OnTriggerEnter(Collider other)
    {
        Sector=gameObject;
        GetSector=transform.position;

    }
    public void OnTriggerExit(Collider other )
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CoutPlatformsDestroit();
            var explosion = Instantiate(DestroyPlatformParticle, GetSector, Quaternion.Euler(90f, 0f, 0f));
            Destroy(explosion, 1f);
            Sector.SetActive(false);


        }
    }
 
}
