using UnityEngine;

public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    public SceneChangerController changer;
    private RectTransform rectTransform;
    private Animator animator;
    private float labelHeight = -1;


    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        animator.SetTrigger("Show");
        for (int i = 0; i < scene.labels.Count; i++)
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();

            if (labelHeight == -1)
            {
                labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.labels[i], this, CalculateHeight(i, scene.labels.Count));
        }

        Vector2 size = rectTransform.sizeDelta;
        size.y = (scene.labels.Count + 2) * labelHeight;
        rectTransform.sizeDelta = size;

    }

    public void PerformChoose(StoryScene scene)
    {
        changer.PlayScene(scene);
        animator.SetTrigger("Hide");
    }

    private float CalculateHeight(int index, int count)
    {
        if (count % 2 == 0)
        {
            if (index < count / 2)
            {
                return labelHeight * (count / 2 - index - 1) + labelHeight / 2;
            }
            else
            {
                return (-1)*(labelHeight * (index - count / 2) + labelHeight / 2);
            }
        }
        else
        {
            if (index < count / 2)
            {
                return labelHeight * (count / 2 - index);
            }
            else if (index > count / 2)
            {
                return (-1) * (labelHeight * (index - count / 2));
            }
            else
            {
                return 0;
            }
        }
    }
    private void DestroyLabels()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
