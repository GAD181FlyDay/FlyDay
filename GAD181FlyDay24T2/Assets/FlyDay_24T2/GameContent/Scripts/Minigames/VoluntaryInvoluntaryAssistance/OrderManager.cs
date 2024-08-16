using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// manages order timing and display and generation.
    /// </summary>
    public class OrderManager : MonoBehaviour
    {
        #region Variables
        public List<Order> activeOrders = new List<Order>();
        public DeliveryZone deliveryZone;
        public GameObject orderDisplayPrefab; 
        public Transform orderDisplayParent;  
        public float orderInterval = 4f; 

        public Sprite blueSprite;
        public Sprite redSprite;
        public Sprite greenSprite;

        [SerializeField] private float orderTimer;
        private float _orderTimerValue = 15;
        private List<float> _orderTimers = new List<float>();

        private Dictionary<string, Sprite> _luggageSprites;
        #endregion

        private void Start()
        {
            _luggageSprites = new Dictionary<string, Sprite>
        {
            { "blue", blueSprite },
            { "red", redSprite },
            { "green", greenSprite }
        };

            GenerateNewOrder();
            orderTimer = orderInterval;
            GenerateNewOrder();
            orderTimer = orderInterval;
        }

        private void Update()
        {
            orderTimer -= Time.deltaTime;
            if (orderTimer <= 0)
            {
                GenerateNewOrder();
                orderTimer = orderInterval;
            }

            for (int i = 0; i < _orderTimers.Count; i++)
            {
                _orderTimers[i] -= Time.deltaTime;
                if (_orderTimers[i] <= 0)
                {
                    RemoveOrder(i);
                    deliveryZone.luckyCoins -= 2;
                    deliveryZone.UpdateScoreText();
                    i--;
                }
            }
        }

        #region Private Functions.
        public void CompleteOrder(int index)
        {
            if (index >= 0 && index < activeOrders.Count)
            {
                Destroy(orderDisplayParent.GetChild(index).gameObject); // Remove the corresponding UI element
                activeOrders.RemoveAt(index);
                _orderTimers.RemoveAt(index);
            }
        }

        public void GenerateNewOrder()
        {
            string[] luggageTypes = { "blue", "red", "green" };
            string randomLuggageType = luggageTypes[Random.Range(0, luggageTypes.Length)];

            Order newOrder = new Order { luggageType = randomLuggageType };
            activeOrders.Add(newOrder);
            _orderTimers.Add(_orderTimerValue);

            UpdateOrderDisplay();
        }

        private void RemoveOrder(int index)
        {
            if (index >= 0 && index < activeOrders.Count)
            {
                Destroy(orderDisplayParent.GetChild(index).gameObject); 
                activeOrders.RemoveAt(index);
                _orderTimers.RemoveAt(index);
            }
        }

        private void UpdateOrderDisplay()
        {
            foreach (Transform child in orderDisplayParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var order in activeOrders)
            {
                GameObject newOrderDisplay = Instantiate(orderDisplayPrefab, orderDisplayParent);
                Image orderImage = newOrderDisplay.GetComponent<Image>();

                if (_luggageSprites.TryGetValue(order.luggageType, out Sprite sprite))
                {
                    orderImage.sprite = sprite;
                }
                else
                {
                    Debug.LogWarning("No sprite found for luggage type: " + order.luggageType);
                }
            }
        }
        #endregion
    }

    #region Class.
    [System.Serializable]
    public class Order
    {
        public string luggageType;
    }
    #endregion
}
