<Query Kind="Program" />

IDictionary<string, string[]> graph = new Dictionary<string, string[]> {
	{"A", new [] {"B", "C"}},
	{"B", new [] {"D", "E"}},
	{"C", new [] {"F", "G"}},
	{"E", new [] {"H"}}
};

void Main()
{
	var pathFound = BreadthFirstSearch("A", "H", new string[0]);
	Console.WriteLine(pathFound); // [A, B, E, H]

	var pathNotFound = BreadthFirstSearch("A", "Z", new string[0]);
	Console.WriteLine(pathNotFound); // []
}

IEnumerable<string> BreadthFirstSearch(string start, string end, IEnumerable<string> path)
{
	if (start == end)
	{
		return path.Concat(new[] { end });
	}

	if (!graph.ContainsKey(start)) { return new string[0]; }	

	return graph[start].SelectMany(letter => BreadthFirstSearch(letter, end, path.Concat(new[] { start })));
}