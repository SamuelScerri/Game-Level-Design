using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 100;
    private Animator animator;
    public GameObject[] itemDrops;
    private Interactor interactor;
    private HealthManager healthManager;
    private AudioSource walk, run, attack, die;

    public void Start()
    {
        animator = GetComponent<Animator>();

        GameObject player = GameObject.FindWithTag("Player");

        interactor = player.GetComponent<Interactor>();

        healthManager = player.GetComponent<HealthManager>();

        Component[] audioSources = GetComponents(typeof(AudioSource));

        walk = (AudioSource) audioSources[3];
        run = (AudioSource) audioSources[2];
        attack = (AudioSource) audioSources[1];
        die = (AudioSource) audioSources[0];
    }

    public void SetHealth(int amount)
    {
        HP = amount;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        interactor.IncreaseScore(10);
        if(HP <= 0)
        {
            Die();
        }
        else{
            //Play Damage Animation
            animator.SetTrigger("damage");
        }
    }

    public void StopFootsteps()
    {
        run.Stop();
        walk.Stop();
    }

    public void FootstepsWalk()
    {
        walk.Play();
        run.Stop();
    }

    public void FootstepsRun()
    {
        run.Play();
        walk.Stop();
    }

    public void Die()
    {
        run.Stop();
        walk.Stop();
        die.Play();
        interactor.IncreaseScore(50);
        //Play Death Animation
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 5);
        ItemDrop();
    }

    public void GiveDamage(int damage) {
        run.Stop();
        walk.Stop();
        attack.Play();
        healthManager.TakeDamage(damage);
    }

    private void ItemDrop()
    {
        int randInt = Random.Range(0, itemDrops.Length);
        if (itemDrops[randInt] !=null)
        {
            Instantiate(itemDrops[randInt], transform.position, Quaternion.identity);
        }
    }
}
