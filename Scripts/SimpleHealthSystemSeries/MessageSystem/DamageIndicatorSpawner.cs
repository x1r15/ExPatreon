using Scripts.Systems.HealthSystem;
using UnityEngine;

namespace Scripts.Systems.MessageSystem
{
    public class DamageIndicatorSpawner : MessageSpawner
    {
        public void SpawnMessage(HealthChangeArgs args)
        {
            SpawnMessage(Mathf.Abs(args.ActualChange).ToString());
        }
    }
}