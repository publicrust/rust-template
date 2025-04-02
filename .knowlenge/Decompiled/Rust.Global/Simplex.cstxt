using UnityEngine;

internal struct Simplex
{
	public Vector3 a;

	public Vector3 b;

	public Vector3 c;

	public Vector3 d;

	public int size;

	public Vector3 Direction;

	public float ScaledDistance;

	public void SolveDistance()
	{
		switch (size)
		{
		case 1:
			Point();
			break;
		case 2:
			Line();
			break;
		case 3:
			Triangle();
			break;
		case 4:
			Tetrahedron();
			break;
		}
	}

	private void DebugDraw()
	{
		Gizmos.color = size switch
		{
			1 => Color.blue, 
			2 => Color.red, 
			3 => Color.green, 
			4 => Color.magenta, 
			_ => Color.black, 
		};
		switch (size)
		{
		case 1:
			Gizmos.DrawWireSphere(a, 0.03f);
			break;
		case 2:
			Gizmos.DrawWireSphere(a, 0.03f);
			Gizmos.DrawWireSphere(b, 0.03f);
			Gizmos.DrawLine(a, b);
			break;
		case 3:
			Gizmos.DrawWireSphere(a, 0.03f);
			Gizmos.DrawWireSphere(b, 0.03f);
			Gizmos.DrawWireSphere(c, 0.03f);
			Gizmos.DrawLine(a, b);
			Gizmos.DrawLine(b, c);
			Gizmos.DrawLine(c, a);
			break;
		case 4:
			Gizmos.DrawWireSphere(a, 0.03f);
			Gizmos.DrawWireSphere(b, 0.03f);
			Gizmos.DrawWireSphere(c, 0.03f);
			Gizmos.DrawWireSphere(d, 0.03f);
			Gizmos.DrawLine(a, b);
			Gizmos.DrawLine(a, c);
			Gizmos.DrawLine(a, d);
			Gizmos.DrawLine(b, c);
			Gizmos.DrawLine(b, d);
			Gizmos.DrawLine(d, c);
			break;
		}
	}

	private void Point()
	{
		Direction = a;
		ScaledDistance = Vector3.SqrMagnitude(Direction);
	}

	private void Line()
	{
		Vector3 vector = b - a;
		float num = Vector3.Dot(vector, vector);
		if (Vector3.Dot(-a, vector) >= num)
		{
			size = 1;
			a = b;
			Point();
		}
		else
		{
			Direction = Vector3.Cross(Vector3.Cross(vector, a), vector);
			ScaledDistance = Vector3.Dot(Direction, a);
		}
	}

	private void Triangle()
	{
		Vector3 rhs = a - c;
		Vector3 lhs = b - c;
		Vector3 vector = Vector3.Cross(lhs, rhs);
		Vector3 lhs2 = Vector3.Cross(lhs, vector);
		Vector3 lhs3 = Vector3.Cross(vector, rhs);
		float num = Vector3.Dot(lhs2, b);
		float num2 = Vector3.Dot(lhs3, c);
		if (num < 0f)
		{
			if (num2 >= 0f || Det(vector, lhs2, c) < 0f)
			{
				a = b;
			}
		}
		else if (num2 >= 0f)
		{
			float num3 = Vector3.Dot(c, vector);
			if (num3 < 0f)
			{
				Vector3 vector2 = b;
				Vector3 vector3 = a;
				a = vector2;
				b = vector3;
				vector = -vector;
				num3 = 0f - num3;
			}
			Direction = vector;
			ScaledDistance = num3;
			return;
		}
		b = c;
		size = 2;
		Line();
	}

	private void Tetrahedron()
	{
		Vector3 lhs = Vector3.Cross(a, b);
		Vector3 lhs2 = Vector3.Cross(b, c);
		Vector3 lhs3 = Vector3.Cross(c, a);
		Vector3 vector = new Vector3(Vector3.Dot(lhs, d), Vector3.Dot(lhs2, d), Vector3.Dot(lhs3, d));
		if (vector.x >= -1E-05f && vector.y >= -1E-05f && vector.z >= -1E-05f)
		{
			Direction = Vector3.zero;
			return;
		}
		bool flag = Vector3.Dot(lhs, d) >= 0f;
		bool flag2 = Vector3.Dot(lhs2, d) >= 0f;
		bool flag3 = Vector3.Dot(lhs3, d) >= 0f;
		Vector3 vector2 = d - a;
		Vector3 vector3 = d - b;
		Vector3 vector4 = d - c;
		Vector3 vector5 = Vector3.Cross(vector2, vector3);
		Vector3 vector6 = Vector3.Cross(vector3, vector4);
		Vector3 vector7 = Vector3.Cross(vector4, vector2);
		bool flag4 = Det(vector5, vector2, d) >= 0f;
		bool flag5 = Det(vector6, vector3, d) >= 0f;
		bool flag6 = Det(vector7, vector4, d) >= 0f;
		bool flag7 = Det(vector3, vector5, d) >= 0f;
		bool flag8 = Det(vector4, vector6, d) >= 0f;
		bool flag9 = Det(vector2, vector7, d) >= 0f;
		bool num = flag4 && flag7 && !flag;
		bool flag10 = flag5 && flag8 && !flag2;
		bool flag11 = flag6 && flag9 && !flag3;
		if (num || flag10 || flag11)
		{
			if (flag10)
			{
				a = b;
				b = c;
			}
			else if (flag11)
			{
				b = c;
			}
		}
		else
		{
			bool flag12 = Vector3.Dot(vector2, d) >= 0f;
			bool flag13 = Vector3.Dot(vector3, d) >= 0f;
			bool flag14 = Vector3.Dot(vector4, d) >= 0f;
			bool num2 = !flag4 && !flag9 && flag12;
			bool flag15 = !flag5 && !flag7 && flag13;
			bool flag16 = !flag6 && !flag8 && flag14;
			if (num2 || flag15 || flag16)
			{
				a = b;
				b = c;
			}
		}
		c = d;
		size = 3;
		Triangle();
	}

	private static float Det(Vector3 a, Vector3 b, Vector3 c)
	{
		return Vector3.Dot(Vector3.Cross(a, b), c);
	}
}
