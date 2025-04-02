using UnityEngine;

public class v_chainsaw : MonoBehaviour
{
	public bool bAttacking;

	public bool bHitMetal;

	public bool bHitWood;

	public bool bHitFlesh;

	public bool bEngineOn;

	public ParticleSystem[] hitMetalFX;

	public ParticleSystem[] hitWoodFX;

	public ParticleSystem[] hitFleshFX;

	public SoundDefinition hitMetalSoundDef;

	public SoundDefinition hitWoodSoundDef;

	public SoundDefinition hitFleshSoundDef;

	public Sound hitSound;

	public GameObject hitSoundTarget;

	public float hitSoundFadeTime = 0.1f;

	public ParticleSystem smokeEffect;

	public Animator chainsawAnimator;

	public Renderer chainRenderer;

	public Material chainlink;

	private MaterialPropertyBlock block;

	private Vector2 saveST;

	private float chainSpeed;

	private float chainAmount;

	public float temp1;

	public float temp2;

	public void OnEnable()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		if (block == null)
		{
			block = new MaterialPropertyBlock();
		}
		saveST = Vector4.op_Implicit(chainRenderer.sharedMaterial.GetVector("_MainTex_ST"));
	}

	private void Awake()
	{
		chainlink = chainRenderer.sharedMaterial;
	}

	private void Start()
	{
	}

	private void ScrollChainTexture()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		float num = (chainAmount = (chainAmount + Time.deltaTime * chainSpeed) % 1f);
		block.Clear();
		block.SetVector("_MainTex_ST", new Vector4(saveST.x, saveST.y, num, 0f));
		chainRenderer.SetPropertyBlock(block);
	}

	private void Update()
	{
		chainsawAnimator.SetBool("attacking", bAttacking);
		smokeEffect.enableEmission = bEngineOn;
		if (bHitMetal)
		{
			chainsawAnimator.SetBool("attackHit", true);
			ParticleSystem[] array = hitMetalFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = true;
			}
			array = hitWoodFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			array = hitFleshFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			DoHitSound(hitMetalSoundDef);
		}
		else if (bHitWood)
		{
			chainsawAnimator.SetBool("attackHit", true);
			ParticleSystem[] array = hitMetalFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			array = hitWoodFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = true;
			}
			array = hitFleshFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			DoHitSound(hitWoodSoundDef);
		}
		else if (bHitFlesh)
		{
			chainsawAnimator.SetBool("attackHit", true);
			ParticleSystem[] array = hitMetalFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			array = hitWoodFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			array = hitFleshFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = true;
			}
			DoHitSound(hitFleshSoundDef);
		}
		else
		{
			chainsawAnimator.SetBool("attackHit", false);
			ParticleSystem[] array = hitMetalFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			array = hitWoodFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
			array = hitFleshFX;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enableEmission = false;
			}
		}
	}

	private void DoHitSound(SoundDefinition soundDef)
	{
	}
}
