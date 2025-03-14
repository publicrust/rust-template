using UnityEngine;

public class Buttons
{
	public class ConButton : ConsoleSystem.IConsoleButton
	{
		private int frame;

		public bool IsDown { get; set; }

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
				if (value != IsDown)
				{
					IsDown = value;
					frame = Time.frameCount;
				}
			}
		}

		public void Call(ConsoleSystem.Arg arg)
		{
		}
	}
}
