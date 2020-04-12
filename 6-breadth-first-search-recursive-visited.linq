<Query Kind="Program" />

IDictionary<string, string[]> graph = new Dictionary<string, string[]> {
	{"A", new [] {"B", "C"}},
	{"B", new [] {"D", "E"}},
	{"C", new [] {"F", "G", "E"}},
	{"E", new [] {"H"}}
};

void Main()
{
	var pathFound = BreadthFirstSearch("A", "H", new string[0], new List<string>());
	Console.WriteLine(pathFound); // [A, B, E, H]

	var pathNotFound = BreadthFirstSearch("A", "Z", new string[0], new List<string>());
	Console.WriteLine(pathNotFound); // []
}

IEnumerable<string> BreadthFirstSearch(string start, string end, IEnumerable<string> path, IList<string> visited)
{
	if (start == end)
	{
		return path.Concat(new[] { end });
	}

	if (!graph.ContainsKey(start)) { return new string[0]; }


	return graph[start].Aggregate(new string[0], (acc, letter) =>
	{
		if (visited.Contains(letter))
		{
			return acc;
		}

		visited.Add(letter);

		var result = BreadthFirstSearch(letter, end, path.Concat(new[] { start }), visited);
		return acc.Concat(result).ToArray();
	});
}