<Query Kind="Program" />

void Main()
{
	var stations = new Dictionary<string, HashSet<string>>
	{
		{"KONE", new HashSet<string>(new string[] {"ID", "NV", "UT"})},
		{"KTWO", new HashSet<string>(new string[] {"WA", "ID", "MT"})},
		{"KTHREE", new HashSet<string>(new string[] {"OR", "NV", "CA"})},
		{"KFOUR", new HashSet<string>(new string[] {"NV", "UT"})},
		{"KFIVE", new HashSet<string>(new string[] {"CA", "AZ"})}
	};
	
	var statesNeeded = new HashSet<string>(stations.SelectMany(x => x.Value));
	var finalStations = new List<string>();

	while (statesNeeded.Count > 0)
	{
		string bestStation = null;
		var statesCovered = new HashSet<string>();

		foreach (var kv in stations)
		{
			string station = kv.Key;
			HashSet<string> states = kv.Value;

			var covered = new HashSet<string>(statesNeeded.Intersect(states));
			if (covered.Count > statesCovered.Count)
			{
				bestStation = station;
				statesCovered = covered;
			}
		}

		statesNeeded = new HashSet<string>(statesNeeded.Except(statesCovered));
		finalStations.Add(bestStation);
	}

	finalStations.Dump();
}

// Define other methods and classes here