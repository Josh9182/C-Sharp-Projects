using System;
using System.IO;
using System.Collections.Generic;

public class FileReader {
    public static List<string[]> ReadFile(string file_path) {
        if (!File.Exists(file_path)) {
            throw new FileNotFoundException($"File: {file_path} not found. Please retry.");
        }
        else {
            var lines = new List<string[]>();
            foreach (var line in File.ReadAllLines(file_path)) {
                if (!string.IsNullOrWhiteSpace(line)) {
                    lines.Add(line.Split(','));
                }
            }
            return lines;
        }
    }
}

public class Program {
    static void Main() {
        string file_path = "C:\\Users\\template\\Documents\\data.csv";
        try {
            var data = CSVReader.ReadCSV(file_path);
            foreach (var row in data) {
                Console.WriteLine(string.Join(" | ", row));
            }
        }
        catch (Exception err) {
            Console.WriteLine($"This file cannot be read correctly. Please retry.");
        }
    }
}
