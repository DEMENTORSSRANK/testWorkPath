using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Addone
{
    public static class LoadData
    {
        public static LevelData[] Levels => ObjectsLevels.Select(x => (LevelData) x).ToArray();

        private static IEnumerable<Object> ObjectsLevels => Resources.LoadAll("Levels", typeof(LevelData));
    }
}