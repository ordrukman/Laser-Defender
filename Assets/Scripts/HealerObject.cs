using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerObject : MonoBehaviour
{
    [SerializeField] int heal = 10;

    public int GetHeal() {
        return heal;
    }

    public void Hit() {
        Destroy(gameObject) ; 
    }
}
