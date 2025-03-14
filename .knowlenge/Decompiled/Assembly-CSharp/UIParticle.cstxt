using UnityEngine;
using UnityEngine.UI;

public class UIParticle : BaseMonoBehaviour
{
	public Vector2 LifeTime;

	public Vector2 Gravity = new Vector2(1000f, 1000f);

	public Vector2 InitialX;

	public Vector2 InitialY;

	public Vector2 InitialScale = Vector2.one;

	public Vector2 InitialDelay;

	public Vector2 ScaleVelocity;

	public Gradient InitialColor;

	private float lifetime;

	private float gravity;

	private Vector2 velocity;

	private float scaleVelocity;

	public static void Add(UIParticle particleSource, RectTransform spawnPosition, RectTransform particleCanvas)
	{
		GameObject obj = Object.Instantiate(particleSource.gameObject);
		obj.transform.SetParent(spawnPosition, worldPositionStays: false);
		obj.transform.localPosition = new Vector3(Random.Range(0f, spawnPosition.rect.width) - spawnPosition.rect.width * spawnPosition.pivot.x, Random.Range(0f, spawnPosition.rect.height) - spawnPosition.rect.height * spawnPosition.pivot.y, 0f);
		obj.transform.SetParent(particleCanvas, worldPositionStays: true);
		obj.transform.localScale = Vector3.one;
		obj.transform.localRotation = Quaternion.identity;
	}

	private void Start()
	{
		base.transform.localScale *= Random.Range(InitialScale.x, InitialScale.y);
		velocity.x = Random.Range(InitialX.x, InitialX.y);
		velocity.y = Random.Range(InitialY.x, InitialY.y);
		gravity = Random.Range(Gravity.x, Gravity.y);
		scaleVelocity = Random.Range(ScaleVelocity.x, ScaleVelocity.y);
		Image component = GetComponent<Image>();
		if ((bool)component)
		{
			component.color = InitialColor.Evaluate(Random.Range(0f, 1f));
		}
		lifetime = Random.Range(InitialDelay.x, InitialDelay.y) * -1f;
		if (lifetime < 0f)
		{
			GetComponent<CanvasGroup>().alpha = 0f;
		}
		Invoke(Die, Random.Range(LifeTime.x, LifeTime.y) + lifetime * -1f);
	}

	private void Update()
	{
		if (lifetime < 0f)
		{
			lifetime += Time.deltaTime;
			if (lifetime < 0f)
			{
				return;
			}
			GetComponent<CanvasGroup>().alpha = 1f;
		}
		else
		{
			lifetime += Time.deltaTime;
		}
		Vector3 position = base.transform.position;
		Vector3 localScale = base.transform.localScale;
		velocity.y -= gravity * Time.deltaTime;
		position.x += velocity.x * Time.deltaTime;
		position.y += velocity.y * Time.deltaTime;
		localScale += Vector3.one * scaleVelocity * Time.deltaTime;
		if (localScale.x <= 0f || localScale.y <= 0f)
		{
			Die();
			return;
		}
		base.transform.position = position;
		base.transform.localScale = localScale;
	}

	private void Die()
	{
		Object.Destroy(base.gameObject);
	}
}
