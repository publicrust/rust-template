using UnityEngine;

public interface IRemoteControllable
{
	bool RequiresMouse { get; }

	float MaxRange { get; }

	RemoteControllableControls RequiredControls { get; }

	CameraViewerId? ControllingViewerId { get; }

	bool CanPing { get; }

	Transform GetEyes();

	float GetFovScale();

	BaseEntity GetEnt();

	string GetIdentifier();

	float Health();

	float MaxHealth();

	void UpdateIdentifier(string newID, bool clientSend = false);

	void RCSetup();

	void RCShutdown();

	bool CanControl(ulong playerID);

	void UserInput(InputState inputState, CameraViewerId viewerID);

	bool InitializeControl(CameraViewerId viewerID);

	void StopControl(CameraViewerId viewerID);
}
