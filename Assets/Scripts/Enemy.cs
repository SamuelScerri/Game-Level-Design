using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 100;
    private Animator animator;
    public GameObject[] itemDrops;
    private Interactor interactor;

    public void Start()
    {
        animator = GetComponent<Animator>();

        GameObject player = GameObject.FindWithTag("Player");

        interactor = player.GetComponent<Interactor>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        interactor.IncreaseScore(10);
        if(HP <= 0)
        {
            interactor.IncreaseScore(50);
            //Play Death Animation
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 5);
            ItemDrop();
        }
        else{
            //Play Damage Animation
            animator.SetTrigger("damage");
        }
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
