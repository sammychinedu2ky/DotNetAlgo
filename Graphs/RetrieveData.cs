using System;
using System.Text.Json;

namespace DotNetAlgo.Graphs
{
    internal class RetrieveData
    {
        private UserModel? GetUser(int userId)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data.json");
            var p = JsonSerializer.Deserialize<List<UserModel>>
                (File.ReadAllText("Graphs\\Data.json"))!.FirstOrDefault(x => x.Id == userId);
            return p;
        }
   
        public string FindMostCommonTitle(int userId, int degreeOfSeperation)
        {
            var dic = new Dictionary<string, int>();
            HashSet<int> hash = new();
            var mainQueue = new Queue<List<int>>();
            mainQueue.Enqueue(new() { userId });
            for (var i = 0; i <= degreeOfSeperation; i++)
            {
                var tempQueue = new Queue<List<int>>();
                while (mainQueue.Count > 0)
                {
                    var listOfIds = mainQueue.Dequeue();
                    foreach (var id in listOfIds)
                    {
                        if (hash.Add(id))
                        {
                            var user = GetUser(id);
                            dic[user.Title] = dic.ContainsKey(user.Title) ? dic[user.Title] + 1 : 1;
                            tempQueue.Enqueue(user.Connections);
                        }
                    }
                }
                mainQueue = tempQueue;
            }
            // count highest occuring title in tempList
            var max = dic.MaxBy(x => x.Value);
            return max.Key;
        }

    }
}