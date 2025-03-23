using System;
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
                "Dear Valued Customer,\n\nWe have detected suspicious activity on your account and have temporarily suspended access. Click the secure verification link below to verify your account before it is permanently closed:\n\n<u><color=#00AEFF>http://paypal-security-verification.com/login</color></u>\n\nFailure to act will result in permanent deactivation of your account.\n\nThank you,\nPayPal Security Team",
                "security@paypa1-support.com",
                profilePictures[0],
                true,
                false
            ),

            new Email(
                "Congratulations! You’ve Won a £50 Gift Card!",
                "Dear Customer,\n\nYou have been selected as the lucky winner of a £50 Amazon Gift Card! To claim your reward, simply click the link below.\n\n<u><color=#00AEFF>http://amazon-gift-prize.com/claim</color></u>\n\nOffer expires in 48hrs!\n\nBest,\nAmazon Rewards Team",
                "rewards@amaz0n-prizes.com",
                profilePictures[1],
                true,
                false
            ),

            new Email(
                "Security Alert: Unauthorized Login Attempt!",
                "Hello,\n\nWe detected an unauthorized login attempt on your Microsoft account. If this wasn't you, please secure your account immediately.\n\n <u><color=#00AEFF>http://microsoft-account-security.com/reset</color></u>\n\nBest,\n\nMicrosoft Security Team",
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
                "Hi,\n\nThank you for your payment of £9.99 for your streaming service subscription.\n\nIf you did not authorize this payment, contact us immediately <u><color=#00AEFF>http://nexflix.com/support</color></u>\n\nBest,\n\nCustomer Support Team\nNexflix",
                "support@nexflix.com",
                profilePictures[4],
                true,
                false
            ),
            
            new Email(
                "Timesheet Reminder!",
                "Hello,\n\nThis is a reminder to complete your weekly timesheet.\n\n<u><color=#00AEFF>http://companyportal.com/timesheet</color></u>\n\nBest,\n\nHR Team\nCompany",
                "hr_payroll@company.com",
                profilePictures[5],
                false,
                false
            ),
            
            new Email(
                "Company Credit Card Expiry!",
                "Hello, valued Employee!\n\nThis is a reminder that your Company Credit Card is due to EXPIRE in the next 7 days.\n\nTo prevent the card from expiring, follow this link. <u><color=#00AEFF>http://companycreditcrd.com/expiry</color></u>\n\nRegards,\n\nCredit Card Company",
                "hr_payroll@company.com",
                profilePictures[6],
                false,
                true
            ),

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
        return emailList[emailNumber];
    }

    public List<Email> GetEmailQueue()
    {
        return new List<Email>(emailList); 
    }

}