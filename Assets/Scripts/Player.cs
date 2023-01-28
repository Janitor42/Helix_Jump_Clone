
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float DestroitPlatform;
    private float _DestroitPlatform;
    public float BounceSpeed;
    public Rigidbody rb;
    public Game Game;
    public Text TextCountPlatforms;

    public GameObject Touch_particle;
    public GameObject Smoke_Particle;

    public SoundEffects SoundEffects;
    private Vector3 Player_position;

    public void Start()
    {
        DestroitPlatform = 0f;
    }

    public void Bounce()
    {
        rb.velocity = new Vector3(0, BounceSpeed, 0);
        Player_position = transform.position;
        var explosion=Instantiate(Touch_particle, Player_position,Quaternion.Euler(90f,0f,0f));
        Destroy(explosion, 1f);
    }
    public void Die()
    {

        rb.velocity = Vector3.zero;
        Player_position = transform.position;
        GameObject Smoke = Instantiate(Smoke_Particle, Player_position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(Smoke, 3f);
        Game.OnPlayerPause();   
    }
    public void ReachFinish()
    {
        Game.YouWin();
        rb.velocity = Vector3.zero;       
    }
    public void DestroyPlatformReset()
    { _DestroitPlatform = 0f;}
    public void CoutPlatformsDestroit()
    {
        _DestroitPlatform = _DestroitPlatform + 1f;
        float DestroitPlatform = _DestroitPlatform;
        TextCountPlatforms.text=DestroitPlatform.ToString();
        SoundEffects.SoundDestroyPlatform();
    }
}

    