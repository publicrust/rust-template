using Apex.LoadBalancing;

public sealed class AiManagerLoadBalancer : Apex.LoadBalancing.LoadBalancer
{
	public static readonly ILoadBalancer aiManagerLoadBalancer = new LoadBalancedQueue(1, 2.5f, 1, 4);

	private AiManagerLoadBalancer()
	{
	}
}
