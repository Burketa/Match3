using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    #region Class Swipes definition
    /*
    [SerializeField]
    public class Swipes
    {
        private bool right;
        private bool left;
        private bool up;
        private bool down;
        private bool horizontal;
        private bool vertical;
        public bool Right
        {
            get { return right; }
            set { right = value; }
        }
        public bool Left
        {
            get { return left; }
            set { left = value; }
        }
        public bool Up
        {
            get { return up; }
            set { up = value; }
        }
        public bool Down
        {
            get { return down; }
            set { down = value; }
        }
        public bool Horizontal
        {
            get { return horizontal; }
            set { horizontal = value; }
        }
        public bool Vertical
        {
            get { return vertical; }
            set { vertical = value; }
        }

        public Swipes(bool rightValue, bool leftValue, bool upValue, bool downValue, bool horizontalValue, bool verticalValue)
        {
            right = rightValue;
            left = leftValue;
            up = upValue;
            down = downValue;
            horizontal = horizontalValue;
            vertical = verticalValue;
        }
    }*/
    #endregion

    #region Public Variables
    public float timerInitialValue = 2.0f;
    #endregion

    #region Private Variables
    private int points = 0;
    #endregion

    #region Methods
    void Awake()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
    }

    void Start()
    {
        Setup();
    }

    void Setup()
    {
        ;
    }
    #endregion
}
