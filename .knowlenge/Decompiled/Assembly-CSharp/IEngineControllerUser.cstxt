using System;
using Rust;

public interface IEngineControllerUser : IEntity
{
	bool HasFlag(BaseEntity.Flags f);

	bool IsDead();

	void SetFlag(BaseEntity.Flags f, bool b, bool recursive = false, bool networkupdate = true);

	void Invoke(Action action, float time);

	void CancelInvoke(Action action);

	void OnEngineStartFailed();

	bool MeetsEngineRequirements();
}
