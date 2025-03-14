using System.IO;
using Network;

public abstract class NetworkCryptography : INetworkCryptocraphy
{
	private MemoryStream buffer = new MemoryStream();

	public MemoryStream EncryptCopy(Connection connection, MemoryStream stream, int offset)
	{
		buffer.Position = 0L;
		buffer.SetLength(0L);
		buffer.Write(stream.GetBuffer(), 0, offset);
		EncryptionHandler(connection, stream, offset, buffer, offset);
		return buffer;
	}

	public MemoryStream DecryptCopy(Connection connection, MemoryStream stream, int offset)
	{
		buffer.Position = 0L;
		buffer.SetLength(0L);
		buffer.Write(stream.GetBuffer(), 0, offset);
		DecryptionHandler(connection, stream, offset, buffer, offset);
		return buffer;
	}

	public void Encrypt(Connection connection, MemoryStream stream, int offset)
	{
		EncryptionHandler(connection, stream, offset, stream, offset);
	}

	public void Decrypt(Connection connection, MemoryStream stream, int offset)
	{
		DecryptionHandler(connection, stream, offset, stream, offset);
	}

	public bool IsEnabledIncoming(Connection connection)
	{
		if (connection != null && connection.encryptionLevel != 0)
		{
			return connection.decryptIncoming;
		}
		return false;
	}

	public bool IsEnabledOutgoing(Connection connection)
	{
		if (connection != null && connection.encryptionLevel != 0)
		{
			return connection.encryptOutgoing;
		}
		return false;
	}

	protected abstract void EncryptionHandler(Connection connection, MemoryStream src, int srcOffset, MemoryStream dst, int dstOffset);

	protected abstract void DecryptionHandler(Connection connection, MemoryStream src, int srcOffset, MemoryStream dst, int dstOffset);
}
