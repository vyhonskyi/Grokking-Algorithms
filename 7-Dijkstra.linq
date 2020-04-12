<Query Kind="Program" />

Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>> {
		{"start", new Dictionary<string, int> {{"a", 6}, {"b", 2}}},
		{"a", new Dictionary<string, int> {{"end", 1}}},
		{"b", new Dictionary<string, int> {{"a", 3}, {"end", 5}}},
		{"end", new Dictionary<string, int>()}
	};

Dictionary<string, int> costs = new Dictionary<string, int>() {};
Dictionary<string, string> parents = new Dictionary<string, string>(){};
List<string> processed = new List<string>();

void Main()
{	
	var node = "start";	
	var neighbors = graph[node];
	
	foreach (var n in neighbors.Keys)
	{
		costs[n] = graph[node][n];
		parents[n] = node;
	}
		
	node = FindLowestCostNode();
	
	while (node != null)
	{		
		var cost = costs[node];
		neighbors = graph[node];

		foreach (var n in neighbors.Keys)
		{
			var newCost = cost + neighbors[n];

			if (!costs.ContainsKey(n) || costs[n] > newCost)
			{
				costs[n] = newCost;
				parents[n] = node;
			}
		}

		processed.Add(node);
		node = FindLowestCostNode();
	}
	
	costs.Dump();
	parents.Dump();
}

string FindLowestCostNode()
{
	return costs
		.Where(x => !processed.Contains(x.Key))
		.OrderBy(x => x.Value)
		.Select(x => x.Key)
		.FirstOrDefault();
}

// Define other methods and classes here
