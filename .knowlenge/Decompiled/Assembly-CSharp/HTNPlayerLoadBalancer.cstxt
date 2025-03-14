using Apex.LoadBalancing;

public sealed class HTNPlayerLoadBalancer : Apex.LoadBalancing.LoadBalancer
{
	public static readonly ILoadBalancer HTNPlayerBalancer = new LoadBalancedQueue(50, 0.1f, 50, 4);

	private HTNPlayerLoadBalancer()
	{
	}
}
