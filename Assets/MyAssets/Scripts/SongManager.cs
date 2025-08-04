using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;
    
    // O nome da sua música em StreamingAssets é "notesChart2.mid"
    public string fileLocation = "notesChart2.mid";
    
    public float noteTime;
    public float noteSpawnX;
    public float noteTapX;
    public float noteDespawnX
    {
        get
        {
            return noteTapX - (noteSpawnX - noteTapX);
        }
    }

    public static MidiFile midiFile;

    void Start()
    {
        Instance = this;
        // Inicia a corrotina para carregar o arquivo MIDI usando UnityWebRequest.
        // Essa abordagem funciona para todas as plataformas, incluindo PC, WebGL e Android/Quest 3.
        StartCoroutine(LoadMidiFile());
    }

    private IEnumerator LoadMidiFile()
    {
        // Constrói o caminho completo para o arquivo MIDI.
        // Application.streamingAssetsPath já lida com as diferenças entre plataformas.
        string filePath = Path.Combine(Application.streamingAssetsPath, fileLocation);
        
        UnityWebRequest www;

        // Se a plataforma for Android, o caminho precisa ser ajustado para um formato de URL.
        // No PC, o caminho já funciona como um URI de arquivo.
        if (Application.platform == RuntimePlatform.Android)
        {
            // O caminho precisa começar com "jar:file://" para acessar o .apk
            filePath = "jar:file://" + Application.dataPath + "!/assets/" + fileLocation;
            www = UnityWebRequest.Get(filePath);
        }
        else
        {
            // Para outras plataformas (PC, WebGL, etc.), o caminho padrão funciona.
            www = UnityWebRequest.Get(filePath);
        }

        Debug.Log("Tentando carregar o MIDI do caminho: " + filePath);
        
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao carregar o arquivo MIDI: " + www.error);
        }
        else
        {
            byte[] results = www.downloadHandler.data;
            using (var stream = new MemoryStream(results))
            {
                midiFile = MidiFile.Read(stream);
                GetDataFromMidi();
            }
        }
    }

    public void GetDataFromMidi()
    {
        if (midiFile == null)
        {
            Debug.LogError("midiFile é nulo. Certifique-se de que o arquivo MIDI foi carregado corretamente.");
            return;
        }

        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {
        audioSource.Play();
    }
    
    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    void Update()
    {
        
    }
}