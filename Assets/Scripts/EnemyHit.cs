using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int FullHP;

    public bool ShowHitFeedback;
    public Material RedMat;
    public float RedTime;

    [SerializeField]
    private MeshRenderer m_Renderer;
    private Material PreMat;

    public int CurHp { get; set; }
    public bool IsDead { get; set; }

    private void Awake()
    {
        PreMat = m_Renderer.sharedMaterial;
    }

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

            if(ShowHitFeedback)
            {
                StopCoroutine(HitFeedbackCou());
                StartCoroutine(HitFeedbackCou());
            }

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

    public IEnumerator HitFeedbackCou()
    {
        m_Renderer.sharedMaterial = RedMat;
        yield return new WaitForSeconds(RedTime);
        m_Renderer.sharedMaterial = PreMat;
    }
}
