using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public Character character;
    private void OnCollisionEnter(Collision collision)
    {
        character = collision.gameObject.GetComponent<Character>();
        if(collision.gameObject.tag == "Player")
        {
           character.equippedWeaponMagazine.SetAmmuniationTotal(character.equippedWeaponMagazine.GetAmmunitionTotal() + 5);
           Destroy(gameObject);
        }
    }
}
