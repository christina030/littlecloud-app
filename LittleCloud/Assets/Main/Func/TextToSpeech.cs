using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Crosstales.RTVoice;
using UnityEngine.UI;
using TMPro;

public class TextToSpeech : MonoBehaviour
{
    // public TMP_InputField textContent;
    // public Button button;
    private string mID;
    // Start is called before the first frame update
    void Start()
    {
        // button.onClick.AddListener(() =>
        // {
        //     Speaker.Instance.Silence(mID);
        //     mID = Speaker.Instance.Speak(textContent.text, null, Speaker.Instance.Voices[0]);
        // });
    }
    
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     mID = Speaker.Instance.Speak("測試語音功能！ Testing 1 2 3", null, Speaker.Instance.Voices[0]);
        //     Debug.Log("[測試語音] 開始ID: " + mID);
        //     Speaker.Instance.OnSpeakStart += SpeakStart;
        //     Speaker.Instance.OnSpeakComplete += SpeakComplete;
        // }
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     Speaker.Instance.Silence(mID);
        //     mID = Speaker.Instance.Speak("測試ID", null, Speaker.Instance.Voices[0]);
        //     Debug.Log("[測試ID] 開始ID: " + mID);
        //     Speaker.Instance.OnSpeakComplete += SpeakComplete;
        // }
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     Speaker.Instance.PauseOrUnPause();
        // }
        // if (Input.GetKeyDown(KeyCode.M))
        // {
        //     Speaker.Instance.Silence(mID);
        // }
    }

    private void SpeakStart(Crosstales.RTVoice.Model.Wrapper wrapper)
    {
        Debug.Log("Start ID: " + wrapper.Uid);
    }
    private void SpeakComplete(Crosstales.RTVoice.Model.Wrapper wrapper)
    {
        Debug.Log("Complete ID: " + wrapper.Uid);
        // if (wrapper.Uid.Equals(mID))
        // {

        // }
    }

    public void Speak(string _content)
    {
        Speaker.Instance.Silence(mID);
        mID = Speaker.Instance.Speak(_content, null, Speaker.Instance.Voices[0]);
    }
    public void Silence()
    {
        Speaker.Instance.Silence(mID);
    }
}

// Google.Cloud.TextToSpeech.V1 /////////////////////////////////////////////////////
// using Google.Cloud.TextToSpeech.V1;
// using System.IO;

// public class TextToSpeech : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         // var client = new TextToSpeechClientBuilder
//         // {
//         //     GrpcAdapter = RestGrpcAdapter.Default
//         // }.Build();
//         TextToSpeechClient client = TextToSpeechClient.Create();

//         // The input can be provided as text or SSML.
//         SynthesisInput input = new SynthesisInput
//         {
//             Text = "This is a demonstration of the Google Cloud Text-to-Speech API"
//         };
//         // You can specify a particular voice, or ask the server to pick based
//         // on specified criteria.
//         VoiceSelectionParams voiceSelection = new VoiceSelectionParams
//         {
//             LanguageCode = "en-US",
//             SsmlGender = SsmlVoiceGender.Female
//         };
//         // The audio configuration determines the output format and speaking rate.
//         AudioConfig audioConfig = new AudioConfig
//         {
//             AudioEncoding = AudioEncoding.Mp3
//         };
//         SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);
//         using (Stream output = File.Create("sample.mp3"))
//         {
//             // response.AudioContent is a ByteString. This can easily be converted into
//             // a byte array or written to a stream.
//             response.AudioContent.WriteTo(output);
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }
/////////////////////////////////////////////////////////////////////////////////////
