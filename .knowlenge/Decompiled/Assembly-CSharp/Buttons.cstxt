using UnityEngine;

public class Buttons
{
	public class ConButton : IConsoleButton
	{
		private int frame;

		private TimeSince _timePressed;

		public bool IsDown { get; set; }

		public TimeSince TimePressed
		{
			get
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				if (!IsDown)
				{
					return TimeSince.op_Implicit(0f);
				}
				return _timePressed;
			}
		}

		public bool JustPressed
		{
			get
			{
				if (IsDown)
				{
					return frame == Time.frameCount;
				}
				return false;
			}
		}

		public bool JustReleased
		{
			get
			{
				if (!IsDown)
				{
					return frame == Time.frameCount;
				}
				return false;
			}
		}

		public bool IsPressed
		{
			get
			{
				return IsDown;
			}
			set
			{
				//IL_0022: Unknown result type (might be due to invalid IL or missing references)
				//IL_0027: Unknown result type (might be due to invalid IL or missing references)
				if (value != IsDown)
				{
					IsDown = value;
					frame = Time.frameCount;
					_timePressed = TimeSince.op_Implicit(0f);
				}
			}
		}

		public void Call(Arg arg)
		{
		}
	}
}
