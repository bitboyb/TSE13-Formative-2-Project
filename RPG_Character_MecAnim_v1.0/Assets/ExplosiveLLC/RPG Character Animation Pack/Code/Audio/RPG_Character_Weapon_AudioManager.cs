using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGCharacterAnims;

public class RPG_Character_Weapon_AudioManager : MonoBehaviour
{
    [Header("Unarmed")]
    public AK.Wwise.Event unarmedAtk;

    [Header("Sword")]
    public AK.Wwise.Event swordAtk1;
    public AK.Wwise.Event swordAtk2;
    public AK.Wwise.Event swordRunAtk;
    public AK.Wwise.Event swordSpecialAtk;
    public AK.Wwise.Event swordSpecialStop;
    public AK.Wwise.Event swordUnsheath;
    public AK.Wwise.Event swordSheath;

    [Header("Two Handed Sword")]
    public AK.Wwise.Event twohandedSwordAtk1;
    public AK.Wwise.Event twohandedSwordAtk2;
    public AK.Wwise.Event twohandedSwordRunAtk;
    public AK.Wwise.Event twohandedSwordSpecialAtk;
    public AK.Wwise.Event twohandedSwordSpecialStop;
    public AK.Wwise.Event twohandedSwordUnsheath;
    public AK.Wwise.Event twohandedSwordSheath;

    [Header("Two Handed Axe")]
    public AK.Wwise.Event twohandedAxeAtk1;
    public AK.Wwise.Event twohandedAxeRunAtk;
    public AK.Wwise.Event twohandedAxeSpecialAtk;
    public AK.Wwise.Event twohandedAxeSpecialStop;
    public AK.Wwise.Event twohandedAxeUnsheath;
    public AK.Wwise.Event twohandedAxeSheath;

    [HideInInspector]
    public int newWeaponNumber;
    [HideInInspector]
    public int currentRightWeaponNumber;
    [HideInInspector]
    public int currentLeftWeaponNumber;

    GameObject targetGameObject;
    Target_Audio_Emitter targetScript;

    private void Start()
    {
        //Get target gameobject script and isAttacking bool
        targetGameObject = GameObject.Find("/Target/Target/Target");
        targetScript = targetGameObject.GetComponent<Target_Audio_Emitter>();
        targetScript.isAttacking = false;
    }

    #region Unarmed

    IEnumerator UnarmedAttack()
    {
        unarmedAtk.Post(gameObject);

        yield return new WaitForSeconds(0.1f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.3f);
        targetScript.isAttacking = false;
    }

    #endregion

    #region Sword

    IEnumerator Swd_Attack1()
    {
        swordAtk1.Post(gameObject);

        yield return new WaitForSeconds(0.3f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = false;
    }

    IEnumerator Swd_Attack2()
    {
        swordAtk2.Post(gameObject);

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = false;
    }

    void Swd_Unsheath()
    {
        swordUnsheath.Post(gameObject);
    }

    void Swd_Sheath()
    {
        swordSheath.Post(gameObject);
    }

    void Swd_SpecialAtkStart()
    {
        swordSpecialAtk.Post(gameObject);
        targetScript.isAttacking = true;
    }

    void Swd_SpecialAtkStop()
    {
        swordSpecialStop.Post(gameObject);
        targetScript.isAttacking = false;
    }

    #endregion

    #region Single Weapon Run Attacks

    IEnumerator RunAttack()
    {
        if ((newWeaponNumber == 8) || (newWeaponNumber == 9))
        {
            swordRunAtk.Post(gameObject);

            yield return new WaitForSeconds(0.2f);
            targetScript.isAttacking = true;

            yield return new WaitForSeconds(0.2f);
            targetScript.isAttacking = false;
        }
    }

    #endregion

    #region TwoHandedSword

    IEnumerator THSwd_Attack1()
    {
        twohandedSwordAtk1.Post(gameObject);

        yield return new WaitForSeconds(0.3f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = false;
    }

    IEnumerator THSwd_Attack2()
    {
        twohandedSwordAtk2.Post(gameObject);

        yield return new WaitForSeconds(0.3f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = false;
    }

    IEnumerator THSwd_RunAttack()
    {
        twohandedSwordRunAtk.Post(gameObject);

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.5f);
        targetScript.isAttacking = false;
    }

    void THSwd_Unsheath()
    {
        twohandedSwordUnsheath.Post(gameObject);
    }

    void THSwd_Sheath()
    {
        twohandedSwordSheath.Post(gameObject);
    }

    void THSwd_SpecialAtkStart()
    {
        twohandedSwordSpecialAtk.Post(gameObject);
        targetScript.isAttacking = true;
    }

    void THSwd_SpecialAtkStop()
    {
        twohandedSwordSpecialStop.Post(gameObject);
        targetScript.isAttacking = false;
    }

    #endregion

    #region TwoHandedAxe

    IEnumerator THAxe_Attack1()
    {
        twohandedAxeAtk1.Post(gameObject);

        yield return new WaitForSeconds(0.3f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.5f);
        targetScript.isAttacking = false;
    }

    IEnumerator THAxe_RunAttack()
    {
        twohandedAxeRunAtk.Post(gameObject);

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        targetScript.isAttacking = false;
    }

    void THAxe_Unsheath()
    {
        twohandedAxeUnsheath.Post(gameObject);
    }

    void THAxe_Sheath()
    {
        twohandedAxeSheath.Post(gameObject);
    }

    void THAxe_SpecialAtkStart()
    {
        twohandedAxeSpecialAtk.Post(gameObject);
        targetScript.isAttacking = true;
    }

    void THAxe_SpecialAtkStop()
    {
        twohandedAxeSpecialStop.Post(gameObject);
        targetScript.isAttacking = false;
    }

    #endregion



    #region Unsheath & Sheath

    void Unsheath()
    {
        if ((newWeaponNumber == 8) || (newWeaponNumber == 9))
        {
            Debug.Log("Sword unsheath");
            swordUnsheath.Post(gameObject);
        }

        if (newWeaponNumber == 1)
        {
            Debug.Log("Two handed sword unsheath");
            twohandedSwordUnsheath.Post(gameObject);
        }
        else return;
    }

    void Sheath()
    {
        if ((currentLeftWeaponNumber == 8) || (currentRightWeaponNumber == 9))
        {
            Debug.Log("Sword sheath");
            swordSheath.Post(gameObject);
        }
        if (currentLeftWeaponNumber == 1)
        {
            Debug.Log("Twohanded sword sheath");
            twohandedSwordUnsheath.Post(gameObject);
        }
        else return;
    }
    #endregion
}
