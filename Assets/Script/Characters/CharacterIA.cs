
using System.Collections;
using UnityEngine;


public class CharacterIA : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    private static CharacterIA _instance;
    public static CharacterIA Instance => _instance;
    private Animator _animator;
    private DamageIA _damage;
    public float health = 100f;
    private AiInput _agent;

    public void Awake()
    {
        _instance = this;
        _animator = GetComponent<Animator>();
        //_agent = GetComponent<AiInput>();
    }

    private void Start()
    {
        _damage = FindObjectOfType<DamageIA>();
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
    public void WalkAnimationsIA(float VelX)
    {
        _animator.SetFloat("VelX", VelX);
    }

    public void IGetDamage(float damageRecive)
    {
        health -= damageRecive;
    }
    public void AttackAnimations(int selector)
    {
        switch(selector)
        {
            case 0: 
                _animator.SetTrigger("Attack1");
                _damage.Atacar(5);
                break;

            case 1: _animator.SetTrigger("Attack2");
                _damage.Atacar(13);
                break;
        }

    }
    public void Die()
    {
        _animator.SetTrigger("Death");
        
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Life");
        health = 100;
    }

}
