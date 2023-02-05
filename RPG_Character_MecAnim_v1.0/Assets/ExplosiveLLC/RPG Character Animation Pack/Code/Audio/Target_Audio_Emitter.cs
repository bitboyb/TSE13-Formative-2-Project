using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Audio_Emitter : MonoBehaviour
{

    public AK.Wwise.Event weaponImpactSound;

    [HideInInspector]
    public bool isAttacking;

    ParticleSystem particleEmitter;

    private void Start()
    {
        particleEmitter = GetComponent<ParticleSystem>();
        particleEmitter.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && isAttacking == true)
        {
            Debug.Log("Target Hit");
            weaponImpactSound.Post(gameObject);
            particleEmitter.Play();
        }
        else return;
   }
}
