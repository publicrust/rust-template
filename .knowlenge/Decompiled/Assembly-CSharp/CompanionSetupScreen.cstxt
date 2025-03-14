using Rust.UI;
using UnityEngine;

public class CompanionSetupScreen : SingletonComponent<CompanionSetupScreen>
{
	public enum ScreenState
	{
		Loading,
		Error,
		NoServer,
		NotSupported,
		NotInstalled,
		Disabled,
		Enabled,
		ShowHelp
	}

	public const string PairedKey = "companionPaired";

	public GameObject instructionsBody;

	public GameObject detailsPanel;

	public GameObject loadingMessage;

	public GameObject errorMessage;

	public GameObject notSupportedMessage;

	public GameObject disabledMessage;

	public GameObject enabledMessage;

	public GameObject refreshButton;

	public GameObject enableButton;

	public GameObject disableButton;

	public GameObject pairButton;

	public RustText serverName;

	public RustButton helpButton;
}
