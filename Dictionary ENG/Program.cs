using System.Text.Json;
Dictionary<string, string> dict = new Dictionary<string, string>();
//dict.Add("hello", "Привет");
//dict.Add("bye", "Пока");
//string str = JsonSerializer.Serialize<Dictionary<string, string>>(dict);
//File.WriteAllText("dictionary.json", str);
string str = File.ReadAllText("dictionary.json");
dict = JsonSerializer.Deserialize<Dictionary<string, string>>(str);
do
{
    Console.WriteLine("\t\t\tDictionary\n");
    Console.WriteLine("Input\n1-to show base\n2-Add word\n3-Deleted word\n4-Search word\n5-Sort word");
    int key = int.Parse(Console.ReadLine());
    switch (key)
    {
        case 1:
            foreach (var item in dict)
                Console.WriteLine($"{item.Key} : {item.Value}");
            break;
        case 2:
            Console.WriteLine("Input word eng");
            string eng = Console.ReadLine();
            foreach (var item in dict)
            {
                if (item.Key == eng)
                {
                    Console.WriteLine("Word already added");
                    break;
                }
                else
                {
                    Console.WriteLine("Input word rus");
                    string rus = Console.ReadLine();
                    dict.Add(eng, rus);
                    str = JsonSerializer.Serialize<Dictionary<string, string>>(dict);
                    File.WriteAllText("dictionary.json", str);
                    Console.WriteLine("Word is added");
                    break;
                }
            }
            break;
        case 3:
            Console.WriteLine("Input search word eng");
            string search = Console.ReadLine();
            string outstr = string.Empty;
            if (dict.TryGetValue(search, out outstr))
            {
                dict.Remove(search);
                str = JsonSerializer.Serialize<Dictionary<string, string>>(dict);
                File.WriteAllText("dictionary.json", str);
                Console.WriteLine("Word is deleted");
            }
            else
            {
                Console.WriteLine("there is no such word in the dictionary");
            }
            break;
        case 4:
            Console.WriteLine("Input search word eng");
            search = Console.ReadLine();
            outstr = string.Empty;
            if (dict.TryGetValue(search, out outstr))
            {
                Console.WriteLine(outstr);
            }
            else
            {
                Console.WriteLine("there is no such word in the dictionary");
            }
            break;
        case 5:
            var list = dict.Keys.ToList();
            list.Sort();
            foreach (var keys in list)
            {
                Console.WriteLine("{0}: {1}", keys, dict[keys]);
            }
            break;
        default:
            Console.WriteLine("Erore only 1 - 5");
            break;
    }
} while(true);
