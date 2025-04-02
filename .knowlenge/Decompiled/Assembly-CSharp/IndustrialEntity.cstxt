public class IndustrialEntity : IOEntity
{
	public class IndustrialProcessQueue : ObjectWorkQueue<IndustrialEntity>
	{
		protected override void RunJob(IndustrialEntity job)
		{
			if (job != null)
			{
				job.RunJob();
			}
		}
	}

	public static IndustrialProcessQueue Queue = new IndustrialProcessQueue();

	protected virtual void RunJob()
	{
	}
}
