public class PriorityListComponent<T> : ListComponent<T> where T : PriorityListComponent<T>
{
	public static T Instance { get; private set; }

	public virtual int Priority => 100;

	public override void Setup()
	{
		base.Setup();
		UpdateInstance();
	}

	public override void Clear()
	{
		base.Clear();
		UpdateInstance();
	}

	private static void UpdateInstance()
	{
		if (ListComponent<T>.InstanceList.Count == 0)
		{
			Instance = null;
			return;
		}
		T instance = null;
		int num = int.MinValue;
		for (int num2 = ListComponent<T>.InstanceList.Count; num2 >= 0; num2--)
		{
			T val = ListComponent<T>.InstanceList[num2];
			if (!(val == null))
			{
				int priority = val.Priority;
				if (priority > num)
				{
					instance = val;
					num = priority;
				}
			}
		}
		Instance = instance;
	}
}
