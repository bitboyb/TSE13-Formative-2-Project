using System.Collections;
using UnityEngine;

namespace RPGCharacterAnims
{
    //Placeholder functions for Animation events.
    public class RPGCharacterAnimatorEvents:MonoBehaviour
    {
		public RPGCharacterController rpgCharacterController;

        public void WeaponSwitch()
        {
            if (rpgCharacterController.rpgCharacterWeaponController != null)
            {
                rpgCharacterController.rpgCharacterWeaponController.WeaponSwitch();
            }
        }
    }
}