using System;

public readonly struct ClanValueResult<T>
{
	public readonly ClanResult Result;

	private readonly T _value;

	public bool IsSuccess => Result == ClanResult.Success;

	public T Value
	{
		get
		{
			if (!IsSuccess)
			{
				throw new InvalidOperationException("Result is an error and has no value.");
			}
			return _value;
		}
	}

	public ClanValueResult(ClanResult result)
	{
		if (result == ClanResult.Success)
		{
			throw new ArgumentException("Success result requires a value.", "result");
		}
		Result = result;
		_value = default(T);
	}

	public ClanValueResult(T value)
	{
		Result = ClanResult.Success;
		_value = value;
	}

	public static implicit operator ClanValueResult<T>(ClanResult result)
	{
		return new ClanValueResult<T>(result);
	}

	public static implicit operator ClanValueResult<T>(T value)
	{
		return new ClanValueResult<T>(value);
	}
}
