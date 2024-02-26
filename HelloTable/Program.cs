using System.Text;
using Newtonsoft.Json.Linq;


namespace HelloTable
{
    internal class Program
    {
        public class Managment
        {
            public ConsoleKeyInfo key;
            public int[] Cursor = { 0, 0 };
            public List<StringBuilder> ColumnNames = new List<StringBuilder>()
            {
                new StringBuilder("id"),
                new StringBuilder("firstName"),
                new StringBuilder("lastName"),
            };
            public List<StringBuilder> ColumnTypes = new List<StringBuilder>()
            {
                new StringBuilder("5"),
                new StringBuilder("2"),
                new StringBuilder("3")
            };
            public List<StringBuilder> Blanks = new List<StringBuilder>()
            {
                new StringBuilder("0"),
                new StringBuilder("0"),
                new StringBuilder("0")
            };
            public List<StringBuilder> Min = new List<StringBuilder>()
            {
                new StringBuilder("0"),
                new StringBuilder("0"),
                new StringBuilder("0")
            };
            public List<StringBuilder> Max = new List<StringBuilder>()
            {
                new StringBuilder("100"),
                new StringBuilder("100"),
                new StringBuilder("100")
            };
            public List<StringBuilder> End = new List<StringBuilder>()
            {
                new StringBuilder(" X "),
                new StringBuilder(" X "),
                new StringBuilder(" X ")
            };
            public string[] Types =
            {
                "",
                "gender",
                "firstName",
                "lastName",
                "fullName",
                "row",
                "number",
                "streetName",
                "city",
                "country",
                "postcode",
                "email",
                "username",
                "password",
                "birthDate",
                "age",
                "picturePath",
                ""
            };
            public StringBuilder TableName= new StringBuilder("HelloTable");
            public StringBuilder RowCount= new StringBuilder("50");
            public StringBuilder Generate= new StringBuilder("Generate");
            public string isMinMax = "6";
            public List<int> empties = new List<int>();


            public Managment()
            {
                Console.CursorVisible = false;

                Intro();
                Menu();
            }

            public void Intro()
            {
                void QuickSetUp()
                {
                    if(!Directory.Exists("C:/HelloTable"))
                    {
                        Directory.CreateDirectory("C:/HelloTable");
                        File.WriteAllText("C:/HelloTable/readME.txt", "powered by Abu_Programmiy");
                    }
                }
                QuickSetUp();

                string newlines = new string('\n', 7);
                string Headerspaces = new string(' ', 56);
                string Controlspaces = new string(' ', 50);
                string Controlspaces1 = new string(' ', 45);
                
                while (true)
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{newlines}{Headerspaces}Hello Table");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"\n\n{Controlspaces}  ^");
                    Console.WriteLine($"{Controlspaces}< v >    -->  to choose\n");
                    Console.WriteLine($"{Controlspaces1}Tab / Shift-Tab    -->  to change\n\n");
                    Console.WriteLine($"{Controlspaces} press Enter to start");

                    key = Console.ReadKey();
                    if (key.KeyChar == '\u000D')
                        return;
                    Console.Clear();
                }
            }

            public void Menu()
            {
                string newlines = new string('\n', 3);
                string spaces = new string(' ', 20);
                string lines = new string('-', 36);
                string ColumnLines = new string('-', 13) + "+";
                string MaxMinLinesTop = "---Min-------Max---+";
                string MaxMinLinesDown = new string('-', 19) + "+";
                string LastSetingsLine = new string(' ', 36)+"+"+new string('-',20)+"+"+new string(' ',13)+"+"+new string('-',5)+"+"+new string(' ',4);
                string generateLine = "+" + new string('-', 10) + "+";
                string LastSpaces = new string(' ', 25);
                bool bug = false;
                bool bug1 = false;
                bool bug2 = false;

                List<List<StringBuilder>> Elements = new List<List<StringBuilder>>()
                {
                    End,ColumnNames,Blanks,ColumnTypes,Min,Max
                };
                List<StringBuilder> BottomSetings = new List<StringBuilder>()
                {
                    TableName,RowCount,Generate
                };

                void Print(int e, int i)
                {
                    if (Elements[e] == End)
                        Console.Write("{0}", End[i]);
                    else if (Elements[e] == ColumnNames)
                        Console.Write(" {0,-20}", ColumnNames[i]);
                    else if (Elements[e] == Blanks)
                        Console.Write(" Blank: {0,3}% ", Blanks[i]);
                    else if (Elements[e] == ColumnTypes)
                        Console.Write(" {0,-12}", Types[Convert.ToInt64(ColumnTypes[i].ToString())]);
                    else if (Elements[e] == Min && ColumnTypes[i].ToString() == isMinMax)
                        Console.Write(" {0,-8}", Min[i]);
                    else if (Elements[e] == Max && ColumnTypes[i].ToString() == isMinMax)
                        Console.Write(" {0,-8}", Max[i]);
                }

                void Printer(int b)
                {
                    if (BottomSetings[b] == TableName)
                    {
                        Console.Write("TableName: ");
                        if (Cursor[0] < ColumnNames.Count + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else Console.Write("|");
                        if (Cursor[1] == b && Cursor[0]>ColumnNames.Count)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(" {0,-18} ", TableName);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                            Console.Write(" {0,-18} ", TableName);
                    }

                    else if (BottomSetings[b] == RowCount)
                    {
                        Console.Write("   RowCount: ");
                        if (Cursor[0] < ColumnNames.Count + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else Console.Write("|");

                        if (Cursor[1] == b && Cursor[0] > ColumnNames.Count)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(" {0,-3} ", RowCount);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                            Console.Write(" {0,-3} ", RowCount);
                    }

                    else if (BottomSetings[b]==Generate)
                    {
                        if (Cursor[0] < ColumnNames.Count + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("    |");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("    |");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        if (Cursor[1] == b && Cursor[0] > ColumnNames.Count)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" {0} ", Generate);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" {0} ", Generate);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                    }

                    if (Cursor[0] < ColumnNames.Count + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (BottomSetings[b] == Generate)
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write("|");
                        if (BottomSetings[b] == Generate)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
//Dont forget me
                bool Checker()
                {
                    bool notEmpty = false;
                    bool errorFound=false;
                    for(int i = 0;i<ColumnNames.Count;i++)
                    {
                        foreach(char c in ColumnNames[i].ToString())
                            if("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_".Contains(c))
                                notEmpty = true;

                        if (notEmpty == false)
                        {
                            empties.Add(i);
                            errorFound = true;
                        }
                    }

                    if (!notEmpty)
                        return true;
                    else 
                        return false;
                }

                //ReadKey Methods
                void ReadTheKey(ConsoleKeyInfo key)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (Cursor[0]>0)
                                {
                                    if (Cursor[0] == ColumnNames.Count + 1)
                                    {
                                        Cursor[1] = 0;
                                        Cursor[0]--;
                                    }
                                    else if (Cursor[0] == ColumnNames.Count)
                                        Cursor[0]--;
                                    else if (Cursor[1] > 3 && ColumnTypes[Cursor[0] - 1].ToString() != isMinMax)
                                    {
                                        Cursor[1] = 3;
                                        Cursor[0]--;
                                    }

                                    else
                                        Cursor[0]--;
                                }
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            {
                                if (Cursor[0]<=ColumnNames.Count)
                                {
                                    if (Cursor[0] == ColumnNames.Count - 1)
                                    {
                                        Cursor[1] = 0;
                                        Cursor[0]++;
                                    }

                                    else if (Cursor[0]==ColumnNames.Count)
                                        Cursor[0]++;

                                    else if (Cursor[1] > 3 && ColumnTypes[Cursor[0] + 1].ToString() != isMinMax)
                                    {
                                        Cursor[1] = 3;
                                        Cursor[0]++;
                                    }

                                    else
                                        Cursor[0]++;
                                }
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            {
                                if (Cursor[0] == ColumnNames.Count) { }
                                else if (Cursor[0]>ColumnNames.Count)
                                {
                                    if (Cursor[1]<BottomSetings.Count-1)
                                        Cursor[1]++;
                                }
                                else if (ColumnTypes[Cursor[0]].ToString()!=isMinMax)
                                {
                                    if (Cursor[1]<Elements.Count-3)
                                        Cursor[1]++;
                                }
                                else
                                {
                                    if (Cursor[1] < Elements.Count - 1)
                                        Cursor[1]++;
                                }
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            {
                                if (Cursor[0] == ColumnNames.Count) { }
                                else if (Cursor[0] > ColumnNames.Count)
                                {
                                    if (Cursor[1] > 0)
                                        Cursor[1]--;
                                }
                                else
                                {
                                    if (Cursor[1] > 0)
                                        Cursor[1]--;
                                }
                            }
                            break;
                    //Enter
                        case ConsoleKey.Enter:
                            {
                                if (Cursor[0] == ColumnNames.Count) 
                                {
                                    if(ColumnNames.Count<10)
                                    {
                                        End.Add(End[End.Count-1]);
                                        ColumnNames.Add(new StringBuilder(ColumnNames[ColumnNames.Count-1].ToString()));
                                        Blanks.Add(new StringBuilder(Blanks[Blanks.Count - 1].ToString()));
                                        ColumnTypes.Add(new StringBuilder(ColumnTypes[ColumnTypes.Count - 1].ToString()));
                                        Min.Add(new StringBuilder(Min[Min.Count - 1].ToString()));
                                        Max.Add(new StringBuilder(Max[Max.Count - 1].ToString()));
                                        Cursor[0]++;
                                    }
                                }
                                else if (Cursor[0] < ColumnNames.Count && Cursor[1]==0&&ColumnNames.Count>1)
                                {
                                    End.RemoveAt(Cursor[0]);
                                    ColumnNames.RemoveAt(Cursor[0]);
                                    Blanks.RemoveAt(Cursor[0]);
                                    ColumnTypes.RemoveAt(Cursor[0]);
                                    Min.RemoveAt(Cursor[0]);
                                    Max.RemoveAt(Cursor[0]);
                                }
                                else if (Cursor[0] > ColumnNames.Count && Cursor[1]==2)
                                {
                                    //Generate is activated
                                    Generator();
                                    while(Console.KeyAvailable)
                                        Console.ReadKey(intercept: true);
                                }
                            }
                            break;

                        case ConsoleKey.Backspace:
                            {
                                if (Cursor[0] < ColumnNames.Count )
                                {
                                    if (Cursor[1] == 1 && ColumnNames[Cursor[0]].Length>0)
                                        ColumnNames[Cursor[0]].Remove(ColumnNames[Cursor[0]].Length-1, 1);

                                    else if (Cursor[1] == 2)
                                    {
                                        if (Blanks[Cursor[0]].Length == 1)
                                            Blanks[Cursor[0]] = new StringBuilder("0");
                                        else
                                            Blanks[Cursor[0]].Remove(Blanks[Cursor[0]].Length - 1, 1);
                                    }

                                    else if (Cursor[1]==4)
                                    {
                                        if (Min[Cursor[0]].Length == 1)
                                            Min[Cursor[0]] = new StringBuilder("0");
                                        else
                                            Min[Cursor[0]].Remove(Min[Cursor[0]].Length - 1, 1);
                                    }

                                    else if (Cursor[1] == 5)
                                    {
                                        if (Max[Cursor[0]].Length == 1)
                                            Max[Cursor[0]] = new StringBuilder("0");
                                        else
                                            Max[Cursor[0]].Remove(Max[Cursor[0]].Length - 1, 1);
                                    }
                                }
                                else
                                {
                                    if (Cursor[1]==0&&TableName.Length>0)
                                        TableName.Remove(TableName.Length-1, 1);
                                    else if (Cursor[1]==1)
                                    {
                                        if (RowCount.Length == 1)
                                            RowCount.Replace(RowCount.ToString(),"0");
                                        else
                                            RowCount.Remove(RowCount.Length - 1, 1);
                                    }

                                }
                            }
                            break;

                        case ConsoleKey.Delete:
                            {
                                if (Cursor[0] < ColumnNames.Count)
                                {
                                    if (Cursor[1] == 1 && ColumnNames[Cursor[0]].Length > 0)
                                        ColumnNames[Cursor[0]].Remove(0, ColumnNames[Cursor[0]].Length);

                                    else if (Cursor[1] == 2)
                                            Blanks[Cursor[0]] = new StringBuilder("0");

                                    else if (Cursor[1] == 4)
                                            Min[Cursor[0]] = new StringBuilder("0");

                                    else if (Cursor[1] == 5)
                                            Max[Cursor[0]] = new StringBuilder("0");
                                }

                                else if (Cursor[0]>ColumnNames.Count)
                                {
                                    if (Cursor[1] == 0 && TableName.Length > 0)
                                        TableName.Remove(0, TableName.Length);
                                    else if (Cursor[1] == 1)
                                            RowCount.Replace(RowCount.ToString(), "0");

                                }
                            }
                            break;

                        default:
                            {
                            //Tab
                                if (Cursor[1]==3)
                                {
                                    if (key.Key == ConsoleKey.Tab && (key.Modifiers & ConsoleModifiers.Shift) != 0)
                                    {
                                        if (int.Parse(ColumnTypes[Cursor[0]].ToString()) > 1)
                                            ColumnTypes[Cursor[0]] = new StringBuilder((int.Parse(ColumnTypes[Cursor[0]].ToString()) - 1).ToString());
                                    }
                                    else if(key.Key == ConsoleKey.Tab)
                                    {
                                        if(int.Parse(ColumnTypes[Cursor[0]].ToString()) < Types.Length-2)
                                            ColumnTypes[Cursor[0]] = new StringBuilder((int.Parse(ColumnTypes[Cursor[0]].ToString()) + 1).ToString());
                                    }
                                }

                                if("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_ ".Contains(key.KeyChar))
                                {
                                    if (Cursor[1] == 0 && Cursor[0] > ColumnNames.Count)
                                    {
                                        if(TableName.Length<18)
                                            TableName.Append(key.KeyChar);
                                    }

                                    else if (Cursor[1] == 1 && Cursor[0] < ColumnNames.Count)
                                    {
                                        if (ColumnNames[Cursor[0]].Length<19)
                                            ColumnNames[Cursor[0]].Append(key.KeyChar);
                                    }

                                    else if (Cursor[1] == 1 && Cursor[0] > ColumnNames.Count)
                                    {
                                        if ("0123456789".Contains(key.KeyChar))
                                        {
                                            if (RowCount.ToString() == "0")
                                            {
                                                RowCount.Remove(0,RowCount.Length);
                                                RowCount.Append(key.KeyChar.ToString());
                                            }
                                            else if (RowCount.ToString()=="10"&& key.KeyChar=='0')
                                                RowCount.Append(key.KeyChar);
                                            else if(RowCount.Length<2)
                                                RowCount.Append(key.KeyChar);
                                        }
                                    }
                                    else if (Cursor[1] == 2 && Cursor[0] < ColumnNames.Count)
                                    {
                                        if("0123456789".Contains(key.KeyChar))
                                        {
                                            if (Blanks[Cursor[0]].ToString()=="0")
                                                Blanks[Cursor[0]]=new StringBuilder(key.KeyChar.ToString());
                                            else if (Blanks[Cursor[0]].Length<2)
                                                Blanks[Cursor[0]].Append(key.KeyChar);
                                            else if (Blanks[Cursor[0]].ToString() == "10"&& key.KeyChar=='0')
                                                Blanks[Cursor[0]].Append(key.KeyChar);
                                        }
                                    }
                                    else if (Cursor[1] == 4 && Cursor[0] < ColumnNames.Count)
                                    {
                                        if ("0123456789".Contains(key.KeyChar))
                                        {
                                            if (Min[Cursor[0]].Length<7)
                                            {
                                                if (Min[Cursor[0]].ToString()=="0")
                                                    Min[Cursor[0]].Replace("0", key.KeyChar.ToString());
                                                else
                                                    Min[Cursor[0]].Append(key.KeyChar);
                                            }
                                        }
                                    }
                                    else if (Cursor[1] == 5 && Cursor[0] < ColumnNames.Count)
                                    {
                                        if ("0123456789".Contains(key.KeyChar))
                                        {
                                            if (Max[Cursor[0]].Length < 7)
                                            {
                                                if (Max[Cursor[0]].ToString() == "0")
                                                    Max[Cursor[0]].Replace("0", key.KeyChar.ToString());
                                                else
                                                    Max[Cursor[0]].Append(key.KeyChar);
                                            }
                                        }
                                    }
                                }   
                            }
                            break;
                    }
                }


        //Asosiy Menu
                while (true)
                {
                    Console.Clear();
                    Console.Write(newlines);
                    if (Cursor[0] != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"\n{spaces}   +{lines}{ColumnLines}");
                        if (ColumnTypes[0].ToString() == isMinMax)
                            Console.WriteLine(MaxMinLinesTop);
                        else Console.WriteLine();
                    }
                    for (int i = 0; i < ColumnNames.Count; i++)
                    {
                        if (i == Cursor[0])
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"\n{spaces}   +{lines}");
                            if (Cursor[1] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(" {0,-13}", Types[Convert.ToInt64(ColumnTypes[i].ToString()) - 1]);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else
                                Console.Write(ColumnLines);

                            if (ColumnTypes[i].ToString() == isMinMax)
                            {
                                Console.Write(MaxMinLinesTop);
                                bug = true;
                            }
                            try
                            {
                                if (ColumnTypes[i - 1].ToString() == isMinMax && bug == false)
                                    Console.Write(MaxMinLinesDown);
                                else bug = false;
                            }
                            catch { bug = false; }
                            Console.Write($"\n{spaces}");
                            for (int j = 0; j < Elements.Count; j++)
                            {
                                if (j == Cursor[1])
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Print(j, i);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                else
                                {
                                    Print(j, i);
                                }
                                if (Elements[j] != Min && Elements[j] != Max)
                                    Console.Write("|");
                                else if (ColumnTypes[i].ToString() == isMinMax)
                                    Console.Write("|");
                            }
                            Console.Write($"\n{spaces}   +{lines}");
                            if (Cursor[1] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(" {0,-13}", Types[Convert.ToInt64(ColumnTypes[i].ToString()) + 1]);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else
                                Console.Write(ColumnLines);
                            try
                            {
                                if (ColumnTypes[i + 1].ToString() == isMinMax)
                                {
                                    Console.Write(MaxMinLinesTop);
                                    bug2 = true;
                                }
                            }
                            catch { bug2 = false; }
                            if (ColumnTypes[i].ToString() == isMinMax && bug2 == false)
                                Console.WriteLine(MaxMinLinesDown);
                            else { Console.WriteLine(); bug2 = false; }
                        }
                        else
                        {
                            Console.Write(spaces);
                            for (int j = 0; j < Elements.Count; j++)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Print(j, i);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                if (Elements[j] != Min && Elements[j] != Max)
                                    Console.Write("|");
                                else if (ColumnTypes[i].ToString() == isMinMax)
                                    Console.Write("|");
                            }
                            if (i + 1 != Cursor[0])
                            {
                                Console.Write($"\n{spaces}   +{lines}{ColumnLines}");
                                try
                                {
                                    if (ColumnTypes[i + 1].ToString() == isMinMax)
                                    {
                                        Console.Write(MaxMinLinesTop);
                                        bug1 = true;
                                    }

                                }
                                catch { bug1 = false; }
                                if (ColumnTypes[i].ToString() == isMinMax && bug1 == false)
                                    Console.WriteLine(MaxMinLinesDown);
                                else { Console.WriteLine(); bug1 = false; }
                            }
                        }
                    }
                    if (Cursor[0] == ColumnNames.Count)
                    {
                        if (ColumnTypes[ColumnTypes.Count - 1].ToString() == isMinMax)
                            Console.WriteLine("\n   " + spaces + "+" + lines + ColumnLines + MaxMinLinesDown);
                        else
                            Console.WriteLine("\n   " + spaces + "+" + lines + ColumnLines);
                    }
            //Last setings
                    Console.ForegroundColor = ConsoleColor.Yellow;
                //plus
                    if (Cursor[0] == ColumnNames.Count)
                    {
                        Console.Write(spaces);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(" + ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                        Console.WriteLine($"{spaces} + ");

                //Generate Row
                    if (Cursor[0] <= ColumnNames.Count)
                    {
                        Console.ForegroundColor= ConsoleColor.DarkGray;
                        Console.Write(LastSetingsLine);
                        Console.WriteLine(generateLine);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.Write(LastSetingsLine);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(generateLine);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                //Printer chaqirish
                    Console.Write(LastSpaces);
                    for (int i=0;i<BottomSetings.Count;i++)
                    {
                        Printer(i);
                    }

                    if (Cursor[0] <= ColumnNames.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\n"+LastSetingsLine);
                        Console.WriteLine(generateLine);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.Write("\n"+LastSetingsLine);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(generateLine);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                //KEYi o'qish
                    key = Console.ReadKey();

                    ReadTheKey(key);
                    while(Console.KeyAvailable)
                        Console.ReadKey(intercept: true);
                    //if (key.Key == ConsoleKey.DownArrow)
                      //  Cursor[0] = (Cursor[0] + 1) % 5;
                      //else Cursor[1] = (Cursor[1] + 1) % 6;
                }
            }

            public async void Generator()
            {
                StringBuilder result = new StringBuilder();
                StringBuilder type = new StringBuilder("hello");
                StringBuilder value = new StringBuilder("hello");
                StringBuilder tableName=new StringBuilder(TableName.ToString().Trim());
                StringBuilder columnName = new StringBuilder("hello");
                StringBuilder data=new StringBuilder("hello");
                HttpClient client = new HttpClient();
                HttpResponseMessage response;
                JObject jObject;
                Random random = new Random();
                string newlines = new string('\n', 8);
                string spaces = new string(' ', 40);
                string spacesg = new string(' ', 48);
                string[] gmails = { "gmail", "yahoo", "proton", "gmail", "mail", "yandex", "zoho", "gmail", "gmail" };
                string[] coms = { "com", "uz", "kz", "ru", "com", "ua", "us", "com","edu" };
                int filenumber = 2;
                StringBuilder additional = new StringBuilder("(2)");

                Console.Clear();
                Console.ForegroundColor= ConsoleColor.Gray;
                Console.Write(newlines + spaces+"Generation is ");
                Thread.Sleep(1000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(newlines + spaces+"Generation is  started succesfully");
                Thread.Sleep(500);

                if (tableName.ToString().Contains(" "))
                    tableName.Replace(tableName.ToString(),$"\"{tableName}\"");
                result.Append($"Create Table {tableName.ToString()} (");

                for (int i=0;i<ColumnNames.Count;i++)
                {
                    columnName.Replace(columnName.ToString(), ColumnNames[i].ToString().Trim());
                    if (columnName.ToString().Contains(" "))
                        columnName.Replace(columnName.ToString(), $"\"{columnName}\"");
                    result.Append($"{columnName} ");
                    switch (Types[int.Parse(ColumnTypes[i].ToString())].ToString())
                    {
                        case "gender":
                            type.Replace(type.ToString(),"varchar(6)"); break;
                        case "firstName":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "lastName":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "fullName":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "row":
                            type.Replace(type.ToString(), "serial"); break;
                        case "number":
                            type.Replace(type.ToString(), "int"); break;
                        case "streetName":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "city":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "country":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "postcode":
                            type.Replace(type.ToString(), "int"); break;
                        case "email":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "username":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "password":
                            type.Replace(type.ToString(), "varchar(255)"); break;
                        case "birthDate":
                            type.Replace(type.ToString(), "timestamp"); break;
                        case "age":
                            type.Replace(type.ToString(),   "smallint"); break;
                        case "picturePath":
                            type.Replace(type.ToString(), "text"); break;
                    }
                    result.Append($"{type.ToString()},");
                }
                result.Remove(result.Length - 1, 1);
                result.Append(");");

                result.Append($"\n\nInsert into {tableName} Values \n(");
                Console.Clear();

                for (int i=0;i<int.Parse(RowCount.ToString());i++)
                {
                    Console.WriteLine(newlines + spacesg + "    Generatinig...");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\n{0}  {1,3} seconds left",spacesg, int.Parse(RowCount.ToString()) - i - 1);
                    Console.ForegroundColor= ConsoleColor.Yellow;

                    response = await client.GetAsync("https://randomuser.me/api");
                    data.Replace(data.ToString(),await response.Content.ReadAsStringAsync());
                    jObject=JObject.Parse(data.ToString());

                    for (int j = 0; j < ColumnTypes.Count; j++)
                    {
                        switch (Types[int.Parse(ColumnTypes[j].ToString())].ToString())
                        {
                            case "gender":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["gender"]}'"); break;
                            case "firstName":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["name"]["first"].ToString()}'"); break;
                            case "lastName":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["name"]["last"]}'"); break;
                            case "fullName":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["name"]["first"]+" "+ jObject["results"][0]["name"]["last"]}'"); break;
                            case "row":
                                value.Replace(value.ToString(), $"{i+1}"); break;
                            case "number":
                                value.Replace(value.ToString(), $"{random.Next(int.Parse(Min[i].ToString()), int.Parse(Max[i].ToString()))}"); break;
                            case "streetName":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["location"]["street"]["name"]}'"); break;
                            case "city":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["location"]["city"]}'"); break;
                            case "country":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["location"]["country"]}'"); break;
                            case "postcode":
                                value.Replace(value.ToString(), $"{jObject["results"][0]["location"]["postcode"]}"); break;
                            case "email":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["email"].ToString().Replace("example", gmails[random.Next(0, gmails.Length - 1)]).Replace("com", coms[random.Next(0,coms.Length-1)])}'"); break;
                            case "username":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["login"]["username"]}'"); break;
                            case "password":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["login"]["password"]}'"); break;
                            case "birthDate":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["dob"]["date"]}'"); break;
                            case "age":
                                value.Replace(value.ToString(), $"{jObject["results"][0]["dob"]["age"]}"); break;
                            case "picturePath":
                                value.Replace(value.ToString(), $"'{jObject["results"][0]["picture"]["large"]}'"); break;
                        }
                        result.Append($"{value}, ");
                    }
                    result.Remove(result.Length - 2, 1);
                    result.Append("),\n(");
                    Console.Clear();
                }
                result.Remove(result.Length - 3, 3);
                result.Append(";");

                while (true)
                {
                    if(!File.Exists($"C:/HelloTable/{TableName}{additional}.sql"))
                    {
                        File.WriteAllText($"C:/HelloTable/{TableName}{additional}.sql",result.ToString());
                        break;
                    }
                    else
                    {
                        additional.Replace(additional.ToString(), $"({filenumber})");
                        filenumber++;
                    }
                }
                Console.Clear();
                Console.WriteLine($"{newlines}{spacesg}      Done!");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine($"{newlines}{spaces}Result is saved at: C:/HelloTable/{TableName}{additional}.sql");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Environment.Exit(0);
                Console.WriteLine($"\n\n{spaces}      press Enter to continue");
                Console.ForegroundColor= ConsoleColor.Yellow;
                while(true)
                {
                    key=Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                        return;
                }
            }
        }
        static void Main(string[] args)
        {
            Managment Start = new Managment();
        }
    }
}
