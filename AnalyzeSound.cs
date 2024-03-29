using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalyzeSound : MonoBehaviour
{

    [Header ("Audio Analyzer")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float DbValue;
    [SerializeField] float RmsValue;
    [SerializeField] float PitchValue;
    [SerializeField] Text DBMeter;
    [SerializeField] Text RMSMeter;
    [SerializeField] Text PitchMeter;
    private const int QSamples = 512;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;
    private float[] _samples;
    private float[] _spectrum;
    private float _fSample;


    // Start is called before the first frame update
    void Start()
    {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = 48000f; //AudioSettings.outputSampleRate;
    }

    // Update is called once per frame
    void Update()
    {
        GetSoundData();
         DBMeter.text ="DBMeter: " + DbValue;
         RMSMeter.text ="RMSMeter: " + RmsValue;
         PitchMeter.text ="PitchMeter: " + PitchValue;
    }

    void GetSoundData()
    {   // Get Output Level
        _audioSource.GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
        if (DbValue < -160) DbValue = -160; // clamp it to -160dB min
        
        // get sound spectrum
        _audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        {   // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }

        float freqN = maxN; // pass the index to a float variable

        if (maxN > 0 && maxN < QSamples - 1)
        {   // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples; // convert index to frequency
    }

}
