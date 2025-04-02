using Rust.UI;
using UnityEngine;

public class RustUiTest : MonoBehaviour
{
	private static readonly Option[] enumOptions = new Option[3]
	{
		new Option("test.one", "Test One", "testone"),
		new Option("test.two", "Test Two", "testtwo"),
		new Option("test.three", "Test Three", "testthree")
	};

	private static readonly Option[] enumOptionsJustIcons = new Option[5]
	{
		new Option(Icons.Marker),
		new Option(Icons.Peace),
		new Option(Icons.Duck),
		new Option(Icons.MapPin),
		new Option(Icons.Fire)
	};

	private static readonly Option[] enumOptionsWithIcons = new Option[3]
	{
		new Option("test.one", "Test One", "testone", isdefault: false, Icons.UserNinja),
		new Option("test.two", "Test Two", "testtwo", isdefault: false, Icons.BookUser),
		new Option("test.three", "Test Three", "testthree")
	};

	private void Awake()
	{
		TabControl tabControl = Make.Container.TabControl();
		tabControl.SetParent(base.transform);
		tabControl.AddTab("tabcontrol", string.Empty, Icons.Folders);
		TabControl tabControl2 = Make.Container.TabControl("Vertical");
		tabControl2.SetParent(tabControl.Panel("tabcontrol"));
		tabControl2.AddTab("a", string.Empty, Icons.HandHeart);
		tabControl2.AddTab("b", string.Empty, Icons.OilCan);
		tabControl2.AddTab("c", string.Empty, Icons.SunCloud);
		tabControl.AddTab("buttons", "Buttons", Icons.Clipboard);
		RustButton rustButton = Make.Button("Button Normal", Icons.Rss);
		rustButton.SetParent(tabControl.Panel("buttons"));
		rustButton.OnPressed.AddListener(delegate
		{
			Debug.Log("Button Pressed");
		});
		RustButton rustButton2 = Make.Button("Button Danger", Icons.ExclamationTriangle, toggle: false, "Danger");
		rustButton2.SetParent(tabControl.Panel("buttons"));
		rustButton2.OnPressed.AddListener(delegate
		{
			Debug.Log("Button Pressed");
		});
		RustButton rustButton3 = Make.Button("Button Success", Icons.InfoSquare, toggle: false, "Success");
		rustButton3.SetParent(tabControl.Panel("buttons"));
		rustButton3.OnPressed.AddListener(delegate
		{
			Debug.Log("Button Pressed");
		});
		tabControl.AddTab("input", "Inputs", Icons.Inbox);
		RustOption rustOption = Make.Option(enumOptions);
		rustOption.SetParent(tabControl.Panel("input"));
		rustOption.OnChanged.AddListener(delegate(Option val)
		{
			Debug.Log("Value Changed: " + val.Value);
		});
		RustInput rustInput = Make.Input("Enter Your Name");
		rustInput.SetParent(tabControl.Panel("input"));
		rustInput.OnValueChanged.AddListener(delegate(string val)
		{
			Debug.Log("Value Changed: " + val);
		});
		RustSlider rustSlider = Make.Slider(0f, 1f, 0.3f);
		rustSlider.SetParent(tabControl.Panel("input"));
		rustSlider.OnChanged.AddListener(delegate(float val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		RustSlider rustSlider2 = Make.Slider(0f, 50f, 3f, integer: true);
		rustSlider2.SetParent(tabControl.Panel("input"));
		rustSlider2.OnChanged.AddListener(delegate(float val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		RustToggle rustToggle = Make.ToggleOnOff();
		rustToggle.SetParent(tabControl.Panel("input"));
		rustToggle.OnChanged.AddListener(delegate(bool val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		RustToggle rustToggle2 = Make.ToggleEnabledDisabled();
		rustToggle2.SetParent(tabControl.Panel("input"));
		rustToggle2.OnChanged.AddListener(delegate(bool val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		RustToggle rustToggle3 = Make.Toggle("Awake", "Asleep");
		rustToggle3.SetParent(tabControl.Panel("input"));
		rustToggle3.OnChanged.AddListener(delegate(bool val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		tabControl.AddTab("menu", "Menu", Icons.Backward);
		RustButton file = Make.Button(new Translate.Phrase("menu.file", "File"), Icons.File, toggle: true, "Toolbar.Normal", autoSize: true);
		RustWrapper rustWrapper = Make.Container.Toolbar();
		rustWrapper.Add(file);
		rustWrapper.Add(Make.Button(new Translate.Phrase("menu.edit", "Edit"), Icons.Pencil, toggle: true, "Toolbar.Normal", autoSize: true));
		rustWrapper.Add(Make.Button(new Translate.Phrase("menu.view", "View"), Icons.Magnet, toggle: true, "Toolbar.Normal", autoSize: true));
		rustWrapper.AddFlex();
		rustWrapper.Add(Make.Button(new Translate.Phrase("menu.exit", "Exit"), Icons.SearchMinus, toggle: true, "Toolbar.Normal", autoSize: true));
		rustWrapper.SetParent(tabControl.Panel("menu"));
		RustButton rustButton4 = Make.Button(new Translate.Phrase("changebtext", "Change Button Text"), Icons.Sync);
		rustButton4.SetParent(tabControl.Panel("menu"));
		rustButton4.OnPressed.AddListener(delegate
		{
			string[] array = new string[6] { "Hi", "Hello", "Long String", "File", "Buttes", "Yep" };
			file.Text.SetText(array[Random.Range(0, array.Length)]);
		});
		RustButtonGroup rustButtonGroup = Make.ButtonGroup(enumOptions);
		rustButtonGroup.SetParent(tabControl.Panel("buttons"));
		rustButtonGroup.OnChanged.AddListener(delegate(Option val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		RustButtonGroup rustButtonGroup2 = Make.ButtonGroup(enumOptionsJustIcons);
		rustButtonGroup2.SetParent(tabControl.Panel("buttons"));
		rustButtonGroup2.OnChanged.AddListener(delegate(Option val)
		{
			Debug.Log($"Value Changed: {val}");
		});
		RustButtonGroup rustButtonGroup3 = Make.ButtonGroup(enumOptionsWithIcons);
		rustButtonGroup3.SetParent(tabControl.Panel("buttons"));
		rustButtonGroup3.OnChanged.AddListener(delegate(Option val)
		{
			Debug.Log($"Value Changed: {val}");
		});
	}
}
