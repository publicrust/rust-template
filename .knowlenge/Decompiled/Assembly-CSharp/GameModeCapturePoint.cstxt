using Facepunch;
using ProtoBuf;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameModeCapturePoint : BaseEntity
{
	public CapturePointTrigger captureTrigger;

	public float timeToCapture = 3f;

	public int scorePerSecond = 1;

	public string scoreName = "score";

	private float captureFraction;

	private int captureTeam = -1;

	private int capturingTeam = -1;

	public EntityRef capturingPlayer;

	public EntityRef capturedPlayer;

	public const Flags Flag_Contested = Flags.Busy;

	public RustText capturePointText;

	public RustText captureOwnerName;

	public Image captureProgressImage;

	public GameObjectRef progressBeepEffect;

	public GameObjectRef progressCompleteEffect;

	public Transform computerPoint;

	private float nextBeepTime;

	public bool IsContested()
	{
		return HasFlag(Flags.Busy);
	}

	public override void ServerInit()
	{
		base.ServerInit();
		InvokeRepeating(AssignPoints, 0f, 1f);
	}

	public void Update()
	{
		if (!base.isClient)
		{
			UpdateCaptureAmount();
		}
	}

	public void AssignPoints()
	{
		BaseGameMode activeGameMode = BaseGameMode.GetActiveGameMode(serverside: true);
		if (activeGameMode == null || !activeGameMode.IsMatchActive())
		{
			return;
		}
		if (activeGameMode.IsTeamGame())
		{
			if (captureTeam != -1 && captureFraction == 1f)
			{
				activeGameMode.ModifyTeamScore(captureTeam, scorePerSecond);
			}
		}
		else if (capturedPlayer.IsValid(serverside: true))
		{
			activeGameMode.ModifyPlayerGameScore(capturedPlayer.Get(serverside: true).GetComponent<BasePlayer>(), "score", scorePerSecond);
		}
	}

	public void DoCaptureEffect()
	{
		Effect.server.Run(progressCompleteEffect.resourcePath, computerPoint.position);
	}

	public void DoProgressEffect()
	{
		if (!(Time.time < nextBeepTime))
		{
			Effect.server.Run(progressBeepEffect.resourcePath, computerPoint.position);
			nextBeepTime = Time.time + 0.5f;
		}
	}

	public void UpdateCaptureAmount()
	{
		if (base.isClient)
		{
			return;
		}
		float num = captureFraction;
		BaseGameMode activeGameMode = BaseGameMode.GetActiveGameMode(serverside: true);
		if (activeGameMode == null)
		{
			return;
		}
		if (captureTrigger.entityContents == null)
		{
			SetFlag(Flags.Busy, b: false, recursive: false, networkupdate: false);
		}
		else
		{
			if (!activeGameMode.IsMatchActive())
			{
				return;
			}
			if (activeGameMode.IsTeamGame())
			{
				int[] array = new int[activeGameMode.GetNumTeams()];
				foreach (BaseEntity entityContent in captureTrigger.entityContents)
				{
					if (!(entityContent == null) && !entityContent.isClient)
					{
						BasePlayer component = entityContent.GetComponent<BasePlayer>();
						if (!(component == null) && component.IsAlive() && !component.IsNpc && component.gamemodeteam != -1)
						{
							array[component.gamemodeteam]++;
						}
					}
				}
				int num2 = 0;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] > 0)
					{
						num2++;
					}
				}
				if (num2 < 2)
				{
					int num3 = -1;
					int num4 = 0;
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j] > num4)
						{
							num4 = array[j];
							num3 = j;
						}
					}
					if (captureTeam == -1 && captureFraction == 0f)
					{
						capturingTeam = num3;
					}
					if (captureFraction > 0f && num3 != captureTeam && num3 != capturingTeam)
					{
						captureFraction = Mathf.Clamp01(captureFraction - Time.deltaTime / timeToCapture);
						if (captureFraction == 0f)
						{
							captureTeam = -1;
						}
					}
					else if (captureTeam == -1 && captureFraction < 1f && capturingTeam == num3)
					{
						DoProgressEffect();
						captureFraction = Mathf.Clamp01(captureFraction + Time.deltaTime / timeToCapture);
						if (captureFraction == 1f)
						{
							DoCaptureEffect();
							captureTeam = num3;
						}
					}
				}
				SetFlag(Flags.Busy, num2 > 1);
			}
			else
			{
				if (!capturingPlayer.IsValid(serverside: true) && !capturedPlayer.IsValid(serverside: true))
				{
					captureFraction = 0f;
				}
				if (captureTrigger.entityContents.Count == 0)
				{
					capturingPlayer.Set(null);
				}
				if (captureTrigger.entityContents.Count == 1)
				{
					foreach (BaseEntity entityContent2 in captureTrigger.entityContents)
					{
						BasePlayer component2 = entityContent2.GetComponent<BasePlayer>();
						if (component2 == null)
						{
							continue;
						}
						if (!capturedPlayer.IsValid(serverside: true) && captureFraction == 0f)
						{
							capturingPlayer.Set(component2);
						}
						if (captureFraction > 0f && component2 != capturedPlayer.Get(serverside: true) && component2 != capturingPlayer.Get(serverside: true))
						{
							captureFraction = Mathf.Clamp01(captureFraction - Time.deltaTime / timeToCapture);
							if (captureFraction == 0f)
							{
								capturedPlayer.Set(null);
							}
						}
						else if (!capturedPlayer.Get(serverside: true) && captureFraction < 1f && capturingPlayer.Get(serverside: true) == component2)
						{
							DoProgressEffect();
							captureFraction = Mathf.Clamp01(captureFraction + Time.deltaTime / timeToCapture);
							if (captureFraction == 1f)
							{
								DoCaptureEffect();
								capturedPlayer.Set(component2);
							}
						}
						break;
					}
				}
				SetFlag(Flags.Busy, captureTrigger.entityContents.Count > 1);
			}
			if (num != captureFraction)
			{
				SendNetworkUpdate();
			}
		}
	}

	public override void Save(SaveInfo info)
	{
		base.Save(info);
		info.msg.ioEntity = Pool.Get<ProtoBuf.IOEntity>();
		info.msg.ioEntity.genericFloat1 = captureFraction;
		info.msg.ioEntity.genericInt1 = captureTeam;
		info.msg.ioEntity.genericInt2 = capturingTeam;
		info.msg.ioEntity.genericEntRef1 = capturedPlayer.uid;
		info.msg.ioEntity.genericEntRef2 = capturingPlayer.uid;
	}
}
