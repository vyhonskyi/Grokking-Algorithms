<Query Kind="Program" />

Dictionary<string, string[]> graph = new Dictionary<string, string[]> {
	{"a", new [] {"b", "c"}},
	{"b", new [] {"d", "e"}},
	{"c", new [] {"f", "g"}},
	{"e", new [] {"h"}}
};

void Main()
{
	var found = BreadthFirstSearch("a", "h");
	found.Dump("End node");
}

string BreadthFirstSearch(string start, string end)
{
	var queue = new List<string>();
	queue.Add(start);

	do
	{
		var letter = queue[0];
		queue.RemoveAt(0);

		if (letter == end)
		{
			return end;
		}
		else
		{
			if (graph.ContainsKey(letter))
			{
				queue.AddRange(graph[letter]);
			}
		}
	} while (queue.Count > 0);

	return null;
}

// Define other methods and classes here