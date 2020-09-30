using System.IO;
using UnityEngine;

namespace Addone
{
	public abstract class SavePatch<T> : MonoBehaviour
	{
		protected abstract string FileName { get; set; }

		protected abstract T SaveObject { get; set; }
	
		public GotSavePath SavePath => new GotSavePath(FileName);
	
		protected internal void Save()
		{
			print(SavePath);
			
			File.WriteAllText(SavePath.ToString(), JsonUtility.ToJson(SaveObject));
		}
	
		protected internal void Load()
		{
			var path = SavePath.ToString();

			print(path);
		
			if (!File.Exists(path))
				return;

			SaveObject = JsonUtility.FromJson<T>(File.ReadAllText(path));
		}

		private protected void Awake()
		{
			Load();
		}
	}
}