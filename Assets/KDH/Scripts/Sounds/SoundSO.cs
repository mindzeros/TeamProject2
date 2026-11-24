using UnityEngine;
public enum SoundType
{
    SFX, BGM
}

namespace KDH.Scripts.Sounds
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "SO/KDH/SoundData")]
    public class SoundSO : ScriptableObject
    {

        public SoundType audioType;
        public AudioClip clip;
        public bool loop;
        public bool randomizePitch;

        public float startTime;
        [Range(0, 1f)] public float randomizePitchRange = 0.1f;
        [Range(0, 1f)] public float volume = 1f;
        [Range(0, 3f)] public float basePitch = 1f;
    }
}
