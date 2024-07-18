using TMPro;
using System.Collections.Generic;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// manages order timing and display and generation.
    /// </summary>

    public class OrderManager : MonoBehaviour
    {
        #region Variables
        public List<Order> activeOrders = new List<Order>();
        public TMP_Text orderText;
        public float orderInterval = 20f; // Time interval for generating new orders
        private float orderTimer;
        private List<float> orderTimers = new List<float>();
        #endregion

        private void Start()
        {
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

            for (int i = 0; i < orderTimers.Count; i++)
            {
                orderTimers[i] -= Time.deltaTime;
                if (orderTimers[i] <= 0)
                {
                    RemoveOrder(i);
                    i--; // Adjust the index after removal
                }
            }
        }

        #region Private Functions.
        public void CompleteOrder(int index)
        {
            if (index >= 0 && index < activeOrders.Count)
            {
                activeOrders.RemoveAt(index);
                orderTimers.RemoveAt(index);
                UpdateOrderDisplay();
            }
        }

        public void GenerateNewOrder()
        {
            string[] luggageTypes = { "black", "red", "green" };
            string randomLuggageType = luggageTypes[Random.Range(0, luggageTypes.Length)];

            Order newOrder = new Order { luggageType = randomLuggageType };
            activeOrders.Add(newOrder);
            orderTimers.Add(20f); // Set timer for the new order

            UpdateOrderDisplay();
        }

        private void RemoveOrder(int index)
        {
            if (index >= 0 && index < activeOrders.Count)
            {
                activeOrders.RemoveAt(index);
                orderTimers.RemoveAt(index);
                UpdateOrderDisplay();
            }
        }

        private void UpdateOrderDisplay()
        {
            if (orderText != null)
            {
                orderText.text = string.Empty;
                foreach (var order in activeOrders)
                {
                    orderText.text += order.luggageType + "\n";
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