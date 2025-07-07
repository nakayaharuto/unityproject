using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SoundManager : MonoBehaviour
{
    public enum SoundType
    {
        FKey,
        LeftClick,
        RightClick,
        GKey,

    }

    [System.Serializable]
    public class SoundData
    {
        public SoundType soundtype; //名前
        public float volume = 1.0f;//音量
        public AudioClip clip;//音源
    }

    [SerializeField]private SoundData[] saunddata;

    //AudioSource（スピーカー）を同時に鳴らしたい音の数だけ用意
    private AudioSource[] audioSourcesList = new AudioSource[20];
    //別名(name)をキーとした管理用Dictionary
    private Dictionary<SoundType, SoundData> soundDictionary = new Dictionary<SoundType, SoundData>();
    private void Awake()
    {
        //配列の数だけAudioSourceを自分自身に生成して配列に格納
        for(var i = 0; i < audioSourcesList.Length; i++)
        {
            audioSourcesList[i] = gameObject.AddComponent<AudioSource>();
        }

        //soundDictionaryにセット
        foreach (var soundData in saunddata)
        {
            soundDictionary.Add(soundData.soundtype, soundData);
        }
    }

    //未使用のAudioSourceの取得 全て使用中の場合はnullを返却
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourcesList.Length; ++i)
        {
            if (audioSourcesList[i].isPlaying == false) return audioSourcesList[i];
        }

        return null; //未使用のAudioSourceは見つかりませんでした
    }

    //指定されたAudioClipを未使用のAudioSourceで再生
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = clip;
        audioSource.Play();
    }

    //指定された別名で登録されたAudioClipを再生
    public void Play(SoundType soundtype)
    {
        if (soundDictionary.TryGetValue(soundtype, out var soundData)) //管理用Dictionary から、別名で探索
        {
            var audioSource = GetUnusedAudioSource();
            if (audioSource == null) return;

            audioSource.clip = soundData.clip;
            audioSource.volume = soundData.volume; //音量を反映！
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }




}
