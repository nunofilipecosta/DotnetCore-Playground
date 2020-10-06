using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsAndPractices.Singleton
{
    class FoodLogger
    {
        private List<string> foodLog;

        public FoodLogger()
        {
            this.foodLog = new List<string>();
        }

        public void log(string order)
        {
            this.foodLog.Add(order);
        }
    }

    class FoodLoggerSingleton
    {
        public FoodLoggerSingleton()
        {
            if(FoodLoggerSingleton.Instance == null)
            {
                FoodLoggerSingleton.Instance = new FoodLogger();
            }
        }

        public static FoodLogger Instance { get; private set; }

        public FoodLogger GetFoodLoggerInstance()
        {
            return FoodLoggerSingleton.Instance;
        }
    }
}
