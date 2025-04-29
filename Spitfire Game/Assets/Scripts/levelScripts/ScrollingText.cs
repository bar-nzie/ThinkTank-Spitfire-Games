using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ScrollingText : MonoBehaviour
{
    public RectTransform textTransform;
    public TextMeshProUGUI scrollingText;
    private int currentIndex = 0;
    public float typeSpeed = 0.0f * Time.deltaTime;

    private string Track1 = "Welcome to the skies pilot! You're sittin' in a legend - the Supermarine Spitfire. She's not just a plane, she's a symbol of defiance, grit and British engineering at its finest!";
    private string Track2 = "Look at those wings - elliptical and sleek. Not just for show! Designed by R.J. Mitchell to cut through the air like a razor. That shape gives you tighter turns and faster rolls.";
    private string Track3 = "Try it out now: Move left and right by pushing the joystick.";
    private string NiceJob = "Nice Job";
    private string Track4 = "First took to the air back in 1936. By the time the war came knockin', the Spitfire was ready. She earned her stripes in the Battle of Britain - held the line when the world damn near fell apart. That hum you hear? That's the Rolls-Royce Merlin engine singin'.";
    private string Track44 = "Pure power, it can reach speeds up to 360 miles per hour, making it one of the fastest planes of its time. Some later models even ran on the Griffon engine - turned this bird into a beast!";
    private string Track5 = "Now, let’s talk about the guns, cadet. The Spitfire is armed with eight .303 Browning machine guns, each shooting 1200 rounds per minute, making it especially effective against enemy aircraft. Try shooting the guns now with the button next to the joystick.";
    private string GreatShooting = "Great Shooting!";
    private string Track6 = "In 1941 a Spitfire pilot could have had as little as six months of training and 150 flight hours before being sent up to face off against the Luftwaffe's finest. However, seeing as you’re a natural, we can start with some more intense training straight away.";
    private string Objective = "Take down as many of the incoming training balloons you can before they get passed you.";
    private string Track10 = "The Spitfire was produced in large numbers during the war – over 20,000 units – making it one of the most produced British aircraft of World War II. It was used now only by the Royal Air Force but also various allied forces such as Australia, Canada and New Zealand.";
    private string Track9 = "Despite being lightweight and fast, the Spitfire was also robust. It was able to take significant damage and still remain airborne, a crucial feature when facing the dangers of aerial combat.";
    private string Track8 = "The Spitfire played a crucial role in the Battle of Britain, where it defended Britain from German Luftwaffe bombers and fighters. While the Hurricane also contributed significantly, the Spitfire’s speed and agility made it the preferred choice for many RAF pilots in dogfights.";
    private string Track7 = "The wing placement provided excellent lift that allowed for tighter turns, a vital feature for outmaneuvering enemy aircraft. Not only incredibly agile the wing placement gave the Spitfire a concentrated area of fire, which increased the chance of hitting enemy planes.";
    private string[] Transcript;
    private int i = 0;
    public bool waitForPlayerActionFlying;
    public bool waitForPlayerActionShooting;

    private void Start()
    {
        Transcript = new string[] { Track1, Track2, Track3, NiceJob, Track4, Track44, Track5, GreatShooting, Track6, Objective, Track7, Track8, Track9, Track10 };
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        while (currentIndex < Transcript.Length)
        {
            scrollingText.text = "";
            string currentText = Transcript[currentIndex];

            int lineLength = 100; // Max characters per line
            int charCount = 0;

            foreach (char letter in currentText)
            {
                scrollingText.text += letter;
                charCount++;

                if (charCount >= lineLength && letter == ' ')
                {
                    scrollingText.text += "\n";
                    charCount = 0;
                }

                yield return new WaitForSeconds(typeSpeed);
            }

            if (currentIndex == 2)
            {
                waitForPlayerActionFlying = true;
                yield return new WaitUntil(() => waitForPlayerActionFlying == false);
            }
            else if (currentIndex == 6)
            {
                waitForPlayerActionShooting = true;
                yield return new WaitUntil(() => waitForPlayerActionShooting == false);
            }

            currentIndex++;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void PlayerCompletedActionFlying()
    {
        waitForPlayerActionFlying = false;
    }
    public void PlayerCompletedActionShooting()
    {
        waitForPlayerActionShooting = false;
    }
}
