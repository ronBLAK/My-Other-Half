using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PhotoRandomiser : MonoBehaviour
{
    System.Random random = new System.Random();

    // all possible photo frames that can be displayed
    public GameObject photoOne;
    public GameObject photoTwo;

    // array holding the that are photos up for display
    private GameObject[] photos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        photos = new GameObject[] { photoOne, photoTwo }; // add the photo game objects into the corresponding list. NOTE: THE SIZE OF THE PHOTOS ARRAY MUST BE THE SAME AS THE NUMBER OF INDICES IN THE NUMBER ARRAY

        int randomIndex = random.Next(0, photos.Length); // return a random index to select an item from the photos list at the random index

        GameObject selectedPhoto = photos[randomIndex]; // select a photo from the returned index

        selectedPhoto.SetActive(true);
    }
}
