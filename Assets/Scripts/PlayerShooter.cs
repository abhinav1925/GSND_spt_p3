using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerShooter : MonoBehaviour
{
    public int Damage;
    public float ShootIntervalTime;
    public float PerShootCost;
    public float PerTickRecover;
    public float MaxShootPower;

    public LayerMask ShootLayer;
    public AudioClip ShootClip;

    [SerializeField]
    private AudioSource m_Source;
    [SerializeField]
    private Animator m_Anim;
    [SerializeField]
    private ParticleSystem Salt;
    private float m_Timer = 0;
    private Vector3 CenterPoint;
    public float RemainShootPower;
    [SerializeField] GameObject ghost;
    public bool IsShooting { get; set; }



    void Start()
    {
        RemainShootPower = MaxShootPower;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShoot();
        if (FindObjectOfType<DialogueController>().dialEnd)
        {
            ghost.SetActive(true);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsShooting = true;
        }
        else if (context.canceled)
        {
            IsShooting = false;
        }
    }

    public void UpdateShoot()
    {
        if (m_Timer <= 0)
        {
            if (IsShooting && RemainShootPower > PerShootCost)
            {
                ShootOneBullet();
                m_Timer = ShootIntervalTime;
            }
        }
        else
        {
            m_Timer -= Time.deltaTime;
        }

        if (!IsShooting)
        {
            if (RemainShootPower < MaxShootPower)
            {
                RemainShootPower += PerTickRecover * Time.deltaTime;
                if (RemainShootPower > MaxShootPower)
                {
                    RemainShootPower = MaxShootPower;
                }
            }
        }

        if (IsShooting)
        {
            m_Anim.SetBool("isShooting", true);

        }
        else
        {
            m_Anim.SetBool("isShooting", false);
        }
    }

    public void ShootOneBullet()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out RaycastHit hit, float.MaxValue, ShootLayer, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.transform.name);
            CenterPoint = hit.point;
            if (hit.transform.TryGetComponent(out EnemyHit enemyHit))
            {

                enemyHit.ApplyDamage(Damage);
            }
        }

        m_Source.PlayOneShot(ShootClip);
        RemainShootPower -= PerShootCost;
        Salt.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(CenterPoint, 0.1f);
    }


  

   

    
}
