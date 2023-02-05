using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGCharacterAnims;

public class RPG_Character_AudioManager : MonoBehaviour
{
    [Header("Movement Sounds")]
    public AK.Wwise.Event footstepLeft;
    public AK.Wwise.Event footstepRight;
    public AK.Wwise.Event roll;
    public AK.Wwise.Event jump;
    public AK.Wwise.Event doubleJump;
    public AK.Wwise.Event land;

    [Header("Character Sounds")]
    public AK.Wwise.Event getHit;
    public AK.Wwise.Event death;
    public AK.Wwise.Event revive;

    RPG_Character_Weapon_AudioManager weaponAudioManager;

    private void Start()
    {
        weaponAudioManager = GetComponent<RPG_Character_Weapon_AudioManager>();
    }

    #region Movement

    void FootL()
    {
            footstepLeft.Post(gameObject);
    }


    void FootR()
    {

            footstepRight.Post(gameObject);
    }

    void Roll()
    {
        roll.Post(gameObject);
    }

    void Jump()
    {
        jump.Post(gameObject);

        //stop special attack sound if already running
        weaponAudioManager.twohandedSwordSpecialStop.Post(gameObject);
        weaponAudioManager.twohandedAxeSpecialStop.Post(gameObject);
    }

    void DoubleJump()
    {
        doubleJump.Post(gameObject);
    }

    void Land()
    {
        land.Post(gameObject);
    }

    #endregion

    #region Character Sounds

    void GetHit()
    {
        getHit.Post(gameObject);
    }

    void Death()
    {
        death.Post(gameObject);
    }

    void Revive()
    {
        revive.Post(gameObject);
    }

    #endregion

}
