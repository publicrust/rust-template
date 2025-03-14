using Apex.LoadBalancing;

public sealed class AnimalSensesLoadBalancer : Apex.LoadBalancing.LoadBalancer
{
	public static readonly ILoadBalancer animalSensesLoadBalancer = new LoadBalancedQueue(300, 0.1f, 50, 4);

	private AnimalSensesLoadBalancer()
	{
	}
}
