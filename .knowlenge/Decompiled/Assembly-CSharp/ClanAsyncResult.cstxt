using System;
using System.Collections.Generic;
using System.Diagnostics;
using Facepunch;
using UnityEngine;

public sealed class ClanAsyncResult<T> : Pool.IPooled
{
	private readonly List<Action<T>> _callbacks = new List<Action<T>>(4);

	private readonly Stopwatch _sinceStarted = new Stopwatch();

	private bool _isComplete;

	private T _result;

	public bool IsStarted => _sinceStarted.IsRunning;

	public float Elapsed => (float)_sinceStarted.Elapsed.TotalSeconds;

	public bool IsComplete => _isComplete;

	public void Start()
	{
		_sinceStarted.Restart();
	}

	public bool TrySetResult(T result)
	{
		if (_isComplete)
		{
			return false;
		}
		_result = result;
		_isComplete = true;
		_sinceStarted.Stop();
		foreach (Action<T> callback in _callbacks)
		{
			try
			{
				callback(_result);
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}
		_callbacks.Clear();
		return true;
	}

	public void OnComplete(Action<T> callback)
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		if (_isComplete)
		{
			try
			{
				callback(_result);
				return;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				return;
			}
		}
		_callbacks.Add(callback);
	}

	private void Reset()
	{
		_callbacks.Clear();
		_sinceStarted.Reset();
		_isComplete = false;
		_result = default(T);
	}

	void Pool.IPooled.EnterPool()
	{
		Reset();
	}

	void Pool.IPooled.LeavePool()
	{
		Reset();
	}
}
