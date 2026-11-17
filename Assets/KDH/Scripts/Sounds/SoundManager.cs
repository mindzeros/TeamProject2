using System.Collections.Generic;
using UnityEngine;

namespace KDH.Scripts.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private SoundListSO sounds;

        private Dictionary<SoundType, SoundSO> _soundDict = new();
        public IReadOnlyDictionary<SoundType, SoundSO> SoundDict => _soundDict;

        private void Awake()
        {
            foreach (var sound in sounds.list)
            {
                _soundDict.TryAdd(sound.audioType, sound);
            }
        }

        public void PlaySFX(SoundType type)
        {
            if (SoundDict.TryGetValue(type, out SoundSO sound))
            {
                if (sound.audioType == SoundType.BGM)
                {
                    return;
                }

                audioSource.time = sound.startTime;

                audioSource.loop = sound.loop;

                audioSource.volume = sound.volume;

                if (sound.randomizePitch)
                { 
                    audioSource.pitch = sound.randomizePitchRange; 
                }
                else 
                {
                    audioSource.pitch = sound.basePitch; 
                }
            }
        }

        public void PlayBGM(SoundType type)
        {
            if (SoundDict.TryGetValue(type, out SoundSO sound))
            {
                if (sound.audioType == SoundType.SFX)
                {
                    return;
                }

                audioSource.time = sound.startTime;

                audioSource.loop = sound.loop;

                audioSource.volume = sound.volume;

                if (sound.randomizePitch)
                {
                    audioSource.pitch = sound.randomizePitchRange;
                }
                else
                {
                    audioSource.pitch = sound.basePitch;
                }
            }
        }
    }
}
