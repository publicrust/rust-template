using UnityEngine;

public class BaseAIBrain<T> : EntityComponent<T> where T : BaseEntity
{
	public class BasicAIState
	{
		private int myIndex;

		public BaseAIBrain<T> brain;

		protected float _timeInState;

		protected float _lastStateExitTime;

		public virtual void StateEnter()
		{
			_timeInState = 0f;
		}

		public virtual void StateThink(float delta)
		{
			_timeInState += delta;
		}

		public virtual void StateLeave()
		{
			_timeInState = 0f;
			_lastStateExitTime = Time.time;
		}

		public virtual bool CanInterrupt()
		{
			return true;
		}

		public virtual float GetWeight()
		{
			return 0f;
		}

		public void SetIndex(int newIndex)
		{
			if (myIndex == 0)
			{
				myIndex = newIndex;
			}
		}

		public float TimeInState()
		{
			return _timeInState;
		}

		public float TimeSinceState()
		{
			return Time.time - _lastStateExitTime;
		}

		public void Reset()
		{
			_timeInState = 0f;
		}

		public bool IsInState()
		{
			if (brain != null)
			{
				return brain.GetCurrentState() == this;
			}
			return false;
		}

		public virtual void DrawGizmos()
		{
		}

		public T GetEntity()
		{
			return brain.GetEntity();
		}
	}

	public BasicAIState[] AIStates;

	public const int AIStateIndex_UNSET = 0;

	public int _currentState;

	public Vector3 mainInterestPoint;

	public virtual bool ShouldThink()
	{
		return true;
	}

	public virtual void DoThink()
	{
	}

	public T GetEntity()
	{
		return base.baseEntity;
	}

	public void Awake()
	{
		InitializeAI();
	}

	public virtual void InitializeAI()
	{
	}

	public virtual void AddState(BasicAIState newState, int newIndex)
	{
		newState.SetIndex(newIndex);
		AIStates[newIndex] = newState;
		newState.brain = this;
		newState.Reset();
	}

	public BasicAIState GetCurrentState()
	{
		if (AIStates == null)
		{
			return null;
		}
		return AIStates[_currentState];
	}

	public BasicAIState GetState(int index)
	{
		return AIStates[index];
	}

	public void SwitchToState(int newState)
	{
		BasicAIState currentState = GetCurrentState();
		BasicAIState state = GetState(newState);
		if (currentState != null)
		{
			if (currentState == state || !currentState.CanInterrupt())
			{
				return;
			}
			currentState.StateLeave();
		}
		_currentState = newState;
		state.StateEnter();
	}

	public virtual void AIThink(float delta)
	{
		BasicAIState currentState = GetCurrentState();
		currentState?.StateThink(delta);
		if (currentState != null && !currentState.CanInterrupt())
		{
			return;
		}
		float num = 0f;
		int newState = 0;
		BasicAIState basicAIState = null;
		for (int i = 0; i < AIStates.Length; i++)
		{
			BasicAIState basicAIState2 = AIStates[i];
			if (basicAIState2 != null)
			{
				float weight = basicAIState2.GetWeight();
				if (weight > num)
				{
					num = weight;
					newState = i;
					basicAIState = basicAIState2;
				}
			}
		}
		if (basicAIState != currentState)
		{
			SwitchToState(newState);
		}
	}
}
