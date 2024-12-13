using System;
using System.IO;
using System.Collections.Generic;

public class CSVReader {
    public static List<string[]> ReadCSV(string file_path) { // Method which reads a csv file input and returns the parsed data via a list of arrays
        if (!File.Exists(file_path)) {
            throw new FileNotFoundException($"File: {file_path} not found. Please retry.");
        }
        else {
            var lines = new List<string[]>(); // Empty list of arrays to house each lines of iterated csv data
            foreach (var line in File.ReadAllLines(file_path)) { // iterate through each line in the file based off the file input
                if (!string.IsNullOrWhiteSpace(line)) { // Ignore NULL / white space lines, if correct format then split the line via "," and add to the the lines list
                    lines.Add(line.Split(','));
                }
            }
            return lines; // Return global value of list of arrays
        }
    }
}

public class Program { 
    static void Main() {
        string file_path = "C:\\Users\\joshlewis\\Documents\\csvjson.csv";
        try {
            var data = CSVReader.ReadCSV(file_path); // Import method and fill in with file_path variable
            foreach (var row in data) { // Iterate through each line and print for error checking
                Console.WriteLine(string.Join(" | ", row));
            }
        }
        catch (Exception err) {
            Console.WriteLine($"This file cannot be read correctly. Please retry.");
        }
    }
}
