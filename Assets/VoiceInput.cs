using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class VoiceInput : MonoBehaviour
{
    [System.Serializable]
    public class VoiceCommand {
        public string keyword;
        public UnityEvent action;
    }

    public List<VoiceCommand> commands;
    private Dictionary<string, VoiceCommand> commandsTable = new Dictionary<string, VoiceCommand>();
    KeywordRecognizer keywordRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
        for (int i = 0; i < commands.Count; i++)
        {
            VoiceCommand command = commands[i];
            commandsTable[command.keyword] = command;
            keywords.Add(command.keyword, () =>
            {
            });
        }

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        VoiceCommand command;
        // if the keyword recognized is in our dictionary, call that Action.
        if (commandsTable.TryGetValue(args.text, out command))
        {
            command.action.Invoke();
        }
    }
}
