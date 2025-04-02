using System;
using UnityEngine;

public abstract class FacepunchBehaviour : MonoBehaviour
{
	public void Invoke(Action action, float time)
	{
		InvokeHandler.Invoke(this, action, time);
	}

	public void Invoke(Action action, float time, float random)
	{
		time += UnityEngine.Random.Range(0f - random, random);
		InvokeHandler.Invoke(this, action, time);
	}

	public void InvokeRepeating(Action action, float time, float repeat)
	{
		InvokeHandler.InvokeRepeating(this, action, time, repeat);
	}

	public void InvokeRandomized(Action action, float time, float repeat, float random)
	{
		InvokeHandler.InvokeRandomized(this, action, time, repeat, random);
	}

	public void CancelInvoke(Action action)
	{
		InvokeHandler.CancelInvoke(this, action);
	}

	public bool IsInvoking(Action action)
	{
		return InvokeHandler.IsInvoking(this, action);
	}

	public void InvokeRepeatingFixedTime(Action action)
	{
		InvokeHandlerFixedTime.InvokeRepeating(this, action, 0.01f, 0.01f);
	}

	public void InvokeRandomizedFixedTime(Action action, float time, float repeat, float random)
	{
		InvokeHandlerFixedTime.InvokeRandomized(this, action, time, repeat, random);
	}

	public void CancelInvokeFixedTime(Action action)
	{
		InvokeHandlerFixedTime.CancelInvoke(this, action);
	}

	public bool IsInvokingFixedTime(Action action)
	{
		return InvokeHandlerFixedTime.IsInvoking(this, action);
	}
}
