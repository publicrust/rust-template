using System;
using System.Collections.Generic;
using Apex.AI;
using Rust.Ai;
using UnityEngine;
using UnityEngine.AI;

public interface IAIAgent
{
	BaseNpc.AiStatistics GetStats { get; }

	NavMeshAgent GetNavAgent { get; }

	bool AgencyUpdateRequired { get; set; }

	bool IsOnOffmeshLinkAndReachedNewCoord { get; set; }

	Vector3 Destination { get; set; }

	bool IsStopped { get; set; }

	bool AutoBraking { get; set; }

	bool HasPath { get; }

	bool IsDormant { get; set; }

	float TimeAtDestination { get; }

	bool IsStuck { get; }

	float TargetSpeed { get; set; }

	BaseEntity FoodTarget { get; set; }

	float GetAttackRate { get; }

	float GetAttackRange { get; }

	Vector3 GetAttackOffset { get; }

	BaseEntity AttackTarget { get; set; }

	float AttackTargetVisibleFor { get; }

	Memory.SeenInfo AttackTargetMemory { get; set; }

	BaseCombatEntity CombatTarget { get; }

	Vector3 AttackPosition { get; }

	Vector3 CrouchedAttackPosition { get; }

	Vector3 CurrentAimAngles { get; }

	Vector3 SpawnPosition { get; set; }

	BaseCombatEntity Entity { get; }

	float GetAttackCost { get; }

	float GetStamina { get; }

	float GetEnergy { get; }

	float GetSleep { get; }

	float GetStuckDuration { get; }

	float GetLastStuckTime { get; }

	float currentBehaviorDuration { get; }

	BaseNpc.Behaviour CurrentBehaviour { get; set; }

	int AgentTypeIndex { get; set; }

	IAIContext GetContext(Guid aiId);

	bool IsNavRunning();

	void Pause();

	void Resume();

	void SetTargetPathStatus(float pendingDelay = 0.05f);

	void UpdateDestination(Vector3 newDestination);

	void UpdateDestination(Transform tx);

	void StopMoving();

	bool WantsToEat(BaseEntity eatable);

	void Eat();

	void StartAttack();

	void StartAttack(AttackOperator.AttackType type, BaseCombatEntity target);

	bool AttackReady();

	float GetWantsToAttack(BaseEntity target);

	float FearLevel(BaseEntity ent);

	float GetActiveAggressionRangeSqr();

	bool BusyTimerActive();

	void SetBusyFor(float dur);

	byte GetFact(BaseNpc.Facts fact);

	void SetFact(BaseNpc.Facts fact, byte value, bool triggerCallback = true, bool onlyTriggerCallbackOnDiffValue = true);

	float ToSpeed(BaseNpc.SpeedEnum speed);

	List<NavPointSample> RequestNavPointSamplesInCircle(NavPointSampler.SampleCount sampleCount, float radius, NavPointSampler.SampleFeatures features = NavPointSampler.SampleFeatures.None);

	List<NavPointSample> RequestNavPointSamplesInCircleWaterDepthOnly(NavPointSampler.SampleCount sampleCount, float radius, float waterDepth);

	byte GetFact(NPCPlayerApex.Facts fact);

	void SetFact(NPCPlayerApex.Facts fact, byte value, bool triggerCallback = true, bool onlyTriggerCallbackOnDiffValue = true);

	float ToSpeed(NPCPlayerApex.SpeedEnum speed);

	int TopologyPreference();
}
