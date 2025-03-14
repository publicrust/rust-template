using Apex.LoadBalancing;

public sealed class NPCSensesLoadBalancer : Apex.LoadBalancing.LoadBalancer
{
	public static readonly ILoadBalancer NpcSensesLoadBalancer = new LoadBalancedQueue(50, 0.1f, 50, 4);

	private NPCSensesLoadBalancer()
	{
	}
}
