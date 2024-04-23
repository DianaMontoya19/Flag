using System;
using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    private static Character _instance;
    public static Character Instance => _instance;
    public float health = 100f;
    public bool _isAttacking;
    public float velocity;
    public float defense;
    public float attack;


    private Animator _animator;

    public delegate void AttackStateChanged(bool isAttacking);
    public event AttackStateChanged OnAttackStateChanged;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _instance = this;
    }
    public void WalkAnimations(float VelY, float VelX)
    {
        _animator.SetFloat("VelX", VelY);
        _animator.SetFloat("VelY", VelX);
    }

    public void ActivateFoots(bool state)
    {
        
        if (state)
        {
            dirtFoots.Play();
        }
        else
        {
            dirtFoots.Stop();
        }
    }

    public void AttackAnimations(int selector)
    {
        
        if(selector == 1)
        {
            _animator.SetTrigger("Attack1");
        }
        if (selector == 2)
        {
            _animator.SetTrigger("Attack2");
        }
        if (selector == 3)
        {
            _animator.SetTrigger("Attack3");
        }
        if (selector == 4)
        {
            _animator.SetTrigger("BlockAttack");
        }
        if (selector == 5)
        {
            _animator.SetBool("Block", true);
        }
        else
        {
            _animator.SetBool("Block", false);
        }

    }
    public void SetIsAttacking(bool isAttacking)
    {
        _isAttacking = isAttacking;
        OnAttackStateChanged?.Invoke(isAttacking);
    }

    public void IGetDamage(float damageRecive)
    {
        health -= damageRecive;
    }
    public bool NoAttackking()
    {
        return false;
    }
    public void Die()
    {
      _animator.SetTrigger("Death");
        StartCoroutine(Timer());
        
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        _animator.SetTrigger("Life");
        health = 100;
    }

    public void TakeDamageAnimation()
    {
        _animator.SetTrigger("Hit");
    }
}
