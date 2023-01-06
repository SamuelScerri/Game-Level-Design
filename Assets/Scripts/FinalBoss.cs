using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBoss : MonoBehaviour
{
	private NavMeshAgent _agent;
	private Animator _animator;
	private GameObject _player;

	[SerializeField]
	private float _attackRadius, _attackCooldown, _attackTime;

	private Coroutine _attackCoroutine;


	//We Will Use This Value To Ensure That The Zombie Will Run With The Correct Speed
	private const float _runAnimationSpeed = 2.781f;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_agent = GetComponent<NavMeshAgent>();

		_player = GameObject.FindWithTag("Player");
	}

	private void Update()
	{
		_agent.SetDestination(_player.transform.position);

		_animator.SetFloat("Run Speed", _agent.velocity.magnitude / _runAnimationSpeed);
		_animator.SetLayerWeight(1, _animator.GetFloat("Run Speed"));

		if (Vector3.Distance(transform.position, _player.transform.position) < _attackRadius && _attackCoroutine == null)
		{
			_animator.SetTrigger("Attack");
			_attackCoroutine = StartCoroutine(Attack());
		}
	}

	private IEnumerator Attack()
	{
		yield return new WaitForSeconds(_attackTime);


		//Check If The Boss Is Still In Range
		if (Vector3.Distance(transform.position, _player.transform.position) < _attackRadius)
			_player.GetComponent<HealthManager>().TakeDamage(5);

		yield return new WaitForSeconds(_attackCooldown);

		_attackCoroutine = null;
	}
}
