using System.Collections.Generic;
using RPGCharacterAnims;
using UnityEngine;

public class Target_Audio_Emitter : MonoBehaviour
{
    public AK.Wwise.Event weaponImpactSound;
    public List<string> weaponImpactSwitches;
    [HideInInspector] public bool isAttacking;
    
    private RPGCharacterController _rpgCharacterController;
    ParticleSystem particleEmitter;

    private void Start()
    {
        particleEmitter = GetComponent<ParticleSystem>();
        particleEmitter.Stop();
        _rpgCharacterController = GameObject.Find("RPG-Character").GetComponent<RPGCharacterController>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && isAttacking)
        {
            Debug.Log("Target Hit");
            switch (_rpgCharacterController.GetCurrentWeapon())
            {
                case "TWOHANDSWORD":
                    SetEventSwitch(2);
                    break;
                case "TWOHANDAXE":
                    SetEventSwitch(1);
                    break;
                case "ARMED":
                    SetEventSwitch(0);
                    break;
                case "UNARMED":
                    SetEventSwitch(3);
                    break;
                default:
                    SetEventSwitch(0);
                    break;
            }

            AkSoundEngine.PostEvent(weaponImpactSound.Name, gameObject);
            particleEmitter.Play();
        }
        else return;
   }
    
    private void SetEventSwitch(int index)
    {
        AkSoundEngine.SetSwitch("Player_Weapon", weaponImpactSwitches[index], gameObject);
    }
}
