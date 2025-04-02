using UnityEngine;

public class LTGUI
{
	public enum Element_Type
	{
		Texture,
		Label
	}

	public static int RECT_LEVELS = 5;

	public static int RECTS_PER_LEVEL = 10;

	public static int BUTTONS_MAX = 24;

	private static LTRect[] levels;

	private static int[] levelDepths;

	private static Rect[] buttons;

	private static int[] buttonLevels;

	private static int[] buttonLastFrame;

	private static LTRect r;

	private static Color color = Color.white;

	private static bool isGUIEnabled = false;

	private static int global_counter = 0;

	public static void init()
	{
		if (levels == null)
		{
			levels = new LTRect[RECT_LEVELS * RECTS_PER_LEVEL];
			levelDepths = new int[RECT_LEVELS];
		}
	}

	public static void initRectCheck()
	{
		if (buttons == null)
		{
			buttons = (Rect[])(object)new Rect[BUTTONS_MAX];
			buttonLevels = new int[BUTTONS_MAX];
			buttonLastFrame = new int[BUTTONS_MAX];
			for (int i = 0; i < buttonLevels.Length; i++)
			{
				buttonLevels[i] = -1;
			}
		}
	}

	public static void reset()
	{
		if (isGUIEnabled)
		{
			isGUIEnabled = false;
			for (int i = 0; i < levels.Length; i++)
			{
				levels[i] = null;
			}
			for (int j = 0; j < levelDepths.Length; j++)
			{
				levelDepths[j] = 0;
			}
		}
	}

	public static void update(int updateLevel)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		if (!isGUIEnabled)
		{
			return;
		}
		init();
		if (levelDepths[updateLevel] <= 0)
		{
			return;
		}
		color = GUI.color;
		int num = updateLevel * RECTS_PER_LEVEL;
		int num2 = num + levelDepths[updateLevel];
		for (int i = num; i < num2; i++)
		{
			r = levels[i];
			if (r == null)
			{
				continue;
			}
			if (r.useColor)
			{
				GUI.color = r.color;
			}
			Rect rect;
			if (r.type == Element_Type.Label)
			{
				if (r.style != null)
				{
					GUI.skin.label = r.style;
				}
				if (r.useSimpleScale)
				{
					rect = r.rect;
					float num3 = (((Rect)(ref rect)).x + r.margin.x + ((Rect)(ref r.relativeRect)).x) * ((Rect)(ref r.relativeRect)).width;
					rect = r.rect;
					float num4 = (((Rect)(ref rect)).y + r.margin.y + ((Rect)(ref r.relativeRect)).y) * ((Rect)(ref r.relativeRect)).height;
					rect = r.rect;
					float num5 = ((Rect)(ref rect)).width * ((Rect)(ref r.relativeRect)).width;
					rect = r.rect;
					GUI.Label(new Rect(num3, num4, num5, ((Rect)(ref rect)).height * ((Rect)(ref r.relativeRect)).height), r.labelStr);
				}
				else
				{
					rect = r.rect;
					float num6 = ((Rect)(ref rect)).x + r.margin.x;
					rect = r.rect;
					float num7 = ((Rect)(ref rect)).y + r.margin.y;
					rect = r.rect;
					float width = ((Rect)(ref rect)).width;
					rect = r.rect;
					GUI.Label(new Rect(num6, num7, width, ((Rect)(ref rect)).height), r.labelStr);
				}
			}
			else if (r.type == Element_Type.Texture && (Object)(object)r.texture != (Object)null)
			{
				Vector2 val;
				if (!r.useSimpleScale)
				{
					rect = r.rect;
					float width2 = ((Rect)(ref rect)).width;
					rect = r.rect;
					val = new Vector2(width2, ((Rect)(ref rect)).height);
				}
				else
				{
					rect = r.rect;
					val = new Vector2(0f, ((Rect)(ref rect)).height * ((Rect)(ref r.relativeRect)).height);
				}
				Vector2 val2 = val;
				if (r.sizeByHeight)
				{
					val2.x = (float)r.texture.width / (float)r.texture.height * val2.y;
				}
				if (r.useSimpleScale)
				{
					rect = r.rect;
					float num8 = (((Rect)(ref rect)).x + r.margin.x + ((Rect)(ref r.relativeRect)).x) * ((Rect)(ref r.relativeRect)).width;
					rect = r.rect;
					GUI.DrawTexture(new Rect(num8, (((Rect)(ref rect)).y + r.margin.y + ((Rect)(ref r.relativeRect)).y) * ((Rect)(ref r.relativeRect)).height, val2.x, val2.y), r.texture);
				}
				else
				{
					rect = r.rect;
					float num9 = ((Rect)(ref rect)).x + r.margin.x;
					rect = r.rect;
					GUI.DrawTexture(new Rect(num9, ((Rect)(ref rect)).y + r.margin.y, val2.x, val2.y), r.texture);
				}
			}
		}
		GUI.color = color;
	}

	public static bool checkOnScreen(Rect rect)
	{
		bool num = ((Rect)(ref rect)).x + ((Rect)(ref rect)).width < 0f;
		bool flag = ((Rect)(ref rect)).x > (float)Screen.width;
		bool flag2 = ((Rect)(ref rect)).y > (float)Screen.height;
		bool flag3 = ((Rect)(ref rect)).y + ((Rect)(ref rect)).height < 0f;
		return !(num || flag || flag2 || flag3);
	}

	public static void destroy(int id)
	{
		int num = id & 0xFFFF;
		int num2 = id >> 16;
		if (id >= 0 && levels[num] != null && levels[num].hasInitiliazed && levels[num].counter == num2)
		{
			levels[num] = null;
		}
	}

	public static void destroyAll(int depth)
	{
		int num = depth * RECTS_PER_LEVEL + RECTS_PER_LEVEL;
		int num2 = depth * RECTS_PER_LEVEL;
		while (levels != null && num2 < num)
		{
			levels[num2] = null;
			num2++;
		}
	}

	public static LTRect label(Rect rect, string label, int depth)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return LTGUI.label(new LTRect(rect), label, depth);
	}

	public static LTRect label(LTRect rect, string label, int depth)
	{
		rect.type = Element_Type.Label;
		rect.labelStr = label;
		return element(rect, depth);
	}

	public static LTRect texture(Rect rect, Texture texture, int depth)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return LTGUI.texture(new LTRect(rect), texture, depth);
	}

	public static LTRect texture(LTRect rect, Texture texture, int depth)
	{
		rect.type = Element_Type.Texture;
		rect.texture = texture;
		return element(rect, depth);
	}

	public static LTRect element(LTRect rect, int depth)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		isGUIEnabled = true;
		init();
		int num = depth * RECTS_PER_LEVEL + RECTS_PER_LEVEL;
		int num2 = 0;
		if (rect != null)
		{
			destroy(rect.id);
		}
		if (rect.type == Element_Type.Label && rect.style != null && rect.style.normal.textColor.a <= 0f)
		{
			Debug.LogWarning((object)"Your GUI normal color has an alpha of zero, and will not be rendered.");
		}
		if (((Rect)(ref rect.relativeRect)).width == float.PositiveInfinity)
		{
			rect.relativeRect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
		}
		for (int i = depth * RECTS_PER_LEVEL; i < num; i++)
		{
			r = levels[i];
			if (r == null)
			{
				r = rect;
				r.rotateEnabled = true;
				r.alphaEnabled = true;
				r.setId(i, global_counter);
				levels[i] = r;
				if (num2 >= levelDepths[depth])
				{
					levelDepths[depth] = num2 + 1;
				}
				global_counter++;
				return r;
			}
			num2++;
		}
		Debug.LogError((object)"You ran out of GUI Element spaces");
		return null;
	}

	public static bool hasNoOverlap(Rect rect, int depth)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		initRectCheck();
		bool result = true;
		bool flag = false;
		for (int i = 0; i < buttonLevels.Length; i++)
		{
			if (buttonLevels[i] >= 0)
			{
				if (buttonLastFrame[i] + 1 < Time.frameCount)
				{
					buttonLevels[i] = -1;
				}
				else if (buttonLevels[i] > depth && pressedWithinRect(buttons[i]))
				{
					result = false;
				}
			}
			if (!flag && buttonLevels[i] < 0)
			{
				flag = true;
				buttonLevels[i] = depth;
				buttons[i] = rect;
				buttonLastFrame[i] = Time.frameCount;
			}
		}
		return result;
	}

	public static bool pressedWithinRect(Rect rect)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = firstTouch();
		if (val.x < 0f)
		{
			return false;
		}
		float num = (float)Screen.height - val.y;
		if (val.x > ((Rect)(ref rect)).x && val.x < ((Rect)(ref rect)).x + ((Rect)(ref rect)).width && num > ((Rect)(ref rect)).y)
		{
			return num < ((Rect)(ref rect)).y + ((Rect)(ref rect)).height;
		}
		return false;
	}

	public static bool checkWithinRect(Vector2 vec2, Rect rect)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		vec2.y = (float)Screen.height - vec2.y;
		if (vec2.x > ((Rect)(ref rect)).x && vec2.x < ((Rect)(ref rect)).x + ((Rect)(ref rect)).width && vec2.y > ((Rect)(ref rect)).y)
		{
			return vec2.y < ((Rect)(ref rect)).y + ((Rect)(ref rect)).height;
		}
		return false;
	}

	public static Vector2 firstTouch()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (Input.touchCount > 0)
		{
			return ((Touch)(ref Input.touches[0])).position;
		}
		if (Input.GetMouseButton(0))
		{
			return Vector2.op_Implicit(Input.mousePosition);
		}
		return new Vector2(float.NegativeInfinity, float.NegativeInfinity);
	}
}
