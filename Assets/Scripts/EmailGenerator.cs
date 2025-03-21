﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class EmailGenerator : MonoBehaviour
{
    private static System.Random random = new System.Random();
    public List<Sprite> profilePictures;
    private static List<Email> emailTemplates = new List<Email>();
    private List<Email> emailList = new List<Email>();

    private void Awake()
    {
        InitialiseEmails();
        
    }

    public void InitialiseEmails()
    {
        emailTemplates = new List<Email>
        {
            new Email(
                "Urgent! Your Account Has Been Suspended!",
                "Dear Valued Customer,\n\nWe have detected suspicious activity on your account and have temporarily suspended access. Click the secure verification link below to verify your account before it is permanently closed:\n\n<u><color=#0000FF>http://paypal-security-verification.com/login</color></u>\n\nFailure to act will result in permanent deactivation of your account.\n\nThank you,\nPayPal Security Team",
                "security@paypa1-support.com",
                profilePictures[0],
                true,
                false
            ),

            new Email(
                "Congratulations! You’ve Won a £50 Gift Card!",
                "Dear Customer,\n\nYou have been selected as the lucky winner of a £50 Amazon Gift Card! To claim your reward, simply click the link below.\n\n<u><color=#0000FF>http://amazon-gift-prize.com/claim</color></u>\n\nOffer expires in 48hrs!\n\nBest,\nAmazon Rewards Team",
                "rewards@amaz0n-prizes.com",
                profilePictures[1],
                true,
                false
            ),

            new Email(
                "Security Alert: Unauthorized Login Attempt!",
                "Hello,\n\nWe detected an unauthorized login attempt on your Microsoft account. If this wasn't you, please secure your account immediately.\n\nhttp://microsoft-account-security.com/reset\n\nBest,\n\nMicrosoft Security Team",
                "support@microsoft-secure.com",
                profilePictures[2],
                true,
                false
            ),

            new Email(
                "Meeting Reminder: Project Update",
                "Hi Team,\n\nThis is a reminder for our scheduled project update meeting at 2:00 PM. Please ensure you send me over a copy of the financial report by 1:00 PM.\n\nThanks,\nManagement Team\nOur Company",
                "management@company.com",
                profilePictures[3],
                false,
                false
            ),

            new Email(
                "Your Monthly Subscription Receipt",
                "Hi,\n\nThank you for your payment of £9.99 for your streaming service subscription.\n\nIf you did not authorize this payment, contact us immediately <u><color=#0000FF>http://nexflix.com/support</color></u>\n\nBest,\n\nCustomer Support Team\nNexflix",
                "support@nexflix.com",
                profilePictures[4],
                true,
                false
            )

        };

        Debug.Log("Emails initialised!");
        ShuffleEmails();
    }

    private void ShuffleEmails()
    {
        List<Email> shuffledEmails = new List<Email>(emailTemplates);

        // Shuffle using Fisher-Yates Algorithm
        for (int i = shuffledEmails.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            (shuffledEmails[i], shuffledEmails[j]) = (shuffledEmails[j], shuffledEmails[i]);
        }

        emailList = new List<Email>(shuffledEmails);
        Debug.Log("Shuffled Emails : " + emailList.Count);
    }

    public Email GetEmail(int emailNumber)
    {
        int number = emailNumber - 1;

        return emailList[number];
    }

    public List<Email> GetEmailQueue()
    {
        return new List<Email>(emailList); 
    }

}