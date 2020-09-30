using System.IO;
using UnityEngine;

namespace Addone
{
	public readonly struct GotSavePath
	{
		private readonly string _fileName;
	
		private readonly Expansion _fileExpansion;

		private string FileWithExpansion => string.Concat(_fileName, ".", _fileExpansion.ToString().ToLower()); 
	
		public override string ToString()
		{
			return Path.Combine(Application.persistentDataPath, FileWithExpansion);
		}

		public GotSavePath(string fileName, Expansion expansion = Expansion.Json)
		{
			_fileName = fileName;

			_fileExpansion = expansion;
		}
	
		public enum Expansion
		{
			Json,
			Txt
		}
	}
}
