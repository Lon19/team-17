using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customiser : MonoBehaviour
{

    public Button m_HairRight, m_HairLeft;
    public Image m_Hair;
    public Sprite[] m_HairTextures;

    private Dictionary<Image, int> textureIndexes = new Dictionary<Image, int>();

    private enum Feature { HAIR };
    private enum Direction { LEFT = -1, RIGHT = 1 };

    // Start is called before the first frame update
    void Start()
    {
        m_HairRight.onClick.AddListener(() => ButtonClicked(Feature.HAIR, Direction.RIGHT));
        m_HairLeft.onClick.AddListener(() => ButtonClicked(Feature.HAIR, Direction.LEFT));
        m_Hair.sprite = m_HairTextures[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SlideAndChange(Image image, Sprite newSprite, Direction direction, float speed)
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
        }

        int index;
        textureIndexes.TryGetValue(image, out index);
        index = (index + (int)direction) % spriteArray.Length;
        textureIndexes[image] = index;
        StartCoroutine(SlideAndChange(image, spriteArray[index], direction, 1000.0f));
    }
}
