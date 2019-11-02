using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Customiser : MonoBehaviour
{

    public Button m_HairRight, m_HairLeft, m_FaceRight, m_FaceLeft, m_OutfitRight, m_OutfitLeft, m_AccessoryRight, m_AccessoryLeft, m_Accept;
    public Image m_Hair, m_Face, m_Outfit, m_Accessory, m_Body;
    public Sprite[] m_HairTextures, m_FaceTextures, m_OutfitTextures, m_AccessoryTextures;

    private Dictionary<Image, int> textureIndexes = new Dictionary<Image, int>();

    private enum Feature { HAIR, FACE, OUTFIT, ACCESSORY };
    private enum Direction { LEFT = -1, RIGHT = 1 };

    // Start is called before the first frame update
    void Start()
    {

        m_Accept.onClick.AddListener(Accept);
        m_HairRight.onClick.AddListener(() => ButtonClicked(Feature.HAIR, Direction.RIGHT));
        m_HairLeft.onClick.AddListener(() => ButtonClicked(Feature.HAIR, Direction.LEFT));
        m_FaceRight.onClick.AddListener(() => ButtonClicked(Feature.FACE, Direction.RIGHT));
        m_FaceLeft.onClick.AddListener(() => ButtonClicked(Feature.FACE, Direction.LEFT));
        m_OutfitRight.onClick.AddListener(() => ButtonClicked(Feature.OUTFIT, Direction.RIGHT));
        m_OutfitLeft.onClick.AddListener(() => ButtonClicked(Feature.OUTFIT, Direction.LEFT));
        m_AccessoryRight.onClick.AddListener(() => ButtonClicked(Feature.ACCESSORY, Direction.RIGHT));
        m_AccessoryLeft.onClick.AddListener(() => ButtonClicked(Feature.ACCESSORY, Direction.LEFT));
        m_Hair.sprite = m_HairTextures[0];
        m_Face.sprite = m_FaceTextures[0];
        m_Outfit.sprite = m_OutfitTextures[0];
        m_Accessory.sprite = m_AccessoryTextures[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SlideAndChangeSprite(Image image, Sprite newSprite, Direction direction, float speed)
    {
        Vector3 pos = image.transform.position;
        for (float i = 0; i <= 600; i += Time.deltaTime * speed)
        {
            if (direction == Direction.LEFT)
            {
                if (i < 300)
                {
                    image.transform.position = pos + Vector3.left * i;
                }
                else
                {
                    image.overrideSprite = newSprite;
                    image.transform.position = pos - Vector3.left * (600 - i);
                }
            }
            else if (direction == Direction.RIGHT)
            {
                if (i < 300)
                {
                    image.transform.position = pos + Vector3.right * i;
                }
                else
                {
                    image.overrideSprite = newSprite;
                    image.transform.position = pos - Vector3.right * (600 - i);
                }
            }
            yield return null;
        }
        image.transform.position = pos;
    }

    void ButtonClicked(Feature feature, Direction direction)
    {
        Sprite[] spriteArray = null;
        Image image = null;
        switch (feature)
        {
            case Feature.HAIR:
                image = m_Hair;
                spriteArray = m_HairTextures;
                break;
            case Feature.FACE:
                image = m_Face;
                spriteArray = m_FaceTextures;
                break;
            case Feature.OUTFIT:
                image = m_Outfit;
                spriteArray = m_OutfitTextures;
                break;
            case Feature.ACCESSORY:
                image = m_Accessory;
                spriteArray = m_AccessoryTextures;
                break;
        }

        int index;
        textureIndexes.TryGetValue(image, out index);
        index = (index + spriteArray.Length + (int)direction) % spriteArray.Length;
        textureIndexes[image] = index;
        StartCoroutine(SlideAndChangeSprite(image, spriteArray[index], direction, 1000.0f));
    }


    public void Accept()
    {
        int width = m_Hair.mainTexture.width;
        int height = m_Hair.mainTexture.height;
        Color[] body = ((Texture2D)m_Body.mainTexture).GetPixels(0, 0, width, height);
        Color[] hair = ((Texture2D)m_Hair.mainTexture).GetPixels(0, 0, width, height); 
        Color[] face = ((Texture2D)m_Face.mainTexture).GetPixels(0, 0, width, height); 
        Color[] outfit = ((Texture2D)m_Outfit.mainTexture).GetPixels(0, 0, width, height); 
        Color[] accessory = ((Texture2D)m_Accessory.mainTexture).GetPixels(0, 0, width, height);

        Color[] character = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int index = x + height * y;
                if (body[index].a > 0)
                {
                    character[index] = body[index];
                }
                if (face[index].a > 0)
                {
                    character[index] = face[index];
                }
                if (hair[index].a > 0) {
                    character[index] = hair[index];
                }
                if (outfit[index].a > 0)
                {
                    character[index] = outfit[index];
                }
                if (accessory[index].a > 0)
                {
                    character[index] = accessory[index];
                }
            }
        }
        
        Texture2D destTex = new Texture2D(width, height);
        destTex.SetPixels(character);
        destTex.Apply();

        byte[] bytes = destTex.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Character.png", bytes);

        SceneManager.LoadScene(4);

    }



}
