/* 
 * 
I approached this challenge with no prior knowledge of C#. As my method, I spent the first week
reading C# documentation, familiarizing self with VS Community (prior experience with VS Code only),
watching freeCodeCamp's full C# tutorial on youtube, and running through as many tutorials as possible.
I then spent the second week working on the challenge in 1.5/2 hr blocks, not to exceed 8 total hours.

Regardless of outcome, I learned the following:

basic structure of C# files, programs,
foundational principles of C# syntax and writing,
the process of accessing tabular data stored elsewhere into a program, inputing that data into a foreach and nested switch,
    and how to format/output that data to a new location,
familiarized self with pulling data to be used in math operators (also learned about math operators),
furthered understanding of C#s datatypes, how they interact, and the methods used on them,
did not learn how to compute polygons, I know the method used elsewhere works,
but I'm not sure how to implement,


explanation of code:
program links to challenge shape list,
makes two arrays, one for eventual output (length of file, 6 columns)/ one for use in string split,
declare/initialize vars,
pull string located after separator char, array position 1 (shape id col.),
run switch, test for equality of string, run internal code,
internal code creates double using value located at corresponding array location,
completes corresponding math,
call upon array fileOutput, log line # and corresponding data into it, loop through entire file,
streamWriter writes new csv file at location, following code populates formatted output,
program ends
 
*/

using System;
using System.IO;
class Program
{
    static void Main()
    { 

        string filePath = "/Users/nick/Gentex/MVChallenge/ShapeList2.csv";
        int readShapeData = System.IO.File.ReadAllLines(filePath).Length;
        string[,] fileOutput = new string[readShapeData, 6];
        string[] readLine = System.IO.File.ReadAllLines(filePath);
        
        int counter = 0;
        double area = 0;
        double perimeter = 0;
        double centerX = 0;
        double centerY = 0;

        foreach (string line in readLine)
        {
            string lineItem = line.Split(',')[1]; 

            switch (lineItem)
            {

                case "Circle":
                    area = Math.PI * Math.Pow(double.Parse(line.Split(',')[7]), 2);
                    perimeter = 2 * Math.PI * double.Parse(line.Split(',')[7]);
                    centerX = double.Parse(line.Split(',')[3]);
                    centerY = double.Parse(line.Split(',')[5]);
                    break;
                case "Square":
                    area = Math.Pow(double.Parse(line.Split(',')[7]), 2);
                    perimeter = double.Parse(line.Split(',')[7]) * 4;
                    centerX = double.Parse(line.Split(',')[3]);
                    centerY = double.Parse(line.Split(',')[5]);
                    break;
                case "Equilateral Triangle":
                    area = (double.Parse(line.Split(',')[7]) * double.Parse(line.Split(',')[7])) / 2;                            //(base * height) / 2
                    perimeter = double.Parse(line.Split(',')[7]) * 3;
                    centerX = double.Parse(line.Split(',')[3]);
                    centerY = double.Parse(line.Split(',')[5]);
                    break;
                case "Ellipse":
                    area = Math.PI * (double.Parse(line.Split(',')[7])) * (double.Parse(line.Split(',')[9]));
                    perimeter =
                    centerX = double.Parse(line.Split(',')[3]);
                    centerY = double.Parse(line.Split(',')[5]);
                    break;
                case "Polygon":

                    //???lost

                    //code outputs data as equilateral triangle
                    break;
            }

            fileOutput[counter, 0] = (counter + 1).ToString(); 
            fileOutput[counter, 1] = lineItem; 
            fileOutput[counter, 2] = area.ToString(); 
            fileOutput[counter, 3] = perimeter.ToString(); 
            fileOutput[counter, 4] = centerX.ToString(); 
            fileOutput[counter, 5] = centerY.ToString();
            counter++; 
        }

        using (StreamWriter newShapeFile = new StreamWriter(@"/Users/nick/Gentex/MVChallenge/newShapeFile.csv"))
        {
            newShapeFile.WriteLine("ID,Shape,Area,Perimeter,CenterX,CenterY");

            for (int i = 0; i < fileOutput.GetLength(0); i++)
            {
                string content = "";
                for (int j = 0; j < fileOutput.GetLength(1) - 1; j++)
                {
                    content += fileOutput[i, j] + ",";
                }
                content += fileOutput[i, fileOutput.GetLength(1) - 1];
                newShapeFile.WriteLine(content);
            }
        }
    }
}