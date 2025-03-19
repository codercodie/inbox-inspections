using UnityEngine;

public class Email
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public string Sender { get; private set; }
    public Sprite ProfilePicture { get; private set; }
    public bool Scam { get; private set; }

    public Email(string title, string body, string sender, Sprite profilePicture, bool scam)
    {
        Title = title;
        Body = body;
        Sender = sender;
        ProfilePicture = profilePicture;
        Scam = scam;
    }
}
