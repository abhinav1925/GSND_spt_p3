using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int FullHP;

    public int CurHp { get; set; }
    public bool IsDead { get; set; }

    private void OnEnable()
    {
        CurHp = FullHP;
    }

    public void ApplyDamage(int damage)
    {
        if(!IsDead)
        {
            Debug.Log("Receive Damage");
            CurHp -= damage;
            if(CurHp<=0)
            {
                EnemyDie();
            }
        }

    }

    public void EnemyDie()
    {
        IsDead= true;
        Debug.Log("EnemyDie");
    }
}
