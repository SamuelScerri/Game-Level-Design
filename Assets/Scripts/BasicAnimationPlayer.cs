using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimationPlayer : MonoBehaviour
{
	public void PlayAnimation()
	{
		GetComponent<Animation>().Play();
	}
}
