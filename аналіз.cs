using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

public class Company
{
    public string OfficialName { get; set; }
    public List<string> Synonyms { get; set; }
    public int MentionCount { get; set; }
    public List<string> MentionedInFiles { get; set; }

    public string Industry { get; set; }
    public string Country { get; set; }
    public int FoundedYear { get; set; }
    public string CEO { get; set; }
    public decimal MarketCap { get; set; }

    public Company(string officialName, List<string> synonyms, string industry, string country, int foundedYear, string ceo, decimal marketCap)
    {
        OfficialName = officialName;
        Synonyms = synonyms;
        MentionCount = 0;
        MentionedInFiles = new List<string>();
        Industry = industry;
        Country = country;
        FoundedYear = foundedYear;
        CEO = ceo;
        MarketCap = marketCap;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Company FromJson(string json)
    {
        return JsonSerializer.Deserialize<Company>(json);
    }

    public void SaveToFile(string filePath)
    {
        File.WriteAllText(filePath, ToJson());
    }

    public static Company LoadFromFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return FromJson(json);
    }

    
    public void UpdateCEO(string newCeo)
    {
        CEO = newCeo;
    }

    public void UpdateMarketCap(decimal newMarketCap)
    {
        MarketCap = newMarketCap;
    }

    public void UpdateIndustry(string newIndustry)
    {
        Industry = newIndustry;
    }
}

public class TextAnalyzer
{
    public List<Company> Companies { get; set; }

    public TextAnalyzer(List<Company> companies)
    {
        Companies = companies;
    }

    public string PreprocessText(string text)
    {
        text = text.ToLower(); 
        text = Regex.Replace(text, @"[^\w\s]", ""); 
        return text;
    }

    public void AnalyzeText(string text, string fileName)
    {
        text = PreprocessText(text);
        foreach (var company in Companies)
        {
            foreach (var synonym in company.Synonyms)
            {
                if (text.Contains(synonym))
                {
                    company.MentionCount++;
                    if (!company.MentionedInFiles.Contains(fileName))
                    {
                        company.MentionedInFiles.Add(fileName);
                    }
                }
            }
        }
    }
}

public class FileManager
{
    public string DirectoryPath { get; set; }

   
    public long TotalFileSize { get; set; }
    public int TotalFilesProcessed { get; set; }
    public DateTime LastProcessed { get; set; }
    public List<string> ErrorFiles { get; set; }
    public string FileType { get; set; }

    public FileManager(string directoryPath, string fileType = "*.txt")
    {
        DirectoryPath = directoryPath;
        FileType = fileType;
        TotalFileSize = 0;
        TotalFilesProcessed = 0;
        LastProcessed = DateTime.MinValue;
        ErrorFiles = new List<string>();
    }

    public List<string> GetTextFiles()
    {
        try
        {
            return new List<string>(Directory.GetFiles(DirectoryPath, FileType));
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Directory {DirectoryPath} not found.");
            return new List<string>();
        }
    }

    public string ReadFile(string filePath)
    {
        try
        {
            var fileInfo = new FileInfo(filePath);
            TotalFileSize += fileInfo.Length;
            TotalFilesProcessed++;
            LastProcessed = DateTime.Now;
            return File.ReadAllText(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File {filePath} not found.");
            ErrorFiles.Add(filePath);
            return string.Empty;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Access to file {filePath} is denied.");
            ErrorFiles.Add(filePath);
            return string.Empty;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file {filePath}: {e.Message}");
            ErrorFiles.Add(filePath);
            return string.Empty;
        }
    }

    
    public void ResetFileProcessingStats()
    {
        TotalFileSize = 0;
        TotalFilesProcessed = 0;
        LastProcessed = DateTime.MinValue;
        ErrorFiles.Clear();
    }

    public string GetErrorReport()
    {
        return JsonSerializer.Serialize(ErrorFiles, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class ReportGenerator
{
    public List<Company> Companies { get; set; }

    public ReportGenerator(List<Company> companies)
    {
        Companies = companies;
    }

    public string GenerateReport()
    {
        var report = new Dictionary<string, object>();
        int totalMentions = 0;

        foreach (var company in Companies)
        {
            totalMentions += company.MentionCount;
            report[company.OfficialName] = new
            {
                TotalMentions = company.MentionCount,
                MentionedInFiles = company.MentionedInFiles,
                Industry = company.Industry,
                Country = company.Country,
                FoundedYear = company.FoundedYear,
                CEO = company.CEO,
                MarketCap = company.MarketCap
            };
        }

        var finalReport = new
        {
            TotalMentions = totalMentions,
            Companies = report
        };

        return JsonSerializer.Serialize(finalReport, new JsonSerializerOptions { WriteIndented = true });
    }

    public void SaveReport(string filePath)
    {
        string report = GenerateReport();
        try
        {
            File.WriteAllText(filePath, report);
            Console.WriteLine("Report saved successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving report to {filePath}: {e.Message}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var companies = new List<Company>
        {
            new Company("Apple Inc.", new List<string> { "apple", "aapl" }, "Technology", "USA", 1976, "Tim Cook", 2.5M),
            new Company("Microsoft Corporation", new List<string> { "microsoft", "msft" }, "Technology", "USA", 1975, "Satya Nadella", 1.9M)
            
        };

        var fileManager = new FileManager("path/to/directory");
        var textAnalyzer = new TextAnalyzer(companies);

        foreach (var filePath in fileManager.GetTextFiles())
        {
            string text = fileManager.ReadFile(filePath);
            if (!string.IsNullOrEmpty(text))
            {
                textAnalyzer.AnalyzeText(text, filePath);
            }
        }

        var reportGenerator = new ReportGenerator(companies);
        reportGenerator.SaveReport("report.json");

        Console.WriteLine("Report generated and saved to report.json");

       
        companies[0].UpdateCEO("New CEO");
        companies[1].UpdateMarketCap(2.1M);
        fileManager.ResetFileProcessingStats();
        Console.WriteLine("Error report: " + fileManager.GetErrorReport());
    }
}
