using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace UsingNetFrameworkLab_CS_ar
{
  class Program
  {
    static void Main(string[] args)
    {
      while (true)
      {
        Console.WriteLine("Enter one of the following:");
        Console.WriteLine("a to find the difference in days " +
          "between two dates,");
        Console.WriteLine("b to write and read XML,");
        Console.WriteLine("c to convert a phrase to Pig Latin,");
        Console.WriteLine("x to exit: ");
        ConsoleKeyInfo key = Console.ReadKey();
        char resultChar = char.ToUpper(key.KeyChar);
        if (resultChar == 'X')
        {
          // Stop running the code
          break;
        }

        if (resultChar == 'A')
        {
          DaysFromToday();
        }
        else
        {
          if (resultChar == 'B')
          {
            WriteAndReadXML();
          }
          else
          {
            PigLatinConverter();
          }
        }
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();

      }

    }
    static void DaysFromToday()
    {
      Console.Clear();
      int whatMonth;
      int whatDay;
      int whatYear;

      while (true)
      {
        Console.WriteLine("Enter the month (1-12)");
        whatMonth = Convert.ToInt32(Console.ReadLine());
        if (whatMonth > 0 && whatMonth <= 12)
        {
          break;
        }
      }

      while (true)
      {
        Console.WriteLine("Enter the day (1-31)");
        whatDay = Convert.ToInt32(Console.ReadLine());
        if (whatDay > 0 && whatDay <= 31)
        {
          break;
        }
      }
      Console.WriteLine("Enter the year");
      whatYear = Convert.ToInt32(Console.ReadLine());
      DateTime whatDate = new
        DateTime(whatYear, whatMonth, whatDay);

      Console.WriteLine();
      Console.WriteLine("You selected {0:D}", whatDate);
      
      TimeSpan timeUntil;
      timeUntil = whatDate - DateTime.Today;

      int daysDiff = timeUntil.Days;
      if (daysDiff > 0)
      {
        Console.WriteLine(
          "That is {0:N0} days from now", daysDiff);
      }
      else
      {
        Console.WriteLine(
          "That was {0:N0} days ago", -daysDiff);
      }
      Console.WriteLine();
      Console.Write("Press any key to continue...");
      Console.ReadKey();
      }
    static void WriteAndReadXML()
    {
      Console.Clear();
      XmlWriterSettings settings =
  new XmlWriterSettings();
      settings.Indent = true;
      settings.NewLineChars = "\r\n";
      XmlWriter writer =
        XmlWriter.Create("c:\\Friends.xml", settings);
      writer.WriteStartDocument(true);
      writer.WriteStartElement("Friends");
      string enteredString;
      string personsName;
      int personsAge;
      string personsEmail;
      while (true)
      {
        Console.WriteLine("Enter the name of a friend");
        personsName = Console.ReadLine();

        Console.WriteLine("Enter this friend's age");
        personsAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter this friend's email");
        enteredString = Console.ReadLine();
        if (enteredString != String.Empty)
        {
          personsEmail = enteredString;
        }
        else
        {
          personsEmail = "Unknown";
        }
        writer.WriteStartElement("Friend");
        writer.WriteElementString("Name", personsName);
        writer.WriteElementString("Age", personsAge.ToString());
        writer.WriteElementString("Email", personsEmail);
        writer.WriteEndElement();

        Console.WriteLine();
        Console.Write(
          "Press a key. Enter x if you are done adding friends.");
        ConsoleKeyInfo key = Console.ReadKey();

        Char resultChar = Char.ToUpper(key.KeyChar);
        if (resultChar == 'X')
        {
          break;
        }
        Console.WriteLine();
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();

        StringBuilder xmlString = new StringBuilder();
        xmlString.AppendLine("Friends:");

        XmlReader reader =
          XmlReader.Create("C:\\Friends.xml");
        while (reader.ReadToFollowing("Friend"))
        {
          reader.ReadToFollowing("Name");
          xmlString.Append("  " + reader.ReadInnerXml());
          reader.ReadToFollowing("Age");
          xmlString.Append(" is " + reader.ReadInnerXml() + ". ");
          reader.ReadToFollowing("Email");
          xmlString.AppendLine("Email is " + reader.ReadInnerXml());
        }
        reader.Close();
        Console.WriteLine();
        Console.WriteLine(xmlString.ToString());
       

      }


    }
    static void PigLatinConverter()
    {
      Console.Clear();
      string phrase;
      StringBuilder pigLatin;
      string word;
      int location;
      string consonant;
      string firstLetter;
      bool lastWord;
      char lastChar;
      string punctuation;
      int counter;
      const string vowels = "aeiouAEIOU";

      while (true)
      {
        Console.WriteLine(
  "Enter a phrase to translate. Enter 0 to exit.");
        phrase = Console.ReadLine();

        if (phrase.StartsWith("0"))
        {
          break;
        }
        pigLatin = new StringBuilder();
        lastWord = false;
        punctuation = String.Empty;
        while (true)
        {
          location = phrase.IndexOf(" ");
          if (location > 0)
          {
            word = phrase.Substring(0, location);
          }
          else
          {
            word = phrase;
            lastWord = true;
          }
          if (lastWord == true)
          {
            lastChar = word[word.Length - 1];
            if (Char.IsPunctuation(lastChar))
            {
              punctuation = lastChar.ToString();
              word = word.Remove(word.Length - 1);
            }
          }

          firstLetter = word[0].ToString();
          if (!vowels.Contains(word[0].ToString()))
          {
            counter = 0;
            while (true)
            {
              if (counter == word.Length)
              {
                break;
              }
              consonant = word[0].ToString();
              word = word.Remove(0, 1);
              word = word.Insert(word.Length,
                consonant.ToString());
              if (vowels.Contains(word[0].ToString()))
              {
                break;
              }
              counter += 1;
            }
          }
          word = word.Insert(word.Length, "ay");
          word = word.ToLower();
          if (String.Equals(firstLetter,
            firstLetter.ToUpper()))
          {
            firstLetter = word[0].ToString();
            word = word.Remove(0, 1);
            word = word.Insert(0, firstLetter.ToUpper());
          }
          if (punctuation != String.Empty)
          {
            word = word.Insert(word.Length, punctuation);
          }
          pigLatin.Append(word + " "); if (lastWord == true)
          {
            break;
          }
          phrase = phrase.Remove(0, word.Length - 1);

        }
        Console.WriteLine(pigLatin.ToString());
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();

      }

    }


  }
}
