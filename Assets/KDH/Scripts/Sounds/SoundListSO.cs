using System.Collections.Generic;
using UnityEngine;

namespace KDH.Scripts.Sounds
{
    [CreateAssetMenu(fileName = "SoundList", menuName = "SO/KDH/SoundList")]
    public class SoundListSO : ScriptableObject
    {
        public List<SoundSO> list = new List<SoundSO>();
    }
}
