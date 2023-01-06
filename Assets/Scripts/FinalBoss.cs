using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AttackMode
{
	NormalMode,
	RetreatMode,
	ChargeMode,
	Dead
};

public class FinalBoss : MonoBehaviour
{
	private NavMeshAgent _agent;
	private Animator _animator;
	private GameObject _player;

	private AudioSource _attackSound, _hurtSound, _hitSound;

	[SerializeField]
	private AttackMode _attackMode;

	[SerializeField]
	private float _attackRadius, _attackCooldown, _attackTime;

	[SerializeField]
	private float _normalSpeed, _retreatSpeed, _chargingSpeed;

	[SerializeField]
	private int _damageAmountToRetreat;
	private int _currentDamageAmount;

	[SerializeField]
	private List<Vector3> _chargingAreas;

	[SerializeField]
	private int _health;

	private Coroutine _attackCoroutine;
	private Coroutine _chargeCoroutine;

	//We Will Use This Value To Ensure That The Zombie Will Run With The Correct Speed
	private const float _runAnimationSpeed = 2.781f;
	private const float _crawlAnimationSpeed = .523f * 8;

	private float _deathAnimationDamp;
	private float _runAnimationDamp;
	private float _crouchAnimationDamp;

	private float _runLayerDamp;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_agent = GetComponent<NavMeshAgent>();

		_agent.speed = _normalSpeed;

		_chargingAreas = new List<Vector3>();

		foreach (GameObject chargingObject in GameObject.FindGameObjectsWithTag("ChargeArea"))
			_chargingAreas.Add(chargingObject.transform.position);

		_player = GameObject.FindWithTag("Player");

		_currentDamageAmount = _damageAmountToRetreat;
	}

	public void TakeDamage(int amount)
	{
		if (_attackMode == AttackMode.NormalMode)
		{
			_animator.SetTrigger("Hurt");
			_health -= amount;
			_currentDamageAmount -= amount;
		}

		if (_currentDamageAmount <= 0)
		{
			//If The Player Damages The Boss Enough, He Will Now Attempt To Charge Them
			_attackMode = AttackMode.RetreatMode;
			_agent.speed = _retreatSpeed;

			_animator.SetTrigger("Retreat");

			_agent.SetDestination(GetFurthestChargingArea());
			_currentDamageAmount = _damageAmountToRetreat;
		}

		if (_health <= 0 && _attackMode != AttackMode.Dead)
			Die();
	}

	private void Update()
	{
		if (_attackMode == AttackMode.NormalMode)
			NormalMode();

		else if (_attackMode == AttackMode.RetreatMode)
			RetreatMode();

		else if (_attackMode == AttackMode.ChargeMode)
			ChargeMode();

		else if (_attackMode == AttackMode.Dead)
			_animator.SetLayerWeight(4, Mathf.SmoothDamp(_animator.GetLayerWeight(4), 1, ref _deathAnimationDamp, .2f));

		float finalRunSpeed = _agent.velocity.magnitude / _agent.speed;

		_animator.SetFloat("Run Speed", _agent.velocity.magnitude / _runAnimationSpeed);
		_animator.SetFloat("Crawl Speed", _agent.velocity.magnitude / _crawlAnimationSpeed);
		_animator.SetLayerWeight(1, Mathf.SmoothDamp(_animator.GetLayerWeight(1), finalRunSpeed, ref _runAnimationDamp, .1f));

		_agent.acceleration = _agent.speed * 2;
	}

	private void NormalMode()
	{
		_agent.SetDestination(_player.transform.position);

		if (Vector3.Distance(transform.position, _player.transform.position) < _attackRadius && _attackCoroutine == null)
		{
			_attackCoroutine = StartCoroutine(Attack());
		}
	}

	//Here The Boss Will Go To The Charging Location, When It Arrives To Its Destination, It Will Begin To Charge
	private void RetreatMode()
	{
		_agent.stoppingDistance = 0;

		Vector3 lookPosition = _player.transform.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(lookPosition);

		if (_agent.remainingDistance == 0 && _agent.pathStatus == NavMeshPathStatus.PathComplete)
		{
			//When The Boss Has Arrived, Start Turning Towards The Player
			if (_chargeCoroutine == null)
			{
				
				_chargeCoroutine = StartCoroutine(PrepareCharge());
			}
			else
				transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2);
		}
	}

	private void ChargeMode()
	{
		if (_agent.remainingDistance == 0 && _agent.pathStatus == NavMeshPathStatus.PathComplete)
			_attackMode = AttackMode.NormalMode;

		if (Vector3.Distance(transform.position, _agent.destination) < _attackRadius + 1 && _attackCoroutine == null)
			_attackCoroutine = StartCoroutine(Attack());
	}

	//Here The Boss Will Run To The Player And Attack When In Range
	private IEnumerator Attack()
	{
		_animator.SetTrigger("Attack");
		yield return new WaitForSeconds(_attackTime);


		//Check If The Boss Is Still In Range
		if (Vector3.Distance(transform.position, _player.transform.position) < _attackRadius)
		{
			_player.GetComponent<HealthManager>().TakeDamage(5);
			//_hitSound.Play();
		}

		yield return new WaitForSeconds(_attackCooldown - _attackTime);

		_attackCoroutine = null;
	}

	//Here We Will Find The Charging Area That Is The Furthest Away From The Player
	private Vector3 GetFurthestChargingArea()
	{
		Vector3 furthestArea = Vector3.zero;
		float furthestDistance = 0;

		foreach(Vector3 area in _chargingAreas)
		{
			float distance = Vector3.Distance(_player.transform.position, area);

			if (distance > furthestDistance)
			{
				furthestDistance = distance;
				furthestArea = area;
			}
		}

		return furthestArea;
	}

	//Here The Boss Will Look At The Player And Will Begin The Charge
	private IEnumerator PrepareCharge()
	{
		_agent.stoppingDistance = 3;
		_animator.SetTrigger("Scream");
		_animator.SetTrigger("Run");


		yield return new WaitForSeconds(1);
		_attackMode = AttackMode.ChargeMode;
		_agent.speed = _chargingSpeed;
		_agent.SetDestination(_player.transform.position);

		_chargeCoroutine = null;
	}

	private void Die()
	{
		_attackMode = AttackMode.Dead;
		_animator.SetTrigger("Dead");

		_agent.ResetPath();
		
	}
}
