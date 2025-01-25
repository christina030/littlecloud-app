﻿//This asset was uploaded by https://unityassetcollection.com

namespace Crosstales.RTVoice
{
   #region BaseVoiceProvider and Speaker

   [System.Serializable]
   public class VoicesReadyEvent : UnityEngine.Events.UnityEvent
   {
   }

   [System.Serializable]
   public class SpeakStartEvent : UnityEngine.Events.UnityEvent<string>
   {
   }

   [System.Serializable]
   public class SpeakCompleteEvent : UnityEngine.Events.UnityEvent<string>
   {
   }

   [System.Serializable]
   public class ErrorEvent : UnityEngine.Events.UnityEvent<string, string>
   {
   }

   public delegate void VoicesReady();

   public delegate void SpeakStart(Crosstales.RTVoice.Model.Wrapper wrapper);

   public delegate void SpeakComplete(Crosstales.RTVoice.Model.Wrapper wrapper);

   public delegate void SpeakCurrentWord(Crosstales.RTVoice.Model.Wrapper wrapper, string[] speechTextArray, int wordIndex);

   public delegate void SpeakCurrentWordString(Crosstales.RTVoice.Model.Wrapper wrapper, string word);

   public delegate void SpeakCurrentPhoneme(Crosstales.RTVoice.Model.Wrapper wrapper, string phoneme);

   public delegate void SpeakCurrentViseme(Crosstales.RTVoice.Model.Wrapper wrapper, string viseme);

   public delegate void SpeakAudioGenerationStart(Crosstales.RTVoice.Model.Wrapper wrapper);

   public delegate void SpeakAudioGenerationComplete(Crosstales.RTVoice.Model.Wrapper wrapper);

   public delegate void ErrorInfo(Crosstales.RTVoice.Model.Wrapper wrapper, string info);

   #endregion


   #region Speaker

   [System.Serializable]
   public class ProviderChangeEvent : UnityEngine.Events.UnityEvent<string>
   {
   }

   public delegate void ProviderChange(string provider);

   #endregion


   #region AudioFileGenerator

   [System.Serializable]
   public class AudioFileGeneratorStartEvent : UnityEngine.Events.UnityEvent
   {
   }

   [System.Serializable]
   public class AudioFileGeneratorCompleteEvent : UnityEngine.Events.UnityEvent
   {
   }

   public delegate void AudioFileGeneratorStart();

   public delegate void AudioFileGeneratorComplete();

   #endregion


   #region Paralanguage

   [System.Serializable]
   public class ParalanguageStartEvent : UnityEngine.Events.UnityEvent
   {
   }

   [System.Serializable]
   public class ParalanguageCompleteEvent : UnityEngine.Events.UnityEvent
   {
   }

   public delegate void ParalanguageStart();

   public delegate void ParalanguageComplete();

   #endregion


   #region SpeechText

   [System.Serializable]
   public class SpeechTextStartEvent : UnityEngine.Events.UnityEvent
   {
   }

   [System.Serializable]
   public class SpeechTextCompleteEvent : UnityEngine.Events.UnityEvent
   {
   }

   public delegate void SpeechTextStart();

   public delegate void SpeechTextComplete();

   #endregion


   #region TextFileSpeaker

   [System.Serializable]
   public class TextFileSpeakerStartEvent : UnityEngine.Events.UnityEvent
   {
   }

   [System.Serializable]
   public class TextFileSpeakerCompleteEvent : UnityEngine.Events.UnityEvent
   {
   }

   public delegate void TextFileSpeakerStart();

   public delegate void TextFileSpeakerComplete();

   #endregion
}
// © 2018-2022 crosstales LLC (https://www.crosstales.com)