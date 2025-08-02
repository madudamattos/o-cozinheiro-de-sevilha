using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0;
    int inputIndex = 0;
    bool inputReceived = false;

    public GameObject hitBox;
    public string laneID = "D";

    void OnEnable()
    {
        InputEvents.OnLaneInput += ReceiveInput;
    }

    void OnDisable()
    {
        InputEvents.OnLaneInput -= ReceiveInput;
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (inputReceived || Input.GetKeyDown(input))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    print($"Hit on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }

                inputReceived = false;
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                // print($"Missed {inputIndex} note");
                Destroy(notes[inputIndex].gameObject);
                inputIndex++;
            }


        }

    }
    private void Hit()
    {
        CancelInvoke(nameof(hitboxRestoreOpacity));
        hitboxReduceColorOpacity();
        Invoke(nameof(hitboxRestoreOpacity), .2f);
        ScoreManager.Hit();
    }
    private void Miss()
    {
        ScoreManager.Miss();
    }
    
    public void ReceiveInput(string triggeredID)
    {
        if (triggeredID == laneID)
        {
            inputReceived = true;
        }
    }

    public void hitboxReduceColorOpacity()
    {
        SpriteRenderer sr = hitBox.GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = .4f;
        sr.color = c;
    }

    public void hitboxRestoreOpacity()
    {
        SpriteRenderer sr =  hitBox.GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = 1f;
        sr.color = c;
    }
}