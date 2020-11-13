using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    // Start is called before the first frame update

    public int GetDamage()
    {
        Debug.Log(damage);
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

   
}
