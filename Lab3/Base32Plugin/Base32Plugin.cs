using System;
using System.Collections.Generic;
using System.Text;
using Plugin;

namespace Base32Plugin
{
	public class Base32Plugin : AbstractPlugin
	{
		private const string alphabet = "ybndrfg8ejkmcpqxot1uwisza345h769";
		private static readonly byte[] DecodingTable = new byte[128];

		public override string GetName()
		{
			return "ZBase32";
		}

		static Base32Plugin()
		{
			for (var i = 0; i < DecodingTable.Length; ++i)
			{
				DecodingTable[i] = byte.MaxValue;
			}

			for (var i = 0; i < alphabet.Length; ++i)
			{
				DecodingTable[alphabet[i]] = (byte)i;
			}
		}

		public override byte[] Encrypt(byte[] data)
		{
			try
			{
				if (data == null)
				{
					throw new Exception("Не было передано данных для кодирования в ZBase32!");
				}

				var text = new StringBuilder((int)Math.Ceiling(data.Length * 8.0 / 5.0));

				for (var i = 0; i < data.Length; i += 5)
				{
					var countOfBytesAtResultString = Math.Min(5, data.Length - i);

					ulong buffer = 0;
					for (var j = 0; j < countOfBytesAtResultString; ++j)
					{
						buffer = (buffer << 8) | data[i + j];
					}

					var countOfBitsAtResultString = countOfBytesAtResultString * 8;

					while (countOfBitsAtResultString > 0)
					{
						var index = countOfBitsAtResultString >= 5 ? (int)(buffer >> (countOfBitsAtResultString - 5)) & 0x1f : (int)(buffer & (ulong)(0x1f >> (5 - countOfBitsAtResultString))) << (5 - countOfBitsAtResultString);
						text.Append(alphabet[index]);
						countOfBitsAtResultString = countOfBitsAtResultString - 5;
					}
				}

				return Encoding.ASCII.GetBytes(text.ToString()); ///
			}
			catch (Exception ex)
			{
				throw new Exception("Ошибка при кодировании ZBase32 \n" + ex.Message);
			}
		}

		public override byte[] Decrypt(byte[] data)
		{
			try
			{
				if (Encoding.ASCII.GetString(data) == string.Empty) //беда
				{
					return Encoding.ASCII.GetBytes("");
				}

				var text = new List<byte>((int)Math.Ceiling(data.Length * 5.0 / 8.0));

				var index = new int[8];

				for (var i = 0; i < data.Length;)
				{
					string str = Encoding.ASCII.GetString(data);
					i = CreateIndexByOctetAndMovePosition(ref str, i, ref index);

					var shortByteCount = 0;
					ulong buffer = 0;

					for (var j = 0; j < 8 && index[j] != -1; ++j)
					{
						buffer = (buffer << 5) | (ulong)(DecodingTable[index[j]] & 0x1f);
						shortByteCount++;
					}

					var bitCount = shortByteCount * 5;

					while (bitCount >= 8)
					{
						text.Add((byte)((buffer >> (bitCount - 8)) & 0xff));
						bitCount -= 8;
					}
				}

				return Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(text.ToArray()));
			}
			catch (Exception ex)
			{
				throw new Exception("Ошибка при декодировании ZBase32 \n" + ex.Message);
			}
		}
		private int CreateIndexByOctetAndMovePosition(ref string data, int currentPosition, ref int[] index)
		{
			var j = 0;
			while (j < 8)
			{
				if (currentPosition >= data.Length)
				{
					index[j++] = -1;
					continue;
				}

				if (IgnoredSymbol(data[currentPosition]))
				{
					currentPosition++;
					continue;
				}

				index[j] = data[currentPosition];
				j++;
				currentPosition++;
			}

			return currentPosition;
		}

		private bool IgnoredSymbol(char checkedSymbol)
		{
			return checkedSymbol >= DecodingTable.Length || DecodingTable[checkedSymbol] == byte.MaxValue;
		}

		public string getExtention()
		{
			return "z32";
		}
	}
}