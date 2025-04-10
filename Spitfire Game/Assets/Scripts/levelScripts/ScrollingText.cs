using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ScrollingText : MonoBehaviour
{
    public RectTransform textTransform;
    public TextMeshProUGUI scrollingText;
    public float scrollSpeed = 50f;
    public float resetPositionX = 1000f;
    public float endPositionX = 0f;

    private string Track1 = "Welcome to the skies pilot! You're sittin' in a legend - the Supermarine Spitfire. She's not just a plane, she's a symbol of defiance, grit and British engineering at its finest!";
    private string Track2 = "Look at those wings - elliptical and sleek. Not just for show! Designed by R.J. Mitchell to cut through the air like a razor. That shape gives you tighter turns and faster rolls.";
    private string Track3 = "Try it out now: Move left and right by pushing the joystick.";
    private string NiceJob = "Nice Job";
    private string Track4 = "First took to the air back in 1936. By the time the war came knockin', the Spitfire was ready. She earned her stripes in the Battle of Britain - held the line when the world damn near fell apart. That hum you hear? That's the Rolls-Royce Merlin engine singin'. Pure power, it can reach speeds up to 360 miles per hour, making it one of the fastest planes of its time. Some later models even ran on the Griffon engine - turned this bird into a beast!";
    private string Track5 = "Now, let’s talk about the guns, cadet. The Spitfire is armed with eight .303 Browning machine guns, each shooting 1200 rounds per minute, making it especially effective against enemy aircraft. Try shooting the guns now with the button next to the joystick.";
    private string GreatShooting = "Great Shooting!";
    private string Track6 = "In 1941 a Spitfire pilot could have had as little as six months of training and 150 flight hours before being sent up to face off against the Luftwaffe's finest. However, seeing as you’re a natural, we can start with some more intense training straight away.";
    private string Objective = "Take down as many of the incoming training balloons you can before they get passed you.";
    private string Track7 = "The Spitfire was produced in large numbers during the war – over 20,000 units – making it one of the most produced British aircraft of World War II. It was used now only by the Royal Air Force but also various allied forces such as Australia, Canada and New Zealand.";
    private string Track8 = "Despite being lightweight and fast, the Spitfire was also robust. It was able to take significant damage and still remain airborne, a crucial feature when facing the dangers of aerial combat.";
    private string Track9 = "The Spitfire played a crucial role in the Battle of Britain, where it defended Britain from German Luftwaffe bombers and fighters. While the Hurricane also contributed significantly, the Spitfire’s speed and agility made it the preferred choice for many RAF pilots in dogfights.";
    private string Track10 = "The wing placement provided excellent lift that allowed for tighter turns, a vital feature for outmaneuvering enemy aircraft. Not only incredibly agile the wing placement gave the Spitfire a concentrated area of fire, which increased the chance of hitting enemy planes.";
    private string[] Transcript;
    private float Track1Length = -3000f;
    private float Track2Length = -3000f;
    private float Track3Length = -1000f;
    private float NiceJobLength = -250f;
    private float Track4Length = -7000f;
    private float Track5Length = -4000f;
    private float GreatShootingLength = -250f;
    private float Track6Length = -4000f;
    private float ObjectiveLength = -1500f;
    private float Track7Length = -4500f;
    private float Track8Length = -3000f;
    private float Track9Length = -4500f;
    private float Track10Length = -4500f;
    private float[] TranscriptLength;
    private int i = 0;

    private void Start()
    {
        Transcript = new string[] { Track1, Track2, Track3, NiceJob, Track4, Track5, GreatShooting, Track6, Objective, Track7, Track8, Track9, Track10 };
        TranscriptLength = new float[] { Track1Length, Track2Length, Track3Length, NiceJobLength, Track4Length, Track5Length, GreatShootingLength, Track6Length, ObjectiveLength, Track7Length, Track8Length, Track9Length, Track10Length };
    }

    // Update is called once per frame
    void Update()
    {
        if (textTransform == null) return;

        textTransform.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

        if (textTransform.anchoredPosition.x < endPositionX)
        {
            textTransform.anchoredPosition = new Vector2(resetPositionX, textTransform.anchoredPosition.y);
            scrollingText.text = Transcript[i];
            endPositionX = TranscriptLength[i];
            i++;
        }
    }
}
