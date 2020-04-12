<Query Kind="Program" />

void Main()
{
	var items = new Item[]
	{
		new Item {Name = "guitar", Price = 1500, Weight = 1},
		new Item {Name = "player", Price = 3000, Weight = 4},
		new Item {Name = "laptop", Price = 2000, Weight = 3},
	};

	var maxWeight = items.Max(x => x.Weight);
	var table = new IEnumerable<Item>[items.Length, maxWeight];

	for (var i = 0; i < table.GetLength(0); i++)
	{
		var item = items[i];

		for (var j = 0; j < table.GetLength(1); j++)
		{
			var prevItems = i == 0 ? new Item[0] : table[i - 1, j];
			var cellWeight = j + 1;

			if (item.Weight <= cellWeight)
			{
				var remainingWeight = cellWeight - item.Weight;

				IEnumerable<Item> remainingItems = new Item[0];
				
				if (i > 0 && remainingWeight > 0)
				{
					remainingItems = table[i - 1, remainingWeight - 1];
				}

				var currentItems = new Item[] { item }.Concat(remainingItems);

				if (currentItems.Sum(x => x.Price) > prevItems.Sum(x => x.Price))
				{
					table[i, j] = currentItems;
				}
				else
				{
					table[i, j] = prevItems;
				}
			}
			else
			{
				table[i, j] = prevItems;
			}
		}		
	}
	
	table[table.GetLength(0) -1 , table.GetLength(1) -1].Dump("Best combination");
}

class Item
{
	public string Name;
	public int Price;
	public int Weight;
}
