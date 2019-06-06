using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32019
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = new string[3];
            lines[0] = "8 9 10";
            lines[1] = "16 X 20";
            lines[2] = "24 X 30";
            int[] XInRow = new int[3];
            int[] XInCol = new int[3];

            string[,] asquare = new string[3, 3];
            int temp = 0;

            for (int i = 0; i < 3; i++)
            {
                XInCol[i] = 0;
                XInRow[i] = 0;
            }
            for (int y = 0; y < 3; y++)
            {

                for (int x = 0; x < 3; x++)
                {
                    asquare[x, y] = lines[y].Split(new char[] { ' ' })[x];
                    if (!int.TryParse(asquare[x, y], out temp))
                    {
                        XInCol[x]++;
                        XInRow[y]++;
                    }
                }
            }
          //  Console.WriteLine("stop");
            while (XInRow[0] != 0 || XInRow[1] != 0 || XInRow[2] != 0 ||
                XInCol[0] != 0 || XInCol[1] != 0 || XInCol[2] != 0
                )
            {
                
                    for (int i = 0; i < 3; i++)
                    {
                    if (XInRow[i] == 1)
                    {

                        if (!int.TryParse(asquare[0, i], out temp))
                        {
                            //find a = line2 - (line3-line2)

                            int l2, l3;
                            int.TryParse(asquare[1, i], out l2);
                            int.TryParse(asquare[2, i], out l3);
                            asquare[0, i] = (l2 - (l3 - l2)).ToString();
                            XInRow[i]--;
                            XInCol[0]--;
                        }
                        else if (!int.TryParse(asquare[1, i], out temp))
                        {
                            //d = (l3-l1)/2 + li
                            int l1, l3;
                            int.TryParse(asquare[0, i], out l1);
                            int.TryParse(asquare[2, i], out l3);
                            asquare[1, i] = ((l3 - l1)/2+l1).ToString();
                            XInRow[i]--;
                            XInCol[1]--;
                        }
                        else
                        {
                            //2d = l1+(l2-l1)*2
                            int l1, l2;
                            int.TryParse(asquare[0, i], out l1);
                            int.TryParse(asquare[1, i], out l2);
                            asquare[2, i] = (l1 + (l2 - l1)*2).ToString();
                            XInRow[i]--;
                            XInCol[2]--;
                        }
                    }

                        if (XInCol[i] == 1)
                        {
                        if (!int.TryParse(asquare[i,0], out temp))
                        {
                            //find a = line2 - (line3-line2)

                            int l2, l3;
                            int.TryParse(asquare[i,1], out l2);
                            int.TryParse(asquare[i,2], out l3);
                            asquare[i,0] = (l2 - (l3 - l2)).ToString();
                            XInCol[i]--;
                            XInRow[0]--;
                        }
                        else if (!int.TryParse(asquare[i,1], out temp))
                        {
                            //d = (l3-l1)/2 + li
                            int l1, l3;
                            int.TryParse(asquare[i,0], out l1);
                            int.TryParse(asquare[i,2], out l3);
                            asquare[i,1] = ((l3 - l1) / 2 + l1).ToString();
                            XInCol[i]--;
                            XInRow[1]--;
                        }
                        else
                        {
                            //2d = l1+(l2-l1)*2
                            int l1, l2;
                            int.TryParse(asquare[i,0], out l1);
                            int.TryParse(asquare[i,1], out l2);
                            asquare[i,2] = (l1 + (l2 - l1) * 2).ToString();
                            XInCol[i]--;
                            XInRow[2]--;
                        }
                    }
                    }
                
            }


            //output
            string output = "";
            for (int y = 0; y < 3; y++)
            {

                for (int x = 0; x < 3; x++)
                {
                    output += asquare[x, y] + " ";
                }
                output += "\n";
            }
            Console.WriteLine(output);
                    Console.ReadLine();
        }
    }
}
