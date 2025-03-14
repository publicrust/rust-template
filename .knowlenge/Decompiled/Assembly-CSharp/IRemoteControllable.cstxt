using UnityEngine;

public interface IRemoteControllable
{
	Transform GetEyes();

	BaseEntity GetEnt();

	bool Occupied();

	void UpdateIdentifier(string newID, bool clientSend = false);

	string GetIdentifier();

	void RCSetup();

	void RCShutdown();

	bool CanControl();

	void UserInput(InputState inputState, BasePlayer player);

	void InitializeControl(BasePlayer controller);

	void StopControl();
}
