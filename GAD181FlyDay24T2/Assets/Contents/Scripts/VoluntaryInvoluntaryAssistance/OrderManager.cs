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
        public TMP_Text ordersText;
        public float orderLifetime = 20f;
        public float orderInterval = 5f;
        public List<Order> activeOrders = new List<Order>();

        private float _timeSinceLastOrder = 0f;
        #endregion

        private void Update()
        {
            _timeSinceLastOrder += Time.deltaTime;

            if (_timeSinceLastOrder >= orderInterval)
            {
                GenerateOrder();
                _timeSinceLastOrder = 0f;
            }

            UpdateOrders();
            DisplayOrders();
        }

        #region Private Functions.
        private void GenerateOrder()
        {
            string[] luggageTypes = { "black", "red", "green" };
            string newOrderType = luggageTypes[Random.Range(0, luggageTypes.Length)];
            Order newOrder = new Order { luggageType = newOrderType, timeRemaining = orderLifetime };
            activeOrders.Add(newOrder);
        }

        private void UpdateOrders()
        {
            for (int i = activeOrders.Count - 1; i >= 0; i--)
            {
                activeOrders[i].timeRemaining -= Time.deltaTime;
                if (activeOrders[i].timeRemaining <= 0)
                {
                    activeOrders.RemoveAt(i);
                }
            }
        }

        private void DisplayOrders()
        {
            ordersText.text = "Orders:\n";
            foreach (Order order in activeOrders)
            {
                ordersText.text += $"{order.luggageType} ({order.timeRemaining:F1}s)\n";
            }
        }
        #endregion

        #region Class
        public class Order
        {
            public string luggageType;
            public float timeRemaining;
        }
        #endregion
    }
}