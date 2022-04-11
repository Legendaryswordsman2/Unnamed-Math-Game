using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswerScreen : MonoBehaviour
{
	private void OnEnable()
	{
		StartCoroutine(disable());
	}

	IEnumerator disable()
	{
		yield return new WaitForSeconds(0.2f);
		gameObject.SetActive(false);
	}
}
