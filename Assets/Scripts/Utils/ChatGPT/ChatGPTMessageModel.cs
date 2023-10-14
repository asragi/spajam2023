using System;
using System.Collections.Generic;

[Serializable]
public class ChatGPTMessageModel
{
    public string role;
    public string content;
}

//ChatGPT API��Request�𑗂邽�߂�JSON�p�N���X
[Serializable]
public class ChatGPTCompletionRequestModel
{
    public string model;
    public List<ChatGPTMessageModel> messages;
}

//ChatGPT API�����Response���󂯎�邽�߂̃N���X
[System.Serializable]
public class ChatGPTResponseModel
{
    public string id;
    public string @object;
    public int created;
    public Choice[] choices;
    public Usage usage;

    [System.Serializable]
    public class Choice
    {
        public int index;
        public ChatGPTMessageModel message;
        public string finish_reason;
    }

    [System.Serializable]
    public class Usage
    {
        public int prompt_tokens;
        public int completion_tokens;
        public int total_tokens;
    }
}

