using Day1;

var inputLines = Input.Data.Trim()
    .Split(Environment.NewLine);

// Part one

int GetSum(string[] inputLines)
{
    var sum = 0;
    
    foreach (var line in inputLines)
    {
        sum += GetNumber(line);
    }

    return sum;
}

int GetNumber(string line)
{
    var numbers = line.Where(c => int.TryParse(c.ToString(),
            out _))
        .Select(c => int.Parse(c.ToString()))
        .ToList();
    if (numbers.Count == 0) return 0;
    var first = numbers.First();
    var last = numbers.Last();
    return first * 10 + last;
}

Console.WriteLine(GetSum(inputLines));

// Part two
var sum = 0;
foreach(var line in inputLines)
{
    var numbers = new List<int>();
    for(int i = 0; i < line.Length; i++)
    {
        if(int.TryParse(line[i].ToString(), out int num))
        {
            numbers.Add(num);
        }
        else
        {
            var leftChars = line.Length - i;
            if(leftChars < 3) continue;
            var possibleLength = leftChars < 5 ? leftChars : 5;
            var possibleNumber = line.Substring(i, possibleLength);
            
            if(possibleNumber.StartsWith("one")) numbers.Add(1);
            else if(possibleNumber.StartsWith("two")) numbers.Add(2);
            else if(possibleNumber.StartsWith("three")) numbers.Add(3);
            else if(possibleNumber.StartsWith("four")) numbers.Add(4);
            else if(possibleNumber.StartsWith("five")) numbers.Add(5);
            else if(possibleNumber.StartsWith("six")) numbers.Add(6);
            else if(possibleNumber.StartsWith("seven")) numbers.Add(7);
            else if(possibleNumber.StartsWith("eight")) numbers.Add(8);
            else if(possibleNumber.StartsWith("nine")) numbers.Add(9);
        }
    }
    if(numbers.Count == 0) continue;
    var first = numbers.First();
    var last = numbers.Last();
    sum += first * 10 + last;
}
Console.WriteLine(sum);