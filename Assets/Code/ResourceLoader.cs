using UnityEngine;

namespace MyRaces
{
    public static class ResourceLoader
    {
        public static GameObject LoadPrefab(ResourcesPath path)
        {
            return Resources.Load<GameObject>(path.PathResources);
        }
    }
}