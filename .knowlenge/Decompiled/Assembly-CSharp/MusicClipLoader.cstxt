using System.Collections.Generic;
using Facepunch;
using UnityEngine;

public class MusicClipLoader
{
	public class LoadedAudioClip : Pool.IPooled
	{
		public AudioClip clip;

		public float unloadTime;

		void Pool.IPooled.LeavePool()
		{
		}

		void Pool.IPooled.EnterPool()
		{
			clip = null;
			unloadTime = 0f;
		}
	}

	public List<LoadedAudioClip> loadedClips = new List<LoadedAudioClip>();

	public Dictionary<AudioClip, LoadedAudioClip> loadedClipDict = new Dictionary<AudioClip, LoadedAudioClip>();

	public List<AudioClip> clipsToLoad = new List<AudioClip>();

	public List<AudioClip> clipsToUnload = new List<AudioClip>();

	public void Update()
	{
		for (int num = clipsToLoad.Count - 1; num >= 0; num--)
		{
			AudioClip audioClip = clipsToLoad[num];
			if (audioClip.loadState != AudioDataLoadState.Loaded && audioClip.loadState != AudioDataLoadState.Loading)
			{
				audioClip.LoadAudioData();
				clipsToLoad.RemoveAt(num);
				return;
			}
		}
		for (int num2 = clipsToUnload.Count - 1; num2 >= 0; num2--)
		{
			AudioClip audioClip2 = clipsToUnload[num2];
			if (audioClip2.loadState == AudioDataLoadState.Loaded)
			{
				audioClip2.UnloadAudioData();
				clipsToUnload.RemoveAt(num2);
				break;
			}
		}
	}

	public void Refresh()
	{
		for (int i = 0; i < SingletonComponent<MusicManager>.Instance.activeMusicClips.Count; i++)
		{
			MusicTheme.PositionedClip positionedClip = SingletonComponent<MusicManager>.Instance.activeMusicClips[i];
			LoadedAudioClip loadedAudioClip = FindLoadedClip(positionedClip.musicClip.audioClip);
			if (loadedAudioClip == null)
			{
				loadedAudioClip = Pool.Get<LoadedAudioClip>();
				loadedAudioClip.clip = positionedClip.musicClip.audioClip;
				loadedAudioClip.unloadTime = (float)UnityEngine.AudioSettings.dspTime + loadedAudioClip.clip.length + 1f;
				loadedClips.Add(loadedAudioClip);
				loadedClipDict.Add(loadedAudioClip.clip, loadedAudioClip);
				clipsToLoad.Add(loadedAudioClip.clip);
			}
			else
			{
				loadedAudioClip.unloadTime = (float)UnityEngine.AudioSettings.dspTime + loadedAudioClip.clip.length + 1f;
				clipsToUnload.Remove(loadedAudioClip.clip);
			}
		}
		for (int num = loadedClips.Count - 1; num >= 0; num--)
		{
			LoadedAudioClip obj = loadedClips[num];
			if (UnityEngine.AudioSettings.dspTime > (double)obj.unloadTime)
			{
				clipsToUnload.Add(obj.clip);
				loadedClips.Remove(obj);
				loadedClipDict.Remove(obj.clip);
				Pool.Free(ref obj);
			}
		}
	}

	private LoadedAudioClip FindLoadedClip(AudioClip clip)
	{
		if (loadedClipDict.ContainsKey(clip))
		{
			return loadedClipDict[clip];
		}
		return null;
	}
}
